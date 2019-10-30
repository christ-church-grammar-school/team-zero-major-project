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
        private int StudentKey;

        public StudentResultsMain(int studentId)
        {
            InitializeComponent();
            StudentKey = studentId;

            setNames();
            setTests();

            changeTextBlocks(TestInfos[0].Title as string);
        }

        public void setTests()
        {
            if(StudentKey == 1)
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
            }

            if(StudentKey == 2)
            {
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
        }

        public void setNames()
        {
            ResultsList.ItemsSource = TestInfos;
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
                    TitleBox.FontWeight = FontWeights.ExtraBold;

                    ScoreBox.Text = "Score: ";
                    ScoreBox.FontWeight = FontWeights.Bold;
                    ScoreBox.Inlines.Add(new Run(item.Score) { FontWeight = FontWeights.Normal });

                    PercentageBox.Text = "Percentage: ";
                    PercentageBox.FontWeight = FontWeights.Bold;
                    PercentageBox.Inlines.Add(new Run(item.Percentage) { FontWeight = FontWeights.Normal });

                    GradeBox.Text = "Grade: ";
                    GradeBox.FontWeight = FontWeights.Bold;
                    GradeBox.Inlines.Add(new Run(item.Grade) { FontWeight = FontWeights.Normal });

                    AverageBox.Text = "Class Average: ";
                    AverageBox.FontWeight = FontWeights.Bold;
                    AverageBox.Inlines.Add(new Run(item.Average) { FontWeight = FontWeights.Normal });

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

        private void ResultsInDepth(object sender, RoutedEventArgs e)
        {
            InsideResult insideResult = new InsideResult();
            insideResult.Show();
        }
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
