using Medical_calculator.MVVM.Model.DataStructures;
using Medical_calculator.MVVM.Model;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical_calculator.MVVM.View
{
    public partial class ABSICalcView : UserControl, INotifyPropertyChanged
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

        public ABSICalcView()
        {
            InitializeComponent();

            DataContext = this;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IntTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string result = GetTextResult();
            SetResultToLable(result);
        }

        private string GetTextResult()
        {
            ParamsForABSI paramsForABSI = GetParamsObject();
            ABSICalculator absiCalculator = new ABSICalculator(paramsForABSI);

            double absi = absiCalculator.GetABSI();
            double bmi = absiCalculator.GetBMI();

            ABSITemplateParams bsaTemplateParams = new ABSITemplateParams(absi, bmi);

            string resultStr = TemplateGenerator.GetABSIResponseTemplate(bsaTemplateParams);

            return resultStr;
        }

        private ParamsForABSI GetParamsObject()
        {
            var paramsObject = new ParamsForABSI();

            paramsObject.HeightStr = HeightTextBox.Text;
            paramsObject.WeightStr = WeightTextBox.Text;
            paramsObject.WaistCircumferenceStr = WaistCircumferenceTextBox.Text;

            return paramsObject;
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
    }
}
