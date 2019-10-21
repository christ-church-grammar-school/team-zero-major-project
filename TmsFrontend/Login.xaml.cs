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
using Firebase.Auth;

namespace TmsFrontend
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        public void AuthenticateFirebase()
        {
            var authOptions = new FirebaseAuthOptions("AIzaSyAykW6GsgrjIdKF54WvTQVxxWkT64Ncb_Y");

            var firebase = new FirebaseAuthService(authOptions);
        }
    }
}
