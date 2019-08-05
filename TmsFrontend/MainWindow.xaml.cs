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
        }

        private void ButtonClickP2(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentResultsMain();
        }

        private void ButtonClickP1(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentTestsMain();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
