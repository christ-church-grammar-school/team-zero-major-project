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
        StudentTestsMain testsPage = new StudentTestsMain();
        StudentResultsMain resultsPage = new StudentResultsMain();

        public MainWindow()
        {
            InitializeComponent();

            LoginPage();
        }

        public void LoginPage()
        {
            Page1 loginPage = new Page1(); //Login Page
            var contentCopy = Content;
            Content = loginPage;
            loginPage.ladder += (object sender, EventArgs e) =>
            {
                Content = contentCopy;
            };
            Main.Content = testsPage;
        }

        private void ButtonClickTest(object sender, RoutedEventArgs e)
        {
            Main.Content = testsPage;
            ChangeButtonColour(sender);
        }

        private void ButtonClickResult(object sender, RoutedEventArgs e)
        {
            Main.Content = resultsPage;
            ChangeButtonColour(sender);
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

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginPage();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            //Code breaks when function removed
        }
    }
}
