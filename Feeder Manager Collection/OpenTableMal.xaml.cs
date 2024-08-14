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
    public partial class OpenTableMal : Window
    {
        List<string> MalType = new List<string>() { "אין תקשורת במיקום", "אין תקשורת בין שולחן למכונה", "ידית שבורה", "צינור אוויר פגום", "חיבור מהיר של לחץ אוויר חסר או פגום",
                                                    "מחבר תקשורת שבור", "גלגל השולחן חסר או פגום", "גובה השולחן לא משתנה", "פידרים לא יציבים", "גובה השולחן לא מתאים" };
        public OpenTableMal()
        {
            InitializeComponent();
            Mal_Type.ItemsSource = MalType;
            OperatorID.Text = MainWindow.ActiveUser.UserID;
        }

        private void SearchTable_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("There Is Opened Malfunctions For This Table.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Table tab = MainWindow.TableList.FirstOrDefault(x => x.TableID == Table_ID.Text);
            Table_Type.Text = tab.TableType;
            Table_Status.Text = tab.TableStatus;
            MalCount.Text = tab.MalfunctionCount.ToString();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Table_Type.Text == "")
            {
                MessageBox.Show("Search Table ID First", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (OperatorID.Text == "" || Mal_Type.Text == "")
            {
                MessageBox.Show("Fill Operator ID And Malfunction Type", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string qry = string.Format(@"INSERT INTO TableMalfunctions (TableID, UserId, TableType, TableStatus, MalfunctionCount, MalfunctionType, MalfunctionDateOpened) 
                                    VALUES('{0}','{1}','{2}','{3}','{4}',N'{5}','{6}')",
                                      Table_ID.Text, OperatorID.Text, Table_Type.Text, "Malfunction Opened",
                                      Convert.ToInt32(MalCount.Text) + 1, Mal_Type.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            MainWindow.sql.InsertNonQuery(qry);

            qry = string.Format(@"UPDATE Tables SET TableStatus='Malfunction Opened', MalfunctionCount='{0}' WHERE TableId='{1}'", Convert.ToInt32(MalCount.Text) + 1, Table_ID.Text);
            MainWindow.sql.InsertNonQuery(qry);

            MessageBox.Show("Mulafunction Added Successfully", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Close();
        }
    }
}
