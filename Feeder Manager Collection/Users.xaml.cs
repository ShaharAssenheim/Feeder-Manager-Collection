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
    public partial class Users : Window
    {
        List<User> Emplist = new List<User>();
        List<string> Roles = new List<string>() { "Admin", "Maintenance", "Setup" };
        public Users()
        {
            InitializeComponent();
            RoleCB.ItemsSource = Roles;
            RestartList();
        }

        private void RestartList()
        {
            this.EmpGrid.ItemsSource = null;
            string Qry = string.Format(@"SELECT * FROM Login");
            Emplist = MainWindow.sql.SelectUsers(Qry);
            this.EmpGrid.ItemsSource = Emplist;
            Clear();
        }

        private void Grid_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)//when the user press on specific row
        {
            User row = (User)EmpGrid.SelectedItem;
            if (row != null)
            {
                NameTxt.Text = row.UserName;
                WNTxt.Text = row.UserID;
                PassTxt.Text = row.Password;
                RoleCB.SelectedIndex = Roles.IndexOf(row.Role);
                GetPhoto(row.UserID);
            }
        }

        private void GetPhoto(string p)//get the photo of the operator
        {
            try
            {
                ProfileImg.Visibility = Visibility.Visible;
                string path = @"\\mignt002\Private\falcon\" + p + ".jpg";
                BitmapImage bitmap = new BitmapImage();
                if (File.Exists(path))
                {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path);
                    bitmap.EndInit();
                    ProfileImg.Source = bitmap;
                }

                else
                {
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/profile.jpg", UriKind.Absolute);
                    bitmap.EndInit();
                    ProfileImg.Source = bitmap;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            RestartList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string query = string.Format("UPDATE Login SET UserName=N'{1}',Password='{2}', Role='{3}' WHERE UserId='{0}'", WNTxt.Text, NameTxt.Text, PassTxt.Text, RoleCB.Text);
            MainWindow.sql.Update(query);
            MessageBox.Show("The Employee Updated Succesfully.", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            RestartList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (WNTxt.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    string query = string.Format("DELETE FROM Login WHERE UserId ='{0}'", WNTxt.Text);
                    MainWindow.sql.Update(query);
                    MessageBox.Show("The Employee Deleted Succesfully.", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            RestartList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NameTxt.Text == "" || PassTxt.Text == "" || WNTxt.Text == "" || RoleCB.Text == "")
            {
                MessageBox.Show("Must Fill All Fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Emplist.Any(x => x.UserID == WNTxt.Text))
            {
                MessageBox.Show("There Is An Employee With That Work Number!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"INSERT INTO Login (UserId, UserName, Password, Role)
                                        VALUES('{0}',N'{1}','{2}','{3}')", WNTxt.Text, NameTxt.Text, PassTxt.Text, RoleCB.Text);

            MainWindow.sql.InsertNonQuery(qry);
            RestartList();
            MessageBox.Show("The Employee Added Succesfully.", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void Clear()
        {
            NameTxt.Text = "";
            WNTxt.Text = "";
            PassTxt.Text = "";
            RoleCB.SelectedItem = null;
            ProfileImg.Visibility = Visibility.Hidden;
        }

        private void WNTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = Emplist.Where(x => x.UserID.StartsWith(WNTxt.Text));
            EmpGrid.ItemsSource = list;
        }
    }
}
