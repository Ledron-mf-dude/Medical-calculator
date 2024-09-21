using Medical_calculator.MVVM.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical_calculator.MVVM.View
{
    public partial class GFRCalcView : UserControl, INotifyPropertyChanged
    {
        private const double creatinineMr = 113.12;
        private const string CKD_EPI_ResponsePattern = "GFR ( CKD-EPI formula ) {0} ml/min/1.73m2\n";
        private const string MDRD_ResponsePattern = "GFR ( MDRD4 formula ) {0} ml/min/1.73m2\n";
        private const string CG_ResponsePattern = "GFR ( Cockcroft−Gault ) {0} ml/min\n";
        private const string CG_BSA_ResponsePattern = "GFR ( CG - BSA ) {0} ml/min/1.73m2\n";

        private string _labelText;

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                OnPropertyChanged("LabelText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public GFRCalcView()
        {
            InitializeComponent();

            DataContext = this;

            LabelText = "Result:";
        }

        private void IntTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DoubleTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            Regex regex = new Regex(@"^\d*\.?\d{0,2}$");
            e.Handled = !regex.IsMatch(fullText);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string result = GetTextResult();
            SetResultToLable(result);
        }

        private void SetResultToLable(string result)
        {
            if(string.IsNullOrEmpty(result))
            {
                LabelText = "Error!";
            }
            else
            {
                LabelText = result;
            }
        }

        private string GetTextResult()
        {
            ParamsForGRF paramsForGRF = GetParamsObject();

            double ckd_epiResult = CalculateGFRByCKD_EPI(paramsForGRF);
            double mdrdResult = CalculateGFRByMDRD(paramsForGRF);
            double cg_Result = CalculateGFRByCG(paramsForGRF);
            double cg_bsa_Result = CalculateGFRByCG_BSA(paramsForGRF, cg_Result);
            string resultStr = GenerateTextResponse(ckd_epiResult, mdrdResult, cg_Result, cg_bsa_Result);


            return resultStr;
        }

        private string GenerateTextResponse(double ckd_epiResult, double mdrdResult, double cg_Result, double cg_bsa_Result)
        {
            string result = "";

            if(ckd_epiResult > 0)
            {
                result += string.Format(CKD_EPI_ResponsePattern, ckd_epiResult);
            }

            if(mdrdResult > 0)
            {
                result += string.Format(MDRD_ResponsePattern, mdrdResult);
            }

            if (cg_Result > 0)
            {
                result += string.Format(CG_ResponsePattern, cg_Result);
            }

            if (cg_bsa_Result > 0)
            {
                result += string.Format(CG_BSA_ResponsePattern, cg_bsa_Result);
            }

            return result;
        }

        private ParamsForGRF GetParamsObject()
        {
            var paramsObject = new ParamsForGRF();
            paramsObject.isAfrican = (bool)african.IsChecked;
            paramsObject.isFemale = (bool)female.IsChecked;
            paramsObject.isMgDl = (bool)mgDl.IsChecked;
            paramsObject.isMkMolL = (bool)mkMolL.IsChecked;
            paramsObject.isMMolL = (bool)mMolL.IsChecked;
            paramsObject.AgeStr = AgeTextBox.Text;
            paramsObject.HeightStr = HeightTextBox.Text;
            paramsObject.CreatinineStr = CreatinineTextBox.Text;
            paramsObject.WeightStr = WeightTextBox.Text;

            return paramsObject;
        }

        private double CalculateGFRByCKD_EPI(ParamsForGRF paramsForGRF)
        {
            double ckd_epiResult = 0;

            if(paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0) return ckd_epiResult;

            double creatitineMgDl = GetCreatinineInMgDl(paramsForGRF);

            double k = paramsForGRF.isFemale ? 0.7 : 0.9;
            double a = paramsForGRF.isFemale ? -0.329 : -0.411;

            var minMaxValue = creatitineMgDl / k;
            double minValue = minMaxValue;
            double maxValue = minMaxValue;

            if(minMaxValue > 1)
            {
                minValue = 1;
            }
            if (minMaxValue < 1)
            {
                maxValue = 1;
            }
            var minValuePow = Math.Pow(minValue, a);
            var maxValuePow = Math.Pow(maxValue, -1.209);
            var agePow = Math.Pow(0.993, paramsForGRF.Age);

            ckd_epiResult = 141 * (minValuePow * maxValuePow * agePow);

            if (paramsForGRF.isFemale) ckd_epiResult = ckd_epiResult * 1.018;
            if (paramsForGRF.isAfrican) ckd_epiResult = ckd_epiResult * 1.159;

            return Math.Round(ckd_epiResult, 2);
        }

        private double CalculateGFRByMDRD(ParamsForGRF paramsForGRF)
        {
            double mdrdResult = 0;

            if (paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0) return mdrdResult;

            double creatitineMgDl = GetCreatinineInMgDl(paramsForGRF);

            double genderCoefficient = paramsForGRF.isFemale ? 0.742 : 1;
            double raseCoefficient = paramsForGRF.isAfrican ? 1.210 : 1;

            var creatitineMgDlPow = Math.Pow(creatitineMgDl, -1.154);
            var agePow = Math.Pow(paramsForGRF.Age, -0.203);

            mdrdResult = 186 * creatitineMgDlPow * agePow * genderCoefficient * raseCoefficient;

            return Math.Round(mdrdResult, 2);
        }

        private double CalculateGFRByCG(ParamsForGRF paramsForGRF)
        {
            double cg_Result = 0;

            if (paramsForGRF == null || paramsForGRF.Age == 0 || paramsForGRF.Creatinine == 0 || paramsForGRF.Weight == 0) return cg_Result;

            double creatitineMgDl = GetCreatinineInMgDl(paramsForGRF);

            double genderCoefficient = paramsForGRF.isFemale ? 0.85 : 1;

            cg_Result = ((140 - paramsForGRF.Age) * paramsForGRF.Weight * genderCoefficient) / (72 * creatitineMgDl);

            return Math.Round(cg_Result, 2);
        }

        private double CalculateGFRByCG_BSA(ParamsForGRF paramsForGRF, double cg_Result)
        {
            double cg_bsaResult = 0;

            if (paramsForGRF == null || paramsForGRF.Weight == 0 || paramsForGRF.Height == 0 || cg_Result == 0) return cg_bsaResult;

            var bsaMostellera = 0.0167 * Math.Pow(paramsForGRF.Weight, 0.5) * Math.Pow(paramsForGRF.Height, 0.5);
            
            cg_bsaResult = 1.73 * cg_Result / bsaMostellera;

            return Math.Round(cg_bsaResult, 2);
        }

        private double GetCreatinineInMgDl(ParamsForGRF paramsForGRF)
        {
            double creatitineMgDl = paramsForGRF.Creatinine;
            if (paramsForGRF.isMkMolL)
            {
                creatitineMgDl = (creatitineMgDl * creatinineMr) / 10 * 0.001;
            }
            else if (paramsForGRF.isMMolL)
            {
                creatitineMgDl = (creatitineMgDl * creatinineMr) / 10;
            }
            return creatitineMgDl;
        }
    }
}
