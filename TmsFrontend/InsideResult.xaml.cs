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
using System.Windows.Shapes;

namespace TmsFrontend
{
    /// <summary>
    /// Interaction logic for InsideResult.xaml
    /// </summary>
    public partial class InsideResult : Window
    {
        List<ResultQuestion> ResultQuestions = new List<ResultQuestion> { };
        List<ResultQuestion> ShownResultQuestions = new List<ResultQuestion> { };
        private string testToShow;

        public InsideResult(string testName)
        {
            InitializeComponent();
            testToShow = testName;

            setTests();
            setButtons();

            changeTextBlocks(ShownResultQuestions[0].Title as string);
        }

        //This funtion decalares and adds new objects of type "ResultQuestion" to
        //the list "ResultQuestion"

        public void setTests()
        {

            ResultQuestions.Add(new ResultQuestion()
            {
                QuestionStatement = "Double the number.",
                Mark = 5,
                OutOf = 5,
                Title = "Question 1",
                ofTest = "WPF Test"
            });

            ResultQuestions.Add(new ResultQuestion()
            {
                QuestionStatement = "Triple the number.",
                Mark = 0,
                OutOf = 5,
                Title = "Question 2",
                ofTest = "WPF Test"
            });

            ResultQuestions.Add(new ResultQuestion()
            {
                QuestionStatement = "Half the number.",
                Mark = 0,
                OutOf = 5,
                Title = "Question 1",
                ofTest = "C# Practical Programming Test"
            });

            ResultQuestions.Add(new ResultQuestion()
            {
                QuestionStatement = "Square the number.",
                Mark = 5,
                OutOf = 5,
                Title = "Question 2",
                ofTest = "C# Practical Programming Test"
            });

            assignQuestions();
        }

        //This function adds objects of type "ResultQuestion" to the list
        //"ShownResultQuestions" if they have been assigned to the student that has 
        //logged in by comparing the int "testToShow" to the array of ints
        //"ofTest", a part of the ResultQuestion object

        public void assignQuestions()
        {
            foreach (var item in ResultQuestions)
            {
                if (item.ofTest == testToShow)
                {
                    ShownResultQuestions.Add(item);
                }
            }
        }

        //This function creates and sets the names of the buttons on the side
        //of the page which allows the user to select different tests

        public void setButtons()
        {
            QuestionsList.ItemsSource = ShownResultQuestions;
        }

        //This function changes the textblocks displayes on the screen to
        //correspond to the selected test
        //It is the button click function of buttons in the listbox

        private void ChangeTest(object sender, RoutedEventArgs e)
        {
            var buttonHolder = sender as Button;

            changeTextBlocks(buttonHolder.Content as string);
        }

        private void changeTextBlocks(string selectedTest)
        {
            foreach (var item in ShownResultQuestions)
            {
                if (item.Title == selectedTest)
                {
                    TitleBox.Text = item.Title;
                    TitleBox.FontWeight = FontWeights.ExtraBold;
               
                    MarkBox.Text = "Mark: ";
                    MarkBox.FontWeight = FontWeights.Bold;
                    MarkBox.Inlines.Add(new Run($"{item.Mark.ToString()}/" +
                                        $"{item.OutOf.ToString()}")
                    {
                        FontWeight = FontWeights.Normal
                    });

                    StatementBox.Text = "Question Statement: ";
                    StatementBox.FontWeight = FontWeights.Bold;
                    StatementBox.Inlines.Add(new Run(item.QuestionStatement)
                    {
                        FontWeight = FontWeights.Normal
                    });
                }
            }
        }

        private void SubmissionFileButton_Click(object sender, RoutedEventArgs e)
        {
            //download file from firebase
        }
    }

    public class ResultQuestion
    {
        public string QuestionStatement { get; set; }
        public int Mark { get; set; }
        public int OutOf { get; set; }
        public string Title { get; set; }
        public string ofTest { get; set; }
    }
}
