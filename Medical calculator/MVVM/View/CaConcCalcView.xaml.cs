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
    public partial class CaConcCalcView : UserControl, INotifyPropertyChanged
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

        public CaConcCalcView()
        {
            InitializeComponent();
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
