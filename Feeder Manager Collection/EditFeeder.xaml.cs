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
    public partial class EditFeeder : Window
    {
        string RowID = "";
        public EditFeeder(Feeder Fed)
        {
            InitializeComponent();
            RowID = Fed.ID.ToString();
            Feeder_ID.Text = Fed.FeederID;
            Feeder_Type.Text = Fed.FeederType;
            if (Fed.FeederSensor != "")
                Feeder_Sensor.SelectedIndex = Fed.FeederSensor == "Yes" ? 0 : 1;
            Calibration_Date.Text = Fed.CalibrationDateExpired;
            Fedder_Status.Text = Fed.FeederStatus;
            User_ID.Text = MainWindow.ActiveUser.UserID;
            FocusManager.SetFocusedElement(this, Feeder_ID);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Feeder_ID.Text == "" || User_ID.Text == "" || Feeder_Type.Text == "")
            {
                MessageBox.Show("Fill All Fileds", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"UPDATE Feeders 
                                             SET FeederID='{0}', UserID='{1}', FeederType='{2}', FeederStatus='{3}', FeederSensor='{4}' 
                                             WHERE ID='{5}'",
                                 Feeder_ID.Text, User_ID.Text, Feeder_Type.Text.Replace(" ", string.Empty), Fedder_Status.Text, Feeder_Sensor.Text, RowID);
            MainWindow.sql.InsertNonQuery(qry);

            MessageBox.Show("Feeder Added Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            TemporeryFunc();
            Close();
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
