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
    public partial class DeleteTable : Window
    {
        public DeleteTable(Table row)
        {
            InitializeComponent();
            Table_ID.Text = row.TableID;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Table_ID.Text == "")
            {
                MessageBox.Show("Fill Table ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!MainWindow.TableList.Any(x => x.TableID == Table_ID.Text))
            {
                MessageBox.Show("Table Not Exist In DB", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MainWindow.TableMalList.Any(x => x.TableId == Table_ID.Text && x.TableStatus == "Malfunction Opened"))
            {
                MessageBox.Show("There Is Opened Malfunctions For This Table, Close Them Before Deletion.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"DELETE FROM Tables WHERE TableId='{0}'", Table_ID.Text);
            MainWindow.sql.Delete(qry);
            qry = string.Format(@"DELETE FROM TableMalfunctions WHERE TableID='{0}'", Table_ID.Text);
            MainWindow.sql.Delete(qry);
            MessageBox.Show("Table Deleted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Close();
        }
    }
}
