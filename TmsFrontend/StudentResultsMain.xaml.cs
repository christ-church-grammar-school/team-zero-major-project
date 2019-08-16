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
        List<TestInfo> TestInfos = new List<TestInfo> { };

        public StudentResultsMain()
        {
            InitializeComponent();
            setNames();
            setTests();
        }

        public void setTests()
        {
            TestInfos.Add(new TestInfo()
            {
                Score = "21/25",
                Percentage = "92%",
                Grade = "A",
                Questions = "5",
                Average = "67%",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "C#",
                Title = "C# Practical Programming Test"
            });

            TestInfos.Add(new TestInfo()
            {
                Score = "22/25",
                Percentage = "88%",
                Grade = "A",
                Questions = "5",
                Average = "70%",
                TimeLimit = "50 Minutes",
                SetBy = "Graham Nolan",
                Topic = "WPF",
                Title = "WPF Test"
            });
        }

        public void setNames()
        {
            List<ResultItem> items = new List<ResultItem>();
            items.Add(new ResultItem() { ResultName = "C# Practical Programming Test" });
            items.Add(new ResultItem() { ResultName = "WPF Test" });

            ResultsList.ItemsSource = items;
        }

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;
            
            changeTextBlocks(buttonHolder.Content as string);
        }

        private void changeTextBlocks(string selectedTest)
        {
            foreach (var item in TestInfos)
            {
                if(item.Title == selectedTest)
                {
                    TitleBox.Text = item.Title;
                    ScoreBox.Text = item.Score;
                    PercentageBox.Text = item.Percentage;
                    GradeBox.Text = item.Grade;
                    AverageBox.Text = item.Average;
                    QuestionsBox.Text = item.Questions;
                    TimeLimitBox.Text = item.TimeLimit;
                    SetByBox.Text = item.SetBy;
                    TopicBox.Text = item.Topic;
                }
            }
        }
    }

    public class ResultItem
    {
        public string ResultName { get; set; }
    }
    
    public class TestInfo
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
