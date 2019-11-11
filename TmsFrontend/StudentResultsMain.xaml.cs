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
        List<TestInfo> TestsDisplayed= new List<TestInfo> { };
        private int StudentKey;

        public string testShown;

        public StudentResultsMain(int studentId)
        {
            InitializeComponent();
            StudentKey = studentId;

            setTests();
            setButtons();

            if (TestsDisplayed.Count != 0)
            {
                changeTextBlocks(TestsDisplayed[0].Title as string);
            }
            else
            {
                changeTextBlocks("No Results Available");
            }
        }

        //This funtion decalares and adds new objects of type "TestInfo" to
        //the list "TestInfos"

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
                Title = "C# Practical Programming Test",
                Assigned = new int[2] { 1, 3 }
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
                Title = "WPF Test",
                Assigned = new int[3]{ 1, 2, 3 }
            });

            assignTests();
        }

        //This function adds objects of type "TestInfo" to the list
        //"TestsDisplayed" if they have been assigned to the student that has 
        //logged in by comparing the int "StudentKey" to the array of ints
        //"assigned", a part of the TestInfo object

        public void assignTests()
        {
            foreach(var item in TestInfos)
            {
                foreach(var num in item.Assigned)
                {
                    if(num == StudentKey)
                    {
                        TestsDisplayed.Add(item);
                    }
                }
            }
        }

        //This function creates and sets the names of the buttons on the side
        //of the page which allows the user to select different tests

        public void setButtons()
        {
            ResultsList.ItemsSource = TestsDisplayed;
        }

        //This function changes the textblocks displayes on the screen to
        //correspond to the selected test
        //It is the button click function of buttons in the listbox

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;
            
            changeTextBlocks(buttonHolder.Content as string);
        }

        //This function changes the text of the textblocks in accordance to a
        //string that it is given which

        private void changeTextBlocks(string selectedTest)
        {
            testShown = selectedTest;

            if(testShown == "No Results Available")
            {
                TitleBox.Text = selectedTest;
                TitleBox.FontWeight = FontWeights.ExtraBold;

                ScoreBox.Text = null;
                
                PercentageBox.Text = null;

                GradeBox.Text = null;
               
                AverageBox.Text = null;
               

                QuestionsBox.Text = null;

                TimeLimitBox.Text = null;

                SetByBox.Text = null;

                TopicBox.Text = null;
            }

            else
            {
                foreach (var item in TestsDisplayed)
                {
                    if (item.Title == selectedTest)
                    {
                        TitleBox.Text = item.Title;
                        TitleBox.FontWeight = FontWeights.ExtraBold;

                        ScoreBox.Text = "Score: ";
                        ScoreBox.FontWeight = FontWeights.Bold;
                        ScoreBox.Inlines.Add(new Run(item.Score)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        PercentageBox.Text = "Percentage: ";
                        PercentageBox.FontWeight = FontWeights.Bold;
                        PercentageBox.Inlines.Add(new Run(item.Percentage)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        GradeBox.Text = "Grade: ";
                        GradeBox.FontWeight = FontWeights.Bold;
                        GradeBox.Inlines.Add(new Run(item.Grade)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        AverageBox.Text = "Class Average: ";
                        AverageBox.FontWeight = FontWeights.Bold;
                        AverageBox.Inlines.Add(new Run(item.Average)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        QuestionsBox.Text = "Questions: ";
                        QuestionsBox.FontWeight = FontWeights.Bold;
                        QuestionsBox.Inlines.Add(new Run(item.Questions)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        TimeLimitBox.Text = "Time Limit: ";
                        TimeLimitBox.FontWeight = FontWeights.Bold;
                        TimeLimitBox.Inlines.Add(new Run(item.TimeLimit)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        SetByBox.Text = "Set By: ";
                        SetByBox.FontWeight = FontWeights.Bold;
                        SetByBox.Inlines.Add(new Run(item.SetBy)
                        {
                            FontWeight = FontWeights.Normal
                        });

                        TopicBox.Text = "Topic: ";
                        TopicBox.FontWeight = FontWeights.Bold;
                        TopicBox.Inlines.Add(new Run(item.Topic)
                        {
                            FontWeight = FontWeights.Normal
                        });
                    }
                }
            }
        }

        //This function is the click function of the "ResultsNewWindowButton"
        //it opens a new window
        //CHANGE

        private void ResultsInDepth(object sender, RoutedEventArgs e)
        {
            InsideResult insideResult = new InsideResult(testShown);
            insideResult.Show();
        }
    }

    //A class that stores all the information of a test

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
        public int[] Assigned { get; set; }
    }
}
