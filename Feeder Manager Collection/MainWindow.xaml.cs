using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Feeder_Manager
{
    public partial class MainWindow : Window
    {
        public static User ActiveUser = new User();
        public static SQLClass sql = new SQLClass("MIGSQLCLU4\\SMT", "FeederManager", "aoi", "$Flex2016");
        public static SQLClass sqlSiplace = new SQLClass("172.20.20.2", "SiplacePro", "ez", "$Flex2016");
        public static MainWindow mn;
        string ScreenMode = "";
        public static List<Feeder> FeederList = new List<Feeder>();
        public static List<FeederMalfunction> FeederMalList = new List<FeederMalfunction>();
        public static List<Table> TableList = new List<Table>();
        public static List<TableMalfunction> TableMalList = new List<TableMalfunction>();
        public static List<Segment> SegmentList = new List<Segment>();
        string[] StatusList = new string[] { "In Work", "Malfunction Opened", "In Storage" };

        public MainWindow()
        {
            InitializeComponent();
            mn = this;
            Login("FirstLogin");
            FeederStatus_txt.ItemsSource = StatusList;
        }

        private void Login(string Type)
        {
            BigLogo.Visibility = Visibility.Visible;
            FeederHeader.Visibility = Visibility.Hidden;
            TableHeader.Visibility = Visibility.Hidden;
            GridBoxFeeder.Visibility = Visibility.Hidden;
            GridBoxTable.Visibility = Visibility.Hidden;

            LogIn log = new LogIn(Type);
            if (log.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();

                if (ActiveUser.Role.ToLower() == "maintenance")
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/maintanance.png", UriKind.Absolute);
                else if (ActiveUser.Role.ToLower() == "setup")
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/setup.png", UriKind.Absolute);
                else if (ActiveUser.Role.ToLower() == "admin")
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/admin.png", UriKind.Absolute);

                bitmap.EndInit();
                ImageBrush i = new ImageBrush();
                i.ImageSource = bitmap;
                ProfileS.Background = i;
                ProfileL.Background = i;
            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ProfileS.Visibility = Visibility.Hidden;
            ProfileL.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ProfileL.Visibility = Visibility.Hidden;
            ProfileS.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedItem == null) return;


            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemFeeder":
                    ScreenMode = "Feeder";
                    SetVisbillty();
                    SetFeeder();
                    break;
                case "ItemTable":
                    ScreenMode = "Table";
                    SetVisbillty();
                    SetTable();
                    break;
                case "ItemSegment":
                    ScreenMode = "Segment";
                    SetVisbillty();
                    SetSegment();
                    break;
                case "ItemExport":
                    Export Exp = new Export();
                    Exp.ShowDialog();
                    break;
                case "ItemStatistics":
                    SetFeeder();
                    SetTable();
                    Statistics Stat = new Statistics();
                    Stat.Owner = this;
                    Stat.Show();
                    ItemStatistics.IsEnabled = false;
                    break;
                case "ItemUsers":
                    if (ActiveUser.Role == "Admin")
                    {
                        Users U = new Users();
                        U.ShowDialog();
                    }
                    else
                        MessageBox.Show("You Are Not An Admin", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case "ItemAbout":
                    About A = new About();
                    A.ShowDialog();
                    break;
                case "ItemExit":
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
            ListViewMenu.SelectedItem = null;
        }

        private void SetVisbillty()
        {
            CleanFeeder();
            if (ActiveUser.Role.ToLower() == "maintenance" && ScreenMode == "Feeder")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Visible;
                TableHeader.Visibility = Visibility.Hidden;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Visible;
                GridBoxTable.Visibility = Visibility.Hidden;
                ShowAllMal.Background = Brushes.LightBlue;
                GridBoxSegment.Visibility = Visibility.Hidden;
                AddNewFeeder.IsEnabled = false;
                CloseMal.IsEnabled = false;
                DelMal.IsEnabled = false;
                ClosedMalCheck.IsChecked = true;
                OpenMalCheck.IsChecked = true;
            }
            else if (ActiveUser.Role.ToLower() == "setup" && ScreenMode == "Feeder")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Visible;
                TableHeader.Visibility = Visibility.Hidden;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Visible;
                GridBoxTable.Visibility = Visibility.Hidden;
                MalDateGrid.Visibility = Visibility.Hidden;
                MalTypeGrid.Visibility = Visibility.Hidden;
                ShowAllMal.Background = Brushes.LightBlue;
                GridBoxSegment.Visibility = Visibility.Hidden;
                AddNewFeeder.IsEnabled = false;
                CloseMal.IsEnabled = false;
                DelMal.IsEnabled = false;
                ClosedMalCheck.IsChecked = true;
                OpenMalCheck.IsChecked = true;
            }
            else if (ActiveUser.Role.ToLower() == "admin" && ScreenMode == "Feeder")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Visible;
                TableHeader.Visibility = Visibility.Hidden;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Visible;
                GridBoxTable.Visibility = Visibility.Hidden;
                MalDateGrid.Visibility = Visibility.Visible;
                MalTypeGrid.Visibility = Visibility.Visible;
                ShowAllMal.Background = Brushes.LightBlue;
                GridBoxSegment.Visibility = Visibility.Hidden;
                AddNewFeeder.IsEnabled = true;
                CloseMal.IsEnabled = false;
                DelMal.IsEnabled = false;
                ClosedMalCheck.IsChecked = true;
                OpenMalCheck.IsChecked = true;
            }
            else if (ActiveUser.Role.ToLower() == "maintenance" && ScreenMode == "Table")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Hidden;
                TableHeader.Visibility = Visibility.Visible;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Hidden;
                GridBoxTable.Visibility = Visibility.Visible;
                GridBoxSegment.Visibility = Visibility.Hidden;
                TableClosedMalCheck.IsChecked = true;
                TableOpenMalCheck.IsChecked = true;
                AddNewTable.IsEnabled = false;
                TableCloseMal.IsEnabled = false;
                TableDelMal.IsEnabled = false;
            }
            else if (ActiveUser.Role.ToLower() == "setup" && ScreenMode == "Table")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Hidden;
                TableHeader.Visibility = Visibility.Visible;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Hidden;
                GridBoxTable.Visibility = Visibility.Visible;
                GridBoxSegment.Visibility = Visibility.Hidden;
                TableClosedMalCheck.IsChecked = true;
                TableOpenMalCheck.IsChecked = true;
                TableClosedMalCheck.IsChecked = true;
                AddNewTable.IsEnabled = false;
                TableCloseMal.IsEnabled = false;
                TableDelMal.IsEnabled = false;
            }
            else if (ActiveUser.Role.ToLower() == "admin" && ScreenMode == "Table")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Hidden;
                TableHeader.Visibility = Visibility.Visible;
                SegmentHeader.Visibility = Visibility.Hidden;
                GridBoxFeeder.Visibility = Visibility.Hidden;
                GridBoxTable.Visibility = Visibility.Visible;
                GridBoxSegment.Visibility = Visibility.Hidden;
                TableClosedMalCheck.IsChecked = true;
                TableOpenMalCheck.IsChecked = true;
                AddNewTable.IsEnabled = true;
                TableCloseMal.IsEnabled = false;
                TableDelMal.IsEnabled = false;
            }
            else if (ScreenMode == "Segment")
            {
                BigLogo.Visibility = Visibility.Hidden;
                FeederHeader.Visibility = Visibility.Hidden;
                TableHeader.Visibility = Visibility.Hidden;
                SegmentHeader.Visibility = Visibility.Visible;
                GridBoxFeeder.Visibility = Visibility.Hidden;
                GridBoxTable.Visibility = Visibility.Hidden;
                GridBoxSegment.Visibility = Visibility.Visible;
            }
        }

        private void CleanFeeder()
        {
            FeederID_txt.Text = "";
            UserId_txt.Text = "";
            FeederType_txt.Text = "";
            FeederStatus_txt.Text = "";
            CalibrationExp_txt.Text = "";
            MalCount_Txt.Text = "";
            MalDate_txt.Text = "";
            MalType_txt.Text = "";
            TechId_txt.Text = "";
            Result_txt.Text = "";
            CloseMal.IsEnabled = false;
            DelMal.IsEnabled = false;
            ChangeMalBtn.IsEnabled = false;
            CalibrateCheckBox.Visibility = Visibility.Collapsed;
        }

        public void CleanTable()
        {
            TableID_txt.Text = "";
            TableUserId_txt.Text = "";
            TableType_txt.Text = "";
            TableStatus_txt.Text = "";
            TableMalCount_Txt.Text = "";
            TableMalDateOpen_txt.Text = "";
            TableMalDateClose_txt.Text = "";
            TableMalType_txt.Text = "";
            TableTechId_txt.Text = "";
            TableResult_txt.Text = "";
            TableCloseMal.IsEnabled = false;
            TableDelMal.IsEnabled = false;
        }

        private void SetFeeder()
        {
            string qry = string.Format(@"SELECT * FROM FeederMalfunctions order by MalfunctionDateOpened DESC");
            FeederMalList = sql.SelectFeederMalfunction(qry);
            MalfunctionDG.ItemsSource = FeederMalList;
            MalFeederHeader.Content = "Feeder Malfunctions List (" + FeederMalList.Count + ")";

            qry = string.Format(@"SELECT * FROM Feeders order by CalibrationDate ASC");
            FeederList = sql.SelectFeeders(qry);
            FeederDG.ItemsSource = FeederList;
            FeederListHeader.Content = "Feeders List (" + FeederList.Count + ")";
        }

        private void SetTable()
        {
            string qry = string.Format(@"SELECT * FROM Tables order by LastTimeChecked ASC");
            TableList = sql.SelectTables(qry);
            TableDG.ItemsSource = TableList;
            TablesListHeader.Content = "Table List (" + TableList.Count + ")";

            qry = string.Format(@"SELECT * FROM TableMalfunctions order by MalfunctionDateOpened DESC");
            TableMalList = sql.SelectTableMalfunction(qry);
            TableMalfunctionDG.ItemsSource = TableMalList;
            TableMalHeader.Content = "Table Malfunctions List (" + TableMalList.Count + ")";
        }

        private void SetSegment()
        {

            string qry = string.Format(@"SELECT DISTINCT 
                             dbo.CSegment.ORD AS SegmentNumber, dbo.CSegment.nSegmentInfo AS OmitSegment, AliasName_1.ObjectName AS Line, AliasName_2.ObjectName AS Station, dbo.AliasName.ObjectName AS SetupName,
                             CFolder_1.bstrDisplayName AS Expr1, CFolder_1.spParentFolderRef
                             FROM dbo.CSegment INNER JOIN
                             dbo.CAttachableHead ON dbo.CSegment.PID = dbo.CAttachableHead.OID INNER JOIN
                             dbo.CStationLocation ON dbo.CAttachableHead.PID = dbo.CStationLocation.OID INNER JOIN
                             dbo.CStationSetup ON dbo.CStationLocation.PID = dbo.CStationSetup.OID INNER JOIN
                             dbo.CSetup ON dbo.CStationSetup.PID = dbo.CSetup.OID INNER JOIN
                             dbo.AliasName ON dbo.CSetup.OID = dbo.AliasName.PID INNER JOIN
                             dbo.AliasName AS AliasName_1 ON dbo.CSetup.spLineRef = AliasName_1.PID INNER JOIN
                             dbo.CStationInLine ON dbo.CStationSetup.CStationSetupCollection_long = dbo.CStationInLine.OID INNER JOIN
                             dbo.AliasName AS AliasName_2 ON dbo.CStationInLine.spStationRef = AliasName_2.PID INNER JOIN
                             dbo.CFolder AS CFolder_1 ON dbo.AliasName.FolderID = CFolder_1.OID
                             WHERE (dbo.CSegment.nSegmentInfo = 1) AND (dbo.AliasName.ObjectName LIKE N'%EMPTY%') AND (CFolder_1.spParentFolderRef = 40076)
                             ORDER BY Line");
            SegmentList = sqlSiplace.SelectSegment(qry).OrderBy(x => x.Line).ThenBy(x => x.Station).ThenBy(x => x.SegmentNumber).ToList();
            SegmentMalfunctionDG.ItemsSource = SegmentList;
            SegmentMalHeader.Content = "Segment Malfunctions List (" + SegmentList.Count + ")";
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login("ChangeLogin");
        }

        private void AddNewFeeder_Click(object sender, RoutedEventArgs e)
        {
            AddNewFeeder Add = new AddNewFeeder();
            Add.ShowDialog();
            SetFeeder();
            CleanFeeder();
        }

        private void DelFeeder_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveUser.Role.ToLower() == "admin" && ScreenMode == "Feeder")
            {
                Feeder row = (Feeder)FeederDG.SelectedCells[0].Item;
                if (row != null)
                {
                    DeleteFeeder Del = new DeleteFeeder(row);
                    Del.ShowDialog();
                    SetFeeder();
                }
            }
            else
            {
                MessageBox.Show("Only Admin Allowd To Delete Feeders", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void EditFeeder_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveUser.Role.ToLower() == "admin" && ScreenMode == "Feeder")
            {
                Feeder row = (Feeder)FeederDG.SelectedCells[0].Item;
                if (row != null)
                {
                    EditFeeder Edit = new EditFeeder(row);
                    Edit.ShowDialog();
                    SetFeeder();
                }
            }
            else
            {
                MessageBox.Show("Only Admin Allowd To Delete Feeders", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void CloseMal_Click(object sender, RoutedEventArgs e)
        {
            if (TechId_txt.Text == "" || Result_txt.Text == "")
            {
                MessageBox.Show("Fill Technician ID And Result", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string qry = string.Format(@"UPDATE FeederMalfunctions 
                                       SET MalfunctionDateClosed='{0}', MalfunctionResult=N'{1}', TechnicianId='{2}', FeederStatus='In Work'
                                       WHERE FeederId='{3}' AND MalfunctionCount='{4}'",
                                       DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Result_txt.Text, TechId_txt.Text, FeederID_txt.Text, MalCount_Txt.Text);
            sql.Update(qry);

            qry = string.Format(@"UPDATE FEEDERS SET FeederStatus='In Work' WHERE FeederId='{0}'", FeederID_txt.Text);
            sql.Update(qry);

            MessageBox.Show("Mulfunction Closed Successfully!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            SetFeeder();
        }

        private void DelMal_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                string qry = string.Format(@"DELETE FROM FeederMalfunctions WHERE FeederId='{0}' AND MalfunctionCount='{1}'", FeederID_txt.Text, MalCount_Txt.Text);
                sql.Delete(qry);

                qry = string.Format(@"BEGIN
                                       IF NOT EXISTS (SELECT * FROM FeederMalfunctions WHERE FeederId='{0}' AND MalfunctionDateClosed IS NULL)
                                       BEGIN
                                           UPDATE Feeders SET FeederStatus='In Work' WHERE FeederID='{0}'
                                       END
                                    END", FeederID_txt.Text);
                sql.Update(qry);

                MessageBox.Show("Mulfunction Deleted Successfully!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                SetFeeder();
                CleanFeeder();
            }
        }

        private void SearchFeeder_Click(object sender, RoutedEventArgs e)
        {
            if (FeederID_txt.Text == "")
            {
                MessageBox.Show("Fill Feeder ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MalfunctionSP.Visibility == Visibility.Visible)
            {
                List<FeederMalfunction> list = FeederMalList.Where(x => x.FeederId.ToLower().Contains(FeederID_txt.Text.ToLower())).ToList();
                MalfunctionDG.ItemsSource = list;
                MalFeederHeader.Content = "Feeder Malfunctions List (" + list.Count + ")";
                MalfunctionSP.Visibility = Visibility.Visible;
                FeederSP.Visibility = Visibility.Hidden;
                int n = list.Count(X => Convert.ToDateTime(X.MalfunctionDateOpened) > DateTime.Now.AddMonths(-1));
                if (n >= 3)
                    MessageBox.Show("Unreliable Feeder!!!\nOver Then 3 Mulfunctions In The Last Month", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (FeederSP.Visibility == Visibility.Visible)
            {
                List<Feeder> list2 = FeederList.Where(x => x.FeederID.ToLower().Contains(FeederID_txt.Text.ToLower())).ToList();
                if (list2.Count == 0)//if there is no feeders
                {
                    MessageBox.Show("Feeder Not Exist In DB!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FeederDG.ItemsSource = null;
                    FeederListHeader.Content = "Feeders List (0)";
                    return;
                }
                else
                {
                    FeederDG.ItemsSource = list2;
                    FeederListHeader.Content = "Feeders List (" + list2.Count + ")";
                    MalfunctionSP.Visibility = Visibility.Hidden;
                    FeederSP.Visibility = Visibility.Visible;
                    MessageBox.Show("There Are No Malfunctions For This Feeder", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void OpenMal_Click(object sender, RoutedEventArgs e)
        {
            OpenMalfunction O = new OpenMalfunction();
            O.ShowDialog();
            SetFeeder();
            CleanFeeder();
        }

        private void ShowAllMal_Click(object sender, RoutedEventArgs e)
        {
            MalfunctionSP.Visibility = Visibility.Visible;
            FeederSP.Visibility = Visibility.Hidden;
            ShowAllFeeders.Background = Brushes.LightGray;
            ShowAllMal.Background = Brushes.LightBlue;
            ShowChecklist.Background = Brushes.LightGray;
            OpenMalCheck.IsChecked = true;
            ClosedMalCheck.IsChecked = true;
            CleanFeeder();
            SetFeeder();
        }

        private void ShowChecklist_Click(object sender, RoutedEventArgs e)
        {
            ShowAllFeeders.Background = Brushes.LightGray;
            ShowAllMal.Background = Brushes.LightGray;
            ShowChecklist.Background = Brushes.LightBlue;
        }

        private void ShowAllFeeders_Click(object sender, RoutedEventArgs e)
        {
            MalfunctionSP.Visibility = Visibility.Hidden;
            FeederSP.Visibility = Visibility.Visible;
            ShowAllFeeders.Background = Brushes.LightBlue;
            ShowAllMal.Background = Brushes.LightGray;
            ShowChecklist.Background = Brushes.LightGray;
            InWorkFeederCheck.IsChecked = true;
            OpenMalFeederCheck.IsChecked = true;
            CleanFeeder();
            SetFeeder();
        }

        private void MalfunctionDG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FeederMalfunction row = (FeederMalfunction)MalfunctionDG.SelectedItem;
            if (row != null)
            {
                FeederID_txt.Text = row.FeederId;
                UserId_txt.Text = row.UserId.ToString();
                FeederType_txt.Text = row.FeederType;
                FeederStatus_txt.SelectedIndex = Array.IndexOf(StatusList, row.FeederStatus);
                CalibrationExp_txt.Text = row.CalibrationDateExpired;
                if (Convert.ToDateTime(row.CalibrationDateExpired) <= DateTime.Now)
                {
                    CalibrationExp_txt.Background = Brushes.Salmon;
                    MessageBox.Show("Feeder Needs Calibration", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                    CalibrationExp_txt.Background = Brushes.White;
                MalCount_Txt.Text = row.MalfunctionCount.ToString();
                MalDate_txt.Text = row.MalfunctionDateOpened;
                MalType_txt.Text = row.MalfunctionType;
                TechId_txt.Text = row.TechnicianId;
                Result_txt.Text = row.MalfunctionResult;
                if (row.MalfunctionDateClosed == "" && ActiveUser.Role.ToLower() != "setup")
                {
                    CloseMal.IsEnabled = true;
                    CalibrateCheckBox.Visibility = Visibility.Visible;
                    CalibrateCheckBox.IsChecked = false;
                    ChangeMalBtn.IsEnabled = true;
                }
                else
                {
                    CloseMal.IsEnabled = false;
                    ChangeMalBtn.IsEnabled = false;
                }


                if (ActiveUser.Role.ToLower() != "setup")
                    DelMal.IsEnabled = true;
            }
        }

        private void FeederDG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Feeder row = (Feeder)FeederDG.SelectedItem;
            if (row != null)
            {
                FeederID_txt.Text = row.FeederID;
                UserId_txt.Text = row.UserID;
                FeederType_txt.Text = row.FeederType;
                FeederStatus_txt.SelectedIndex = Array.IndexOf(StatusList, row.FeederStatus);
                CalibrationExp_txt.Text = row.CalibrationDateExpired;
                CalibrationExp_txt.Text = row.CalibrationDateExpired;
                if (Convert.ToDateTime(row.CalibrationDateExpired) <= DateTime.Now)
                {
                    CalibrationExp_txt.Background = Brushes.Salmon;
                    MessageBox.Show("Feeder Needs Calibration", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                    CalibrationExp_txt.Background = Brushes.White;
                MalCount_Txt.Text = row.MalfunctionCount.ToString();
                MalDate_txt.Text = "";
                MalType_txt.Text = "";
                TechId_txt.Text = "";
                Result_txt.Text = "";
            }
        }

        private void ClosedMalCheck_Checked(object sender, RoutedEventArgs e)
        {
            List<FeederMalfunction> list;
            if (OpenMalCheck.IsChecked == true)
                list = FeederMalList;
            else
                list = FeederMalList.Where(x => x.MalfunctionDateClosed != "").ToList();

            MalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            MalFeederHeader.Content = "Feeder Malfunctions List (" + n + ")";
            CleanFeeder();
        }

        private void ClosedMalCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            List<FeederMalfunction> list;
            if (OpenMalCheck.IsChecked == true)
                list = FeederMalList.Where(x => x.MalfunctionDateClosed == "").ToList();
            else
                list = null;

            MalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            MalFeederHeader.Content = "Feeder Malfunctions List (" + n + ")";
            CleanFeeder();
        }

        private void OpenMalCheck_Checked(object sender, RoutedEventArgs e)
        {
            List<FeederMalfunction> list;
            if (ClosedMalCheck.IsChecked == true)
                list = FeederMalList;
            else
                list = FeederMalList.Where(x => x.MalfunctionDateClosed == "").ToList();

            MalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            MalFeederHeader.Content = "Feeder Malfunctions List (" + n + ")";
            CleanFeeder();
        }

        private void OpenMalCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            List<FeederMalfunction> list;
            if (ClosedMalCheck.IsChecked == true)
                list = FeederMalList.Where(x => x.MalfunctionDateClosed != "").ToList();
            else
                list = null;

            MalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            MalFeederHeader.Content = "Feeder Malfunctions List (" + n + ")";
            CleanFeeder();
        }

        private void InWorkFeeder_Checked(object sender, RoutedEventArgs e)
        {
            List<Feeder> list;
            if (OpenMalFeederCheck.IsChecked == true)
                list = FeederList;
            else
                list = FeederList.Where(x => x.FeederStatus == "In Work").ToList();

            FeederDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            FeederListHeader.Content = "Feeders List (" + n + ")";
            CleanFeeder();
        }

        private void InWorkFeeder_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Feeder> list;
            if (OpenMalFeederCheck.IsChecked == true)
                list = FeederList.Where(x => x.FeederStatus == "Malfunction Opened").ToList();
            else
                list = null;

            FeederDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            FeederListHeader.Content = "Feeders List (" + n + ")";
            CleanFeeder();
        }

        private void OpenMalFeeder_Checked(object sender, RoutedEventArgs e)
        {
            List<Feeder> list;
            if (InWorkFeederCheck.IsChecked == true)
                list = FeederList;
            else
                list = FeederList.Where(x => x.FeederStatus == "Malfunction Opened").ToList();

            FeederDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            FeederListHeader.Content = "Feeders List (" + n + ")";
            CleanFeeder();
        }

        private void OpenMalFeeder_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Feeder> list;
            if (InWorkFeederCheck.IsChecked == true)
                list = FeederList.Where(x => x.FeederStatus == "In Work").ToList();
            else
                list = null;

            FeederDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            FeederListHeader.Content = "Feeders List (" + n + ")";
            CleanFeeder();
        }

        private void AddNewTable_Click(object sender, RoutedEventArgs e)
        {
            AddNewTable Add = new AddNewTable();
            Add.ShowDialog();
            SetTable();
        }

        private void ShowAllTables_Click(object sender, RoutedEventArgs e)
        {
            TableSP.Visibility = Visibility.Visible;
            TableMalfunctionSP.Visibility = Visibility.Hidden;
            TableInWorkCheck.IsChecked = true;
            TableOpenCheck.IsChecked = true;
            CleanTable();
            SetTable();

        }

        private void DelTable_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveUser.Role.ToLower() == "admin" && ScreenMode == "Table")
            {
                Table row = (Table)TableDG.SelectedCells[0].Item;
                if (row != null)
                {
                    DeleteTable Del = new DeleteTable(row);
                    Del.ShowDialog();
                    SetTable();
                }
            }
            else
            {
                MessageBox.Show("Only Admin Allowd To Delete Tables", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void ShowAllTableMal_Click(object sender, RoutedEventArgs e)
        {
            TableSP.Visibility = Visibility.Hidden;
            TableMalfunctionSP.Visibility = Visibility.Visible;
            TableClosedMalCheck.IsChecked = true;
            TableOpenMalCheck.IsChecked = true;
            CleanTable();
            SetTable();
        }

        private void SearchTable_Click(object sender, RoutedEventArgs e)
        {
            if (TableID_txt.Text == "")
            {
                MessageBox.Show("Fill Table ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<TableMalfunction> list = TableMalList.Where(x => x.TableId == TableID_txt.Text).ToList();
            if (list.Count == 0)//if there is no malfunctions
            {
                List<Table> list2 = TableList.Where(x => x.TableID == TableID_txt.Text).ToList();
                if (list2.Count == 0)//if there is no tables
                {
                    MessageBox.Show("Table Not Exist In DB!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TableDG.ItemsSource = null;
                    TablesListHeader.Content = "Table List (0)";
                    return;
                }
                else
                {
                    TableDG.ItemsSource = list2;
                    TablesListHeader.Content = "Table List (" + list2.Count + ")";
                    TableMalfunctionSP.Visibility = Visibility.Hidden;
                    TableSP.Visibility = Visibility.Visible;
                    MessageBox.Show("There Are No Malfunctions For This Table", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                TableMalfunctionDG.ItemsSource = list;
                TableMalHeader.Content = "Table Malfunctions List (" + list.Count + ")";
                TableMalfunctionSP.Visibility = Visibility.Visible;
                TableSP.Visibility = Visibility.Hidden;
            }
        }

        private void MalfunctionTableDG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TableMalfunction row = (TableMalfunction)TableMalfunctionDG.SelectedItem;
            if (row != null)
            {
                TableID_txt.Text = row.TableId;
                TableUserId_txt.Text = row.UserId;
                TableType_txt.Text = row.TableType;
                TableStatus_txt.Text = row.TableStatus;
                TableMalCount_Txt.Text = row.MalfunctionCount.ToString();
                TableMalType_txt.Text = row.MalfunctionType;
                TableMalDateOpen_txt.Text = row.MalfunctionDateOpened;
                TableMalDateClose_txt.Text = row.MalfunctionDateClosed;
                TableTechId_txt.Text = row.TechnicianId;
                TableResult_txt.Text = row.MalfunctionResult;
                if (row.MalfunctionDateClosed == "" && ActiveUser.Role.ToLower() != "setup")
                    TableCloseMal.IsEnabled = true;
                else
                    TableCloseMal.IsEnabled = false;

                if (ActiveUser.Role.ToLower() != "setup")
                    TableDelMal.IsEnabled = true;
            }
        }

        private void TableDG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Table row = (Table)TableDG.SelectedItem;
            if (row != null)
            {
                TableID_txt.Text = row.TableID;
                TableUserId_txt.Text = row.UserID;
                TableType_txt.Text = row.TableType;
                TableStatus_txt.Text = row.TableStatus;
                TableMalCount_Txt.Text = row.MalfunctionCount.ToString();
                TableMalType_txt.Text = "";
                TableMalDateOpen_txt.Text = "";
                TableMalDateClose_txt.Text = "";
                TableTechId_txt.Text = "";
                TableResult_txt.Text = "";
                TableCloseMal.IsEnabled = false;
                TableDelMal.IsEnabled = false;
            }
        }

        private void SegmentDG_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Segment row = (Segment)SegmentMalfunctionDG.SelectedItem;
            if (row != null)
            {
                SegmentLine_txt.Text = row.Line;
                SegmentMachine_txt.Text = row.Station;
                SegmentNumber_txt.Text = row.SegmentNumber.ToString();
                OmitSegmentCount_Txt.Text = row.OmitSegment.ToString();
                SegmentSetup_txt.Text = row.Setup;
            }
        }

        private void OpenTableMal_Click(object sender, RoutedEventArgs e)
        {
            OpenTableMal O = new OpenTableMal();
            O.ShowDialog();
            SetTable();
        }

        private void TableClosedMal_Checked(object sender, RoutedEventArgs e)
        {
            List<TableMalfunction> list;
            if (TableOpenMalCheck.IsChecked == true)
                list = TableMalList;
            else
                list = TableMalList.Where(x => x.MalfunctionDateClosed != "").ToList();

            TableMalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TableMalHeader.Content = "Table Malfunctions List (" + n + ")";
            CleanTable();
        }

        private void TableClosedMal_Unchecked(object sender, RoutedEventArgs e)
        {
            List<TableMalfunction> list;
            if (TableOpenMalCheck.IsChecked == true)
                list = TableMalList.Where(x => x.MalfunctionDateClosed == "").ToList();
            else
                list = null;

            TableMalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TableMalHeader.Content = "Table Malfunctions List (" + n + ")";
            CleanTable();
        }

        private void TableOpenMal_Checked(object sender, RoutedEventArgs e)
        {
            List<TableMalfunction> list;
            if (TableClosedMalCheck.IsChecked == true)
                list = TableMalList;
            else
                list = TableMalList.Where(x => x.MalfunctionDateClosed == "").ToList();

            TableMalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TableMalHeader.Content = "Table Malfunctions List (" + n + ")";
            CleanTable();
        }

        private void TableOpenMal_Unchecked(object sender, RoutedEventArgs e)
        {
            List<TableMalfunction> list;
            if (TableClosedMalCheck.IsChecked == true)
                list = TableMalList.Where(x => x.MalfunctionDateClosed != "").ToList();
            else
                list = null;

            TableMalfunctionDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TableMalHeader.Content = "Table Malfunctions List (" + n + ")";
            CleanTable();
        }

        private void TableInWork_Checked(object sender, RoutedEventArgs e)
        {
            List<Table> list;
            if (TableOpenCheck.IsChecked == true)
                list = TableList;
            else
                list = TableList.Where(x => x.TableStatus == "In Work").ToList();

            TableDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TablesListHeader.Content = "Table List (" + n + ")";
            CleanTable();
        }

        private void TableInWork_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Table> list;
            if (TableOpenCheck.IsChecked == true)
                list = TableList.Where(x => x.TableStatus == "Malfunction Opened").ToList();
            else
                list = null;

            TableDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TablesListHeader.Content = "Table List (" + n + ")";
            CleanTable();
        }

        private void TableOpen_Checked(object sender, RoutedEventArgs e)
        {
            List<Table> list;
            if (TableInWorkCheck.IsChecked == true)
                list = TableList;
            else
                list = TableList.Where(x => x.TableStatus == "Malfunction Opened").ToList();

            TableDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TablesListHeader.Content = "Table List (" + n + ")";
            CleanTable();
        }

        private void TableOpen_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Table> list;
            if (TableInWorkCheck.IsChecked == true)
                list = TableList.Where(x => x.TableStatus == "In Work").ToList();
            else
                list = null;

            TableDG.ItemsSource = list;
            int n = list == null ? 0 : list.Count;
            TablesListHeader.Content = "Table List (" + n + ")";
            CleanTable();
        }

        private void CloseTableMal_Click(object sender, RoutedEventArgs e)
        {
            if (TableTechId_txt.Text == "" || TableResult_txt.Text == "")
            {
                MessageBox.Show("Fill Technician ID And Result", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string qry = string.Format(@"UPDATE TableMalfunctions 
                                       SET MalfunctionDateClosed='{0}', MalfunctionResult=N'{1}', TechnicianId='{2}', TableStatus='In Work'
                                       WHERE TableID='{3}' AND MalfunctionCount='{4}'",
                                       DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), TableResult_txt.Text, TableTechId_txt.Text, TableID_txt.Text, TableMalCount_Txt.Text);
            sql.Update(qry);

            qry = string.Format(@"UPDATE Tables SET TableStatus='In Work' WHERE TableId='{0}'", TableID_txt.Text);
            sql.Update(qry);

            MessageBox.Show("Mulfunction Closed Successfully!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            SetTable();
        }

        private void DelTableMal_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                string qry = string.Format(@"DELETE FROM TableMalfunctions WHERE TableID='{0}' AND MalfunctionCount='{1}'", TableID_txt.Text, TableMalCount_Txt.Text);
                sql.Delete(qry);

                qry = string.Format(@"BEGIN
                                       IF NOT EXISTS (SELECT * FROM TableMalfunctions WHERE TableID='{0}' AND MalfunctionDateClosed IS NULL)
                                       BEGIN
                                           UPDATE Tables SET TableStatus='In Work' WHERE TableId='{0}'
                                       END
                                    END", TableID_txt.Text);
                sql.Update(qry);

                MessageBox.Show("Mulfunction Deleted Successfully!", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                SetTable();
                CleanFeeder();
            }
        }

        public static string GetIso8601WeekOfYear(DateTime time)
        {
            TimeSpan start = new TimeSpan(00, 0, 0); //00 o'clock
            TimeSpan end = new TimeSpan(07, 0, 0); //07 o'clock
            DayOfWeek day;
            if (time.DayOfWeek == DayOfWeek.Sunday && time.TimeOfDay >= start && time.TimeOfDay < end)//if its 
                day = DayOfWeek.Saturday;
            else
                day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Sunday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(4);
            }
            // Return the week of our adjusted day.. TAKE THE CURRENT WEEK +1 FOR YEAR 2021
            string res;
            if (DateTime.Now.Year == 2023)
                res = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
            else
                res = (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + 1).ToString();

            return res;
        }

        private void CalibrateFeeder_Click(object sender, RoutedEventArgs e)
        {
            Feeder row = (Feeder)FeederDG.SelectedCells[0].Item;
            if (row != null)
            {
                CalibrateFeeder Cal = new CalibrateFeeder(row.FeederID);
                Cal.ShowDialog();
                SetFeeder();
            }

        }

        private void CalibrateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FeederID_txt.Text != "")
            {
                CalibrateFeeder Cal = new CalibrateFeeder(FeederID_txt.Text);
                if (Cal.ShowDialog() == false)
                    CalibrateCheckBox.IsChecked = false;
                SetFeeder();
            }
        }

        private void ChangeMalType_Click(object sender, RoutedEventArgs e)
        {
            FeederMalfunction F = FeederMalList.First(x => x.FeederId.ToLower() == FeederID_txt.Text.ToLower());
            ChangeMalType Ch = new ChangeMalType(F);
            Ch.ShowDialog();
        }

        private void FeederStatus_txt_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox CB = (ComboBox)sender;
            string Str = CB.SelectedItem != null ? CB.SelectedItem.ToString() : "";
            if (Str != "" && FeederID_txt.Text != "")
            {
                if (Str == "In Storage" && FeederMalList.Exists(x => x.FeederId.ToLower() == FeederID_txt.Text.ToLower() && x.FeederStatus == "Malfunction Opened"))
                {
                    MessageBox.Show("There is Open Mulfunction To This Feeder, Close Them Before.", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }
                string qry = string.Format(@"UPDATE Feeders SET FeederStatus='{1}' WHERE FeederID='{0}'
                                             UPDATE FeederMalfunctions SET FeederStatus='{1}' WHERE FeederID='{0}'", FeederID_txt.Text, Str);
                sql.Update(qry);

                SetFeeder();
            }
        }
    }
}
