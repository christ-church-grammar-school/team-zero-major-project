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
using Google.Cloud.Firestore;

namespace TmsFrontend
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// 

    public partial class Page1 : Page
    {
        public EventHandler ladder;
        public string loginUserName { get; set; }

        public int studentKey;

        List<StudentLogin> logins = new List<StudentLogin> { };

        public Page1()
        {
            InitializeComponent();
            DataContext = this;

            createDummyStudents();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            //FirestoreDb db = FirestoreDb.Create("react-tms" );
            //CollectionReference classesFromDb = db.Collection("classes");
            //Google.Cloud.Firestore.DocumentReference classFromClasses = classesFromDb.Document("10ASD1_2019");

            int breaker = 0;
            bool fault = false;

            foreach (var item in logins)
            {
                if (breaker == 0)
                {
                    if (loginUserName == item.CorrectUsername)
                    {
                        if (this.PasswordBox.Password == item.CorrectPassword)
                        {
                            studentKey = item.StudentKey;
                            breaker += 1;
                            fault = false;
                            ClimbLadder();
                        }
                        else
                        {
                            fault = true;
                        }
                    }
                    else
                    {
                        fault = true;
                    }
                }
            }
            if (fault)
                MessageBox.Show("Login credentials incorrect");
        }

            private void EnterKeyPasswordBox(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Login(PasswordBox, e);
            }
        }

        public void createDummyStudents()
        {
            logins.Add(new StudentLogin()
            {
                StudentKey = 1,
                CorrectUsername = "Moox",
                CorrectPassword = "Angoose"
            });

            logins.Add(new StudentLogin()
            {
                StudentKey = 2,
                CorrectUsername = "Samuel",
                CorrectPassword = "Thomas"
            });

            logins.Add(new StudentLogin()
            {
                StudentKey = 3,
                CorrectUsername = "Gno",
                CorrectPassword = "Lan"
            });
        }

        private void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }
    }

    public class StudentLogin
    {
        public int StudentKey { get; set; }
        public string CorrectUsername { get; set; }
        public string CorrectPassword { get; set; }
    }
}
