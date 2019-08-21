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
        List<TestPreview> TestPreview = new List<TestPreview> { };

        public StudentTestsMain()
        {
            InitializeComponent();
            setNames();
            setTests();

            changeTextBlocks(TestPreview[0].Title as string);
        }

        public void setTests()
        {
            TestPreview.Add(new TestPreview()
            {
                Questions = "5",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "C#",
                Title = "C# Practical Programming Test"
            });

            TestPreview.Add(new TestPreview()
            {
                Questions = "5",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "WPF",
                Title = "WPF Test"
            });
        }

        public void setNames()
        {
            List<TestItem> items = new List<TestItem>();
            items.Add(new TestItem() { TestName = "C# Practical Programming Test" });
            items.Add(new TestItem() { TestName = "WPF Test" });

            ResultsList.ItemsSource = items;
        }

        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new Window();
            win2.Show();
        }

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;

            changeTextBlocks(buttonHolder.Content as string);
        }

        private void changeTextBlocks(string selectedTest)
        {
            foreach (var item in TestPreview)
            {
                if (item.Title == selectedTest)
                {
                    TitleBox.Text = item.Title;
                    TitleBox.FontWeight = FontWeights.ExtraBold;

                    QuestionsBox.Text = "Questions: ";
                    QuestionsBox.FontWeight = FontWeights.Bold;
                    QuestionsBox.Inlines.Add(new Run(item.Questions) { FontWeight = FontWeights.Normal });

                    TimeLimitBox.Text = "Time Limit: ";
                    TimeLimitBox.FontWeight = FontWeights.Bold;
                    TimeLimitBox.Inlines.Add(new Run(item.TimeLimit) { FontWeight = FontWeights.Normal });

                    SetByBox.Text = "Set By: ";
                    SetByBox.FontWeight = FontWeights.Bold;
                    SetByBox.Inlines.Add(new Run(item.SetBy) { FontWeight = FontWeights.Normal });

                    TopicBox.Text = "Topic: ";
                    TopicBox.FontWeight = FontWeights.Bold;
                    TopicBox.Inlines.Add(new Run(item.Topic) { FontWeight = FontWeights.Normal });
                }
            }
        }

        private void TestInDepth(object sender, RoutedEventArgs e)
        {
            InsideTest insideTest = new InsideTest();
            insideTest.Show();
        }
    }

    public class TestItem
    {
        public string TestName { get; set; }
    }

    public class TestPreview
    {
        public string Title { get; set; }
        public string Score { get; set; }
        public string Percentage { get; set; }
        public string Grade { get; set; }
        public string Average { get; set; }
        public string Questions { get; set; }
        public string TimeLimit { get; set; }
        public string SetBy { get; set; }
        public string Topic { get; set; }
    }
}
