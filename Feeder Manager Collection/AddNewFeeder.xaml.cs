using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AddNewFeeder : Window
    {
        public AddNewFeeder()
        {
            InitializeComponent();
            GetFedderTypes();
            Calibration_Date.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy HH:mm");
            Fedder_Status.Text = "In Work";
            User_ID.Text = MainWindow.ActiveUser.UserID;
            FocusManager.SetFocusedElement(this, Feeder_ID);
        }
        
        private void GetFedderTypes()
        {
            string qry = string.Format(@"SELECT DISTINCT FeederType FROM Feeders");
            DataTable dt = MainWindow.sql.SelectDb(qry);
            Feeder_Type.ItemsSource= dt.AsEnumerable().Select(r => r.Field<string>("FeederType")).ToList().OrderByDescending(x=>x);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Feeder_ID.Text == "" || User_ID.Text == "" || Feeder_Type.Text == "")
            {
                MessageBox.Show("Fill All Fileds", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (!MainWindow.FeederList.Any(x => x.FeederID.ToLower() == Feeder_ID.Text.ToLower()))
            {
                string qry = string.Format(@"INSERT INTO Feeders (FeederID, UserID, FeederType, CreationDate , FeederStatus, CalibrationDate, MalfunctionCount, LastTimeChecked, FeederSensor) 
                                    VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                     Feeder_ID.Text, User_ID.Text, Feeder_Type.Text.Replace(" ",string.Empty), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                     Fedder_Status.Text, DateTime.Now.AddYears(1).ToString("yyyy-MM-dd HH:mm:ss"), 0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Feeder_Sensor.Text);
                MainWindow.sql.InsertNonQuery(qry);

                MessageBox.Show("Feeder Added Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                TemporeryFunc();
                //Close();
            }
            else
            {
                MessageBox.Show("Feeder " + Feeder_ID.Text + " Already Exist in DB.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                Feeder_ID.Text = "";
                Feeder_Type.Text = "";
                FocusManager.SetFocusedElement(this, Feeder_ID);
                return;
            }
        }

        private void Feeder_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Feeder_ID.Text.Contains("-"))
            {
                Feeder_Type.Text = Feeder_ID.Text.Substring(0, Feeder_ID.Text.IndexOf("-"));
               // OKBtn.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        private void TemporeryFunc()
        {
            string qry = string.Format(@"SELECT * FROM Feeders order by CalibrationDate ASC");
            MainWindow.FeederList = MainWindow.sql.SelectFeeders(qry);
            MainWindow.mn.FeederDG.ItemsSource = MainWindow.FeederList;
            MainWindow.mn.FeederListHeader.Content = "Feeders List (" + MainWindow.FeederList.Count + ")";
            Feeder_ID.Text = "";
            Feeder_Type.Text = "";
        }
    }
}
