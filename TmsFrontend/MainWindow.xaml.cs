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
        public int studentId;

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
                studentId = loginPage.studentKey;
            };

            //Main.Content = new StudentTestsMain(studentId); breaks it for some reason
        }

        private void ButtonClickTest(object sender, RoutedEventArgs e)
        {
            var testsPage = new StudentTestsMain(studentId);
            Main.Content = testsPage;
            ChangeButtonColour(sender);
        }

        private void ButtonClickResult(object sender, RoutedEventArgs e)
        {
            var resultsPage = new StudentResultsMain(studentId);
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
            Main.Content = null;

            ResultButton.Foreground = Brushes.White;
            TestButton.Foreground = Brushes.White;

            LoginPage();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            //Code breaks when function removed
        }
    }
}
