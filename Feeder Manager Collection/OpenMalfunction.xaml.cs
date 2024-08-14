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
    public partial class OpenMalfunction : Window
    {
        List<string> MalType = new List<string>() {"תקלה כללית", "STEP פידר מאבד", "מנהרת סרט סתומה", "ויברטור לא מתכוון) עוצמה)", "מסילת סרט פגומה", "סרגל עקום",
                                                  "השמת רכיבים על הצד", "לא יציב) פידר רוטט)", "אין פקודת הפעלה לפידר ממכונה", "סרט רוטט / פידר קורע ניילון", "Type Spring / מכסה אחורי",
                                                  "תיקון גוף", "Pickup Position", "מנוע קדמי לא תקין ", "פידר קורע ניילון", "סוגר קפיץ / קפיץ קדמי פגום", "מנוע אחורי לא תקין",
                                                  "אין פקודה ממכונה / פידר לא מגיב כלל", "פידר לא מגיב כלל", "פידר מפזר רכיבים", "פידר לא יציב, רוטט ", "מנוע אחורי לא תקין / לא מושך ניילון",
                                                  "לא מכויל", "מנוע קדמי לא תקין / לא מושך סרט", "השמתת רכיבים/פידר מפזר רכיבים", "ויברטור לא מגיב כלל "};
        public OpenMalfunction()
        {
            InitializeComponent();
            Mal_Type.ItemsSource = MalType;
            OperatorID.Text = MainWindow.ActiveUser.UserID;
        }

        private void SearchFeeder_Click(object sender, RoutedEventArgs e)
        {
            if (Feeder_ID.Text == "")
            {
                MessageBox.Show("Fill Feeder ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!MainWindow.FeederList.Any(x => x.FeederID.ToLower() == Feeder_ID.Text.ToLower()))
            {
                MessageBox.Show("Feeder Not Exist In DB", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MainWindow.FeederMalList.Any(x => x.FeederId.ToLower() == Feeder_ID.Text.ToLower() && x.FeederStatus == "Malfunction Opened"))
            {
                MessageBox.Show("There Is Opened Malfunctions For This Feeder.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MainWindow.FeederMalList.Any(x => x.FeederId.ToLower() == Feeder_ID.Text.ToLower() && x.FeederStatus == "In Storage"))
            {
                MessageBox.Show("This Feeder Is In Storage", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Feeder fed = MainWindow.FeederList.FirstOrDefault(x => x.FeederID.ToLower() == Feeder_ID.Text.ToLower());
            Feeder_Type.Text = fed.FeederType;
            Fedder_Status.Text = fed.FeederStatus;
            Calibration_Date.Text = fed.CalibrationDateExpired;
            MalCount.Text = fed.MalfunctionCount.ToString();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Feeder_Type.Text == "")
            {
                MessageBox.Show("Search Feeder ID First", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (OperatorID.Text == "" || Mal_Type.Text == "")
            {
                MessageBox.Show("Fill Operator ID And Malfunction Type", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"INSERT INTO FeederMalfunctions (FeederId, UserId, FeederType, FeederStatus, CalibrationDateExpired, MalfunctionCount, MalfunctionType, MalfunctionDateOpened) 
                                    VALUES('{0}','{1}','{2}','{3}','{4}','{5}',N'{6}','{7}')",
                                      Feeder_ID.Text, OperatorID.Text, Feeder_Type.Text, "Malfunction Opened", Convert.ToDateTime(Calibration_Date.Text).ToString("yyyy-MM-dd HH:mm:ss"),
                                      Convert.ToInt32(MalCount.Text) + 1, Mal_Type.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            MainWindow.sql.InsertNonQuery(qry);

            qry = string.Format(@"UPDATE FEEDERS SET FeederStatus='Malfunction Opened', MalfunctionCount='{0}' WHERE FeederId='{1}'", Convert.ToInt32(MalCount.Text) + 1, Feeder_ID.Text);
            MainWindow.sql.InsertNonQuery(qry);

            MessageBox.Show("Mulafunction Added Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Close();
        }
    }
}
