using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    public partial class Export : Window
    {
        public List<string> ExportChooseFiles = new List<string>();
        public ExcelPackage excel;

        public Export()
        {
            InitializeComponent();
            dp.SelectedDate = DateTime.Now;
            dp2.SelectedDate = DateTime.Now;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            excel = new ExcelPackage();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (AllFedders.IsChecked == false && AllTables.IsChecked == false && FeedersMalfunctions.IsChecked == false && TablesMalfunctions.IsChecked == false)
            {
                MessageBox.Show("You Must Choose Files", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            DateTime s1 = dp.SelectedDate.Value;
            DateTime s2 = dp2.SelectedDate.Value;
            if (s2 >= s1)
            {
                if (AllFedders.IsChecked == true)
                    ExportChooseFiles.Add("AllFedders");

                if (AllTables.IsChecked == true)
                    ExportChooseFiles.Add("AllTables");

                if (FeedersMalfunctions.IsChecked == true)
                    ExportChooseFiles.Add("FeedersMalfunctions");

                if (TablesMalfunctions.IsChecked == true)
                    ExportChooseFiles.Add("TablesMalfunctions");
            }
            else
            {
                MessageBox.Show("Invalid Date Range", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            Generate();
            Close();
        }

        private void Generate()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Execl files (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            string PrintFrom = dp.SelectedDate.Value.ToString("dd.MM.yyyy HH:mm:ss");
            string PrintTo = dp2.SelectedDate.Value.ToString("dd.MM.yyyy HH:mm:ss");
            saveFileDialog.FileName = "Feeder Manager Exports " + PrintFrom.Substring(0, 10) + " - " + PrintTo.Substring(0, 10);
            saveFileDialog.Title = "Feeder Manager Exports " + PrintFrom.Substring(0, 10) + " - " + PrintTo.Substring(0, 10);

            bool? result = saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;

            if ((result != null) && (result == true))
            {
                try
                {
                    for (int k = 0; k < ExportChooseFiles.Count(); k++)
                    {
                        ExcelWorksheet workSheet;
                        if (ExportChooseFiles[k] == "AllFedders")
                        {
                            workSheet = AllFeddersExcel("Feeders");
                        }
                        if (ExportChooseFiles[k] == "AllTables")
                        {
                            workSheet = AllTablesExcel("Tables");

                        }
                        if (ExportChooseFiles[k] == "FeedersMalfunctions")
                        {
                            workSheet = FeedersMalfunctionsExcel("Feeders Malfunctions");
                        }
                        if (ExportChooseFiles[k] == "TablesMalfunctions")
                            workSheet = TablesMalfunctionsExcel("Tables Malfunctions");
                    }
                    if (File.Exists(path))
                        File.Delete(path);

                    FileStream objFileStrm = File.Create(path);
                    objFileStrm.Close();
                    // Write content to excel file  
                    File.WriteAllBytes(path, excel.GetAsByteArray());
                    //Close Excel package 
                    excel.Dispose();
                    System.Diagnostics.Process.Start(path);

                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("being used by another process"))
                    {
                        MessageBox.Show("The File Is Open, Plaese Close It And Try Again.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                        MessageBox.Show(ex.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        public ExcelWorksheet AllFeddersExcel(string Type)
        {
            string From = dp.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string To = dp2.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");


            string qry = string.Format("SELECT * FROM Feeders WHERE CAST(CreationDate as date) BETWEEN '{0}' and '{1}' ORDER BY CreationDate desc", From, To);


            List<Feeder> list = MainWindow.sql.SelectFeeders(qry);
            var workSheet = excel.Workbook.Worksheets.Add(Type);
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Font.Size = 15;


            workSheet.Cells[1, 1].Value = "Feeder ID";
            workSheet.Cells[1, 2].Value = "User ID";
            workSheet.Cells[1, 3].Value = "Feeder Type";
            workSheet.Cells[1, 4].Value = "Creation Date";
            workSheet.Cells[1, 5].Value = "Feeder Status";
            workSheet.Cells[1, 6].Value = "Calibration Date";
            workSheet.Cells[1, 7].Value = "Malfunction Count";
            workSheet.Cells[1, 8].Value = "Last Time Checked";

            int i = 2;
            foreach (var row in list)
            {
                workSheet.Row(i).Style.Font.Size = 13;
                workSheet.Cells[i, 1].Value = row.FeederID;
                workSheet.Cells[i, 2].Value = row.UserID;
                workSheet.Cells[i, 3].Value = row.FeederType;
                workSheet.Cells[i, 4].Value = row.CreationDate;
                workSheet.Cells[i, 5].Value = row.FeederStatus;
                workSheet.Cells[i, 6].Value = row.CalibrationDateExpired;
                workSheet.Cells[i, 7].Value = row.MalfunctionCount.ToString();
                workSheet.Cells[i, 8].Value = row.LastTimeChecked;
                i++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();

            return workSheet;
        }

        public ExcelWorksheet AllTablesExcel(string Type)
        {
            string From = dp.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string To = dp2.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string qry = string.Format("SELECT * FROM Tables WHERE CAST(CreationDate as date) BETWEEN '{0}' and '{1}' ORDER BY CreationDate desc", From, To);


            List<Table> list = MainWindow.sql.SelectTables(qry);
            var workSheet = excel.Workbook.Worksheets.Add(Type);
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Font.Size = 15;


            workSheet.Cells[1, 1].Value = "Table ID";
            workSheet.Cells[1, 2].Value = "User ID";
            workSheet.Cells[1, 3].Value = "Table Type";
            workSheet.Cells[1, 4].Value = "Creation Date";
            workSheet.Cells[1, 5].Value = "Table Status";
            workSheet.Cells[1, 6].Value = "Malfunction Count";
            workSheet.Cells[1, 7].Value = "Last Time Checked";

            int i = 2;
            foreach (var row in list)
            {
                workSheet.Row(i).Style.Font.Size = 13;
                workSheet.Cells[i, 1].Value = row.TableID;
                workSheet.Cells[i, 2].Value = row.UserID;
                workSheet.Cells[i, 3].Value = row.TableType;
                workSheet.Cells[i, 4].Value = row.CreationDate;
                workSheet.Cells[i, 5].Value = row.TableStatus;
                workSheet.Cells[i, 6].Value = row.MalfunctionCount.ToString();
                workSheet.Cells[i, 7].Value = row.LastTimeChecked;
                i++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            return workSheet;
        }

        public ExcelWorksheet FeedersMalfunctionsExcel(string Type)
        {
            string From = dp.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string To = dp2.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string qry = string.Format("SELECT * FROM FeederMalfunctions WHERE CAST(MalfunctionDateOpened as date) BETWEEN '{0}' and '{1}' ORDER BY MalfunctionDateOpened desc", From, To);


            List<FeederMalfunction> list = MainWindow.sql.SelectFeederMalfunction(qry);
            var workSheet = excel.Workbook.Worksheets.Add(Type);
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Font.Size = 15;


            workSheet.Cells[1, 1].Value = "Feeder ID";
            workSheet.Cells[1, 2].Value = "User ID";
            workSheet.Cells[1, 3].Value = "Feeder Type";
            workSheet.Cells[1, 4].Value = "Feeder Status";
            workSheet.Cells[1, 5].Value = "Calibration Date Expired";
            workSheet.Cells[1, 6].Value = "Malfunction Count";
            workSheet.Cells[1, 7].Value = "Malfunction Type";
            workSheet.Cells[1, 8].Value = "Malfunction Date Opened";
            workSheet.Cells[1, 9].Value = "Malfunction Date Closed";
            workSheet.Cells[1, 10].Value = "Malfunction Result";
            workSheet.Cells[1, 11].Value = "Technician ID";

            int i = 2;
            foreach (var row in list)
            {
                workSheet.Row(i).Style.Font.Size = 13;
                workSheet.Cells[i, 1].Value = row.FeederId;
                workSheet.Cells[i, 2].Value = row.UserId;
                workSheet.Cells[i, 3].Value = row.FeederType;
                workSheet.Cells[i, 4].Value = row.FeederStatus;
                workSheet.Cells[i, 5].Value = row.CalibrationDateExpired;
                workSheet.Cells[i, 6].Value = row.MalfunctionCount.ToString();
                workSheet.Cells[i, 7].Value = row.MalfunctionType;
                workSheet.Cells[i, 8].Value = row.MalfunctionDateOpened;
                workSheet.Cells[i, 9].Value = row.MalfunctionDateClosed;
                workSheet.Cells[i, 10].Value = row.MalfunctionResult;
                workSheet.Cells[i, 11].Value = row.TechnicianId;
                i++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            return workSheet;
        }

        public ExcelWorksheet TablesMalfunctionsExcel(string Type)
        {
            string From = dp.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string To = dp2.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string qry = string.Format("SELECT * FROM TableMalfunctions WHERE CAST(MalfunctionDateOpened as date) BETWEEN '{0}' and '{1}' ORDER BY MalfunctionDateOpened desc", From, To);


            List<TableMalfunction> list = MainWindow.sql.SelectTableMalfunction(qry);
            var workSheet = excel.Workbook.Worksheets.Add(Type);
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Font.Size = 15;


            workSheet.Cells[1, 1].Value = "Table ID";
            workSheet.Cells[1, 2].Value = "User ID";
            workSheet.Cells[1, 3].Value = "Table Type";
            workSheet.Cells[1, 4].Value = "Table Status";
            workSheet.Cells[1, 5].Value = "Malfunction Count";
            workSheet.Cells[1, 6].Value = "Malfunction Type";
            workSheet.Cells[1, 7].Value = "Malfunction Date Opened";
            workSheet.Cells[1, 8].Value = "Malfunction Date Closed";
            workSheet.Cells[1, 9].Value = "Malfunction Result";
            workSheet.Cells[1, 10].Value = "Technician ID";

            int i = 2;
            foreach (var row in list)
            {
                workSheet.Row(i).Style.Font.Size = 13;
                workSheet.Cells[i, 1].Value = row.TableId;
                workSheet.Cells[i, 2].Value = row.UserId;
                workSheet.Cells[i, 3].Value = row.TableType;
                workSheet.Cells[i, 4].Value = row.TableStatus;
                workSheet.Cells[i, 5].Value = row.MalfunctionCount.ToString();
                workSheet.Cells[i, 6].Value = row.MalfunctionType;
                workSheet.Cells[i, 7].Value = row.MalfunctionDateOpened;
                workSheet.Cells[i, 8].Value = row.MalfunctionDateClosed;
                workSheet.Cells[i, 9].Value = row.MalfunctionResult;
                workSheet.Cells[i, 10].Value = row.TechnicianId;
                i++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            return workSheet;
        }
    }
}
