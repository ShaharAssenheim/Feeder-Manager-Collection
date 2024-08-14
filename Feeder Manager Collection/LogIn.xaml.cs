using System;
using System.Collections.Generic;
using System.IO;
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

namespace Feeder_Manager
{
    public partial class LogIn : Window
    {
        public LogIn(string Type)
        {
            InitializeComponent();
            if (Type == "FirstLogin")
            {
                CancelBtn.Visibility = Visibility.Collapsed;
                ExitBtn.Visibility = Visibility.Visible;
            }
            else if (Type == "ChangeLogin")
            {
                CancelBtn.Visibility = Visibility.Visible;
                ExitBtn.Visibility = Visibility.Collapsed;
            }
            FocusManager.SetFocusedElement(this, UserNameTxt);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string qry = string.Format(@"SELECT * FROM Login WHERE UserId='{0}' AND Password='{1}'", UserNameTxt.Text, PasswordTxt.Password);
            List<User> logList = MainWindow.sql.SelectUsers(qry);

            if (logList.Count > 0)
            {
                MainWindow.ActiveUser = logList[0];
                SetPhoto(logList[0].UserID);
                MainWindow.mn.ProfileName.Text = logList[0].UserName + " - " + logList[0].Role;
                MainWindow.mn.ProfileName2.Text = logList[0].UserName + " - " + logList[0].Role;
                MainWindow.mn.ProfileName3.Text = logList[0].UserName + " - " + logList[0].Role;
                DialogResult = true;

                Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                UserNameTxt.Text = "";
                PasswordTxt.Password = "";
                return;
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string qry = string.Format(@"SELECT * FROM Login WHERE UserId='{0}' AND Password='{1}'", UserNameTxt.Text, PasswordTxt.Password);
                List<User> logList = MainWindow.sql.SelectUsers(qry);

                if (logList.Count > 0)
                {
                    MainWindow.ActiveUser = logList[0];
                    SetPhoto(logList[0].UserID);
                    MainWindow.mn.ProfileName.Text = logList[0].UserName + " - " + logList[0].Role;
                    MainWindow.mn.ProfileName2.Text = logList[0].UserName + " - " + logList[0].Role;
                    MainWindow.mn.ProfileName3.Text = logList[0].UserName + " - " + logList[0].Role;
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    UserNameTxt.Text = "";
                    PasswordTxt.Password = "";
                    return;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetPhoto(string p)//get the photo of the operator
        {
            try
            {
                string path = @"\\mignt002\Private\falcon\" + p + ".jpg";
                BitmapImage bitmap = new BitmapImage();
                if (File.Exists(path))
                {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path);
                    bitmap.EndInit();
                    MainWindow.mn.ProfileImage.ImageSource = bitmap;
                    MainWindow.mn.ProfileImage2.ImageSource = bitmap;
                    MainWindow.mn.ProfileImage3.ImageSource = bitmap;

                }
                else
                {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/profile.jpg", UriKind.Absolute);
                    bitmap.EndInit();
                    MainWindow.mn.ProfileImage.ImageSource = bitmap;
                    MainWindow.mn.ProfileImage2.ImageSource = bitmap;
                    MainWindow.mn.ProfileImage3.ImageSource = bitmap;

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
    }
}
