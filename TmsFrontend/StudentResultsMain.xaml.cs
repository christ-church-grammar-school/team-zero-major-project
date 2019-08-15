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
    /// Interaction logic for StudentResultsMain.xaml
    /// </summary>
    public partial class StudentResultsMain : Page
    {
        public StudentResultsMain()
        {
            InitializeComponent();
            setNames();
        }

        public void setNames()
        {
            List<ResultItem> items = new List<ResultItem>();
            items.Add(new ResultItem() { ResultName = "Test A" });
            items.Add(new ResultItem() { ResultName = "Test B" });
            items.Add(new ResultItem() { ResultName = "Test C" });
            items.Add(new ResultItem() { ResultName = "Test D" });
            items.Add(new ResultItem() { ResultName = "Test E" });

            ResultsList.ItemsSource = items;
        }

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;
            MessageBox.Show(buttonHolder.Content as String);
        }
    }


    public class ResultItem
    {
        public string ResultName { get; set; }
    }
}
