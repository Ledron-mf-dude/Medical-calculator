using Medical_calculator.MVVM.Model.DataStructures;
using Medical_calculator.MVVM.Model;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical_calculator.MVVM.View
{
    public partial class CaConcCalcView : UserControl, INotifyPropertyChanged
    {
        private const string _numericPattern = @"@""^\d*\.?\d*$""";

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

        public CaConcCalcView()
        {
            InitializeComponent();

            DataContext = this;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DoubleTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string fullText = textBox.Text + e.Text;

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
            if (string.IsNullOrEmpty(result))
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
            ParamsForCaConc paramsForBSA = GetParamsObject();
            CaConcCalculator caConcCalculator = new CaConcCalculator(paramsForBSA);

            double caConcDl = caConcCalculator.GetCaConcInDl();
            double caConcMmol = caConcCalculator.GetCaConcInMmol();

            CaConcTemplateParams caConcTemplateParams = new CaConcTemplateParams(caConcDl, caConcMmol);

            string resultStr = TemplateGenerator.GetCaConcResponseTemplate(caConcTemplateParams);

            return resultStr;
        }

        private ParamsForCaConc GetParamsObject()
        {
            var paramsObject = new ParamsForCaConc();

            paramsObject.CaTotalStr = CaTotalTextBox.Text;
            paramsObject.AlbuminStr = AlbuminTextBox.Text;
            paramsObject.IsValueInDl = (bool)mgDL.IsChecked;

            return paramsObject;
        }

        private void mgDL_Checked(object sender, RoutedEventArgs e)
        {
            if(mgDL.IsChecked == true && gDL != null && gDL.IsChecked != true)
            {
                gDL.IsChecked = true;
            }
        }

        private void mmolL_Checked(object sender, RoutedEventArgs e)
        {
            if (mmolL.IsChecked == true && gL != null && gL.IsChecked != true)
            {
                gL.IsChecked = true;
            }
        }

        private void gDL_Checked(object sender, RoutedEventArgs e)
        {
            if (gDL.IsChecked == true && mgDL != null && mgDL.IsChecked != true)
            {
                mgDL.IsChecked = true;
            }
        }

        private void gL_Checked(object sender, RoutedEventArgs e)
        {
            if (gL.IsChecked == true && mmolL != null && mmolL.IsChecked != true)
            {
                mmolL.IsChecked = true;
            }
        }
    }
}
