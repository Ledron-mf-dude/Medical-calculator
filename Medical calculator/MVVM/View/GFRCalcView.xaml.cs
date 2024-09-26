using Medical_calculator.MVVM.Model;
using Medical_calculator.MVVM.Model.DataStructures;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical_calculator.MVVM.View
{
    public partial class GFRCalcView : UserControl, INotifyPropertyChanged
    {
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

            Regex regex = new Regex(@"^\d*\.?\d{0,4}$");
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
            GFRCalculator gFRCalculator = new GFRCalculator(paramsForGRF);

            double ckd_epiResult = gFRCalculator.GetGFRByCKD_EPI();
            double mdrdResult = gFRCalculator.GetGFRByMDRD();
            double cg_Result = gFRCalculator.GetGFRByCG();
            double cg_bsa_Result = gFRCalculator.GetGFRByCG_BSA(cg_Result);

            GFRTemplateParams gfrTemplateParams = new GFRTemplateParams(ckd_epiResult, mdrdResult, cg_Result, cg_bsa_Result);

            string resultStr = TemplateGenerator.GetGFRResponseTemplate(gfrTemplateParams);

            return resultStr;
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
    }
}
