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
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// 

    public partial class Page1 : Page
    {
        public EventHandler ladder;
        public string loginUserName { get; set; }

        List<StudentLogin> logins = new List<StudentLogin> { };

        public Page1()
        {
            InitializeComponent();
            DataContext = this;

            createDummyStudent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            foreach(var item in logins)
            {
                if (loginUserName == item.CorrectUsername)
                {
                    if (this.PasswordBox.Password == item.CorrectPassword)
                    {
                        ClimbLadder();
                    }
                    else
                    {
                        MessageBox.Show("Login credentials incorrect retard");
                    }
                }
                else
                {
                    MessageBox.Show("Login credentials incorrect retard");
                }
            }
        }

        private void EnterKeyPasswordBox(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Login(PasswordBox, e);
            }
        }

        public void createDummyStudent()
        {
            logins.Add(new StudentLogin()
            {
                CorrectUsername = "Moox",
                CorrectPassword = "Angoose"
            });
        }

        private void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }
    }

    public class StudentLogin
    {
        public string CorrectUsername { get; set; }
        public string CorrectPassword { get; set; }
    }
}
