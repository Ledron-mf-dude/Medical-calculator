using System.Windows;
using System.Windows.Input;

namespace Medical_calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ShowWarning();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ShowWarning()
        {
            WarningWindow warningWindow = new WarningWindow();
            if (warningWindow.ShowDialog() == true)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }
    }
}
