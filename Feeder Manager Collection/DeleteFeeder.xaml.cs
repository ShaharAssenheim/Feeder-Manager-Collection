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
    public partial class DeleteFeeder : Window
    {
        public DeleteFeeder(Feeder row)
        {
            InitializeComponent();
            Feeder_ID.Text = row.FeederID;
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

            if (MainWindow.FeederMalList.Any(x => x.FeederId == Feeder_ID.Text && x.FeederStatus == "Malfunction Opened"))
            {
                MessageBox.Show("There Is Opened Malfunctions For This Feeder, Close Them Before Deletion.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"DELETE FROM Feeders WHERE FeederId='{0}'", Feeder_ID.Text);
            MainWindow.sql.Delete(qry);
            qry = string.Format(@"DELETE FROM FeederMalfunctions WHERE FeederId='{0}'", Feeder_ID.Text);
            MainWindow.sql.Delete(qry);
            MessageBox.Show("Feeder Delete Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Close();
        }
    }
}
