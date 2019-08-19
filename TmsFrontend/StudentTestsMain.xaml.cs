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
    /// Interaction logic for StudentTestsMain.xaml
    /// </summary>
    public partial class StudentTestsMain : Page
    {
        public StudentTestsMain()
        {
            InitializeComponent();
            setNames();
        }

        public void setNames()
        {
            List<TestItem> items = new List<TestItem>();
            items.Add(new TestItem() { TestName = "Test A" });
            items.Add(new TestItem() { TestName = "Test B" });
            items.Add(new TestItem() { TestName = "Test C" });
            items.Add(new TestItem() { TestName = "Test D" });

            ResultsList.ItemsSource = items;
        }

        private void Test1(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;
            MessageBox.Show(buttonHolder.Content as String);
        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new Window();
            win2.Show();
        }
    }

    public class TestItem
    {
        public string TestName { get; set; }
    }
}
