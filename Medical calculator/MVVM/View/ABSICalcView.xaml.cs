using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for ABSICalcView.xaml
    /// </summary>
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

            //LabelText = "Result:";
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
            //string result = GetTextResult();
            //SetResultToLable(result);
        }
    }
}
