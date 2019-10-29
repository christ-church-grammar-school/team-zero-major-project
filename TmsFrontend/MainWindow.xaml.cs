using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TmsFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Page1(); //Login Page
        }

        private void ButtonClickTest(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentTestsMain();
            ChangeButtonColour(sender);
        }

        private void ButtonClickResult(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentResultsMain();
            ChangeButtonColour(sender);
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        public void ChangeButtonColour(object sender)
        {
            var buttonHolder = sender as Button;

            if (buttonHolder.Content as string == "Tests")
            {
                TestButton.Foreground = Brushes.Black;
                ResultButton.Foreground = Brushes.White;
            }
            else if (buttonHolder.Content as string == "Results")
            {
                ResultButton.Foreground = Brushes.Black;
                TestButton.Foreground = Brushes.White;
            }
        }
    }
}
