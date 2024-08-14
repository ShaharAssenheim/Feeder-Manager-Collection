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
    public partial class CalibrateFeeder : Window
    {
        public CalibrateFeeder(string Feeder)
        {
            InitializeComponent();
            Feeder_ID.Text = Feeder;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Feeder_ID.Text == "")
            {
                MessageBox.Show("Fill Feeder ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!MainWindow.FeederList.Any(x => x.FeederID == Feeder_ID.Text))
            {
                MessageBox.Show("Feeder Not Exist In DB", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"UPDATE Feeders SET CalibrationDate='{0}', LastTimeChecked='{0}' WHERE FeederId='{1}'", DateTime.Now.AddYears(1).ToString("yyyy-MM-dd HH:mm:ss"), Feeder_ID.Text);
            MainWindow.sql.Delete(qry);
            qry = string.Format(@"UPDATE FeederMalfunctions SET CalibrationDateExpired='{0}' WHERE FeederId='{1}'", DateTime.Now.AddYears(1).ToString("yyyy-MM-dd HH:mm:ss"), Feeder_ID.Text);
            MainWindow.sql.Delete(qry);
            MessageBox.Show("Feeder Calibrated Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            DialogResult = true;
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
