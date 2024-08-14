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

namespace Feeder_Manager
{
    public partial class AddNewTable : Window
    {
        List<string> TableTypes = new List<string>() {"D1", "HS/D4", "S/F", "SX", "X4", "TX"};

        public AddNewTable()
        {
            InitializeComponent();
            Table_Type.ItemsSource = TableTypes;
            Calibration_Date.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy HH:mm");
            Table_Status.Text = "In Work";
            User_ID.Text = MainWindow.ActiveUser.UserID;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            if (Table_ID.Text == "" || User_ID.Text == "" || Table_Type.Text == "")
            {
                MessageBox.Show("Fill All Fileds", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (!MainWindow.TableList.Any(x => x.TableID == Table_ID.Text))
            {
                string qry = string.Format(@"INSERT INTO Tables (TableID, UserID, TableType, CreationDate , TableStatus, MalfunctionCount, LastTimeChecked) 
                                    VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                     Table_ID.Text, User_ID.Text, Table_Type.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                     Table_Status.Text, 0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                MainWindow.sql.InsertNonQuery(qry);

                MessageBox.Show("Table Added Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Close();
            }
            else
            {
                MessageBox.Show("Table " + Table_ID.Text + " Already Exist in DB.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
