using Medical_calculator.MVVM.Model;
using Medical_calculator.MVVM.Model.DataStructures;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Medical_calculator.MVVM.View
{
    public partial class BSACalcView : UserControl, INotifyPropertyChanged
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

        public BSACalcView()
        {
            InitializeComponent();

            DataContext = this;

            LabelText = "Result:";
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
            ParamsForBSA paramsForBSA = GetParamsObject();
            BSACalculator bsaCalculator = new BSACalculator(paramsForBSA);

            double bsaMostellera = bsaCalculator.GetBSAByMostellera();
            double bsaDuBois = bsaCalculator.GetBSAByDuBois();
            double bsaHaycock = bsaCalculator.GetBSAByHaycock();
            double bsaGehanGeorge = bsaCalculator.GetBSAByGehanGeorge();

            BSATemplateParams bsaTemplateParams = new BSATemplateParams(bsaMostellera, bsaDuBois, bsaHaycock, bsaGehanGeorge);

            string resultStr = TemplateGenerator.GetBSAResponseTemplate(bsaTemplateParams);

            return resultStr;
        }

        private ParamsForBSA GetParamsObject()
        {
            var paramsObject = new ParamsForBSA();

            paramsObject.HeightStr = HeightTextBox.Text;
            paramsObject.WeightStr = WeightTextBox.Text;

            return paramsObject;
        }
    }
}
