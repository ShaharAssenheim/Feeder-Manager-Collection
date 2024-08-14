using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class Statistics : Window
    {
        public SeriesCollection FeederOpenSeries { get; set; }
        public string[] FeederOpenLabels { get; set; }
        public Func<double, string> FeederOpenFormatter { get; set; }

        public SeriesCollection FeederReasonSeries { get; set; }
        public string[] FeederReasonLabels { get; set; }
        public Func<double, string> FeederReasonFormatter { get; set; }


        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        public SeriesCollection TableOpenSeries { get; set; }
        public string[] TableOpenLabels { get; set; }
        public Func<double, string> TableOpenFormatter { get; set; }

        public SeriesCollection TableReasonSeries { get; set; }
        public string[] TableReasonLabels { get; set; }
        public Func<double, string> TableReasonFormatter { get; set; }

        public static bool Mode = false;//bright=false, dark=true

        int CurrentMonth = DateTime.Now.Month;
        int CurrentYear = DateTime.Now.Year;
        Dictionary<int, string> Months = new Dictionary<int, string>()
        {
            {1,"January" },
            {2,"February" },
            {3,"March" },
            {4,"April" },
            {5,"May" },
            {6,"June" },
            {7,"July" },
            {8,"August" },
            {9,"September" },
            {10,"October" },
            {11,"November" },
            {12,"December" },
        };

        public Statistics()
        {
            InitializeComponent();
            FillFeederOpenChart(MainWindow.FeederMalList);
            FillFeederReasonChart(MainWindow.FeederMalList);
        }

        private void Fedders_Click(object sender, RoutedEventArgs e)
        {
            FeedersGrid.Visibility = Visibility.Visible;
            TablesGrid.Visibility = Visibility.Hidden;
            FillFeederOpenChart(MainWindow.FeederMalList);
            FillFeederReasonChart(MainWindow.FeederMalList);
        }

        private void Tables_Click(object sender, RoutedEventArgs e)
        {
            FeedersGrid.Visibility = Visibility.Hidden;
            TablesGrid.Visibility = Visibility.Visible;
            FillTableOpenChart(MainWindow.TableMalList);
            FillTableReasonChart(MainWindow.TableMalList.Where(x => x.CloseWeek != "").ToList());
        }

        private void Mode_Click(object sender, RoutedEventArgs e)
        {
            Mode = !Mode;
            var bc = new BrushConverter();
            FeederHeader1.Foreground = Mode ? Brushes.White : Brushes.Black;
            FeederHeader2.Foreground = Mode ? Brushes.White : Brushes.Black;
            FeedersGrid.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            FeederSP1.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            FeederSP2.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            BtnFeederOpen.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            BtnFeederClose.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            FeederOpenChart.Foreground = Mode ? Brushes.White : Brushes.Black;
            FeederOpenAxisX.Foreground = Mode ? Brushes.White : Brushes.Black;
            FeederOpenAxisY.Foreground = Mode ? Brushes.White : Brushes.Black;

            TableHeader1.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableHeader2.Foreground = Mode ? Brushes.White : Brushes.Black;
            TablesGrid.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            TableSP1.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            TableSP2.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            BtnTableOpen.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            BtnTableClose.Background = Mode ? (Brush)bc.ConvertFrom("#373737") : Brushes.White;
            TableOpenChart.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableReasonChart.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableOpenAxisX.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableCloseAxisX.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableOpenAxisY.Foreground = Mode ? Brushes.White : Brushes.Black;
            TableCloseAxisY.Foreground = Mode ? Brushes.White : Brushes.Black;
        }

        public void FillFeederOpenChart(List<FeederMalfunction> AllList)
        {
            var resOpen = AllList.GroupBy(x => new { x.OpenWeek })
             .Select(g => new { g.Key.OpenWeek, MyCount = g.Count() }).Reverse().ToList();

            var resClose = AllList.Where(x => x.CloseWeek != "").GroupBy(x => new { x.CloseWeek })
                    .Select(g => new { g.Key.CloseWeek, MyCount = g.Count() }).Reverse().ToList();

            FeederOpenLabels = new string[resOpen.Count()];
            ChartValues<int> Val = new ChartValues<int>();
            ChartValues<int> Val2 = new ChartValues<int>();

            int j = 0;

            foreach (var item in resOpen.Skip(Math.Max(0, resOpen.Count - 10)))
            {
                FeederOpenLabels[j] = item.OpenWeek;
                Val.Add(item.MyCount);
                j++;
            }


            foreach (var item in resClose.Skip(Math.Max(0, resClose.Count - 10)))
            {
                Val2.Add(item.MyCount);
            }


            FeederOpenSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Open Mulfunction",
                    Values = Val,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightSkyBlue,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                },
                 new ColumnSeries
                {
                    Title = "Close Mulfunction",
                    Values = Val2,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightGreen,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                }
            };

            FeederOpenFormatter = value => value.ToString("G");
            DataContext = this;
            FeederOpenChart.Series = FeederOpenSeries;
            FeederOpenAxisX.Labels = FeederOpenLabels;
            FeederOpenAxisX.Separator.Step = 1;
            FeederOpenAxisY.LabelFormatter = FeederOpenFormatter;
            FeederOpenAxisY.MinValue = 0;
            FeederOpenAxisX.Separator.StrokeThickness = 0;
            FeederOpenAxisY.Separator.StrokeThickness = 0;
        }

        public void FillFeederReasonChart(List<FeederMalfunction> MalList)
        {
            FeederHeader2.Text = "Feeder Mulfunctions Reason - " + Months[CurrentMonth];
            var res = MalList.Where(x => Convert.ToDateTime(x.MalfunctionDateOpened).Month == CurrentMonth && Convert.ToDateTime(x.MalfunctionDateOpened).Year == CurrentYear).GroupBy(x => new { x.MalfunctionType })
             .Select(g => new { g.Key.MalfunctionType, MyCount = g.Count() }).Reverse().ToList().OrderByDescending(x => x.MyCount);

            FeederReasonLabels = new string[res.Count()];
            ChartValues<int> Val = new ChartValues<int>();

            int j = 0;
            foreach (var item in res)
            {
                FeederReasonLabels[j] = item.MalfunctionType;
                Val.Add(item.MyCount);
                j++;
            }

            FeederReasonSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Mulfunction Reasons",
                    Values = Val,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightSkyBlue,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                }
            };

            FeederReasonFormatter = value => value.ToString("G");
            DataContext = this;
            FeederReasonChart.Series = FeederReasonSeries;
            FeederReasonAxisX.Labels = FeederReasonLabels;
            FeederReasonAxisX.Separator.Step = 1;
            FeederReasonAxisY.Separator.Step = 5;
            FeederReasonAxisY.LabelFormatter = FeederReasonFormatter;
            FeederReasonAxisY.MinValue = 0;
            FeederReasonAxisX.Separator.StrokeThickness = 0;
            FeederReasonAxisY.Separator.StrokeThickness = 0;
            FeederReasonAxisX.LabelsRotation = 20;


        }

        public void FillTableOpenChart(List<TableMalfunction> OpenMalList)
        {
            var resOpen = OpenMalList.GroupBy(x => new { x.OpenWeek })
                          .Select(g => new { g.Key.OpenWeek, MyCount = g.Count() }).Reverse().ToList();

            var resClose = OpenMalList.Where(x => x.MalfunctionDateClosed != "").GroupBy(x => new { x.CloseWeek })
                           .Select(g => new { g.Key.CloseWeek, MyCount = g.Count() }).Reverse().ToList();

            TableOpenLabels = new string[resOpen.Count()];
            ChartValues<int> Val = new ChartValues<int>();
            ChartValues<int> Val2 = new ChartValues<int>();

            int j = 0;

            foreach (var item in resOpen.Skip(Math.Max(0, resOpen.Count - 10)))
            {
                TableOpenLabels[j] = item.OpenWeek;
                Val.Add(item.MyCount);
                j++;
            }


            foreach (var item in resClose.Skip(Math.Max(0, resClose.Count - 10)))
            {
                Val2.Add(item.MyCount);
            }


            TableOpenSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Open Mulfunction",
                    Values = Val,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightSkyBlue,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                },
                 new ColumnSeries
                {
                    Title = "Close Mulfunction",
                    Values = Val2,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightGreen,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                }
            };

            TableOpenFormatter = value => value.ToString("G");
            DataContext = this;
            TableOpenChart.Series = TableOpenSeries;
            TableOpenAxisX.Labels = TableOpenLabels;
            TableOpenAxisX.Separator.Step = 1;
            TableOpenAxisY.LabelFormatter = TableOpenFormatter;
            TableOpenAxisY.MinValue = 0;
            TableOpenAxisX.Separator.StrokeThickness = 0;
            TableOpenAxisY.Separator.StrokeThickness = 0;
        }

        public void FillTableReasonChart(List<TableMalfunction> CloseMalList)
        {
            TableHeader2.Text = "Table Mulfunctions Reason - " + Months[CurrentMonth];
            var res = CloseMalList.Where(x => Convert.ToDateTime(x.MalfunctionDateOpened).Month == CurrentMonth && Convert.ToDateTime(x.MalfunctionDateOpened).Year == CurrentYear).GroupBy(x => new { x.MalfunctionType })
             .Select(g => new { g.Key.MalfunctionType, MyCount = g.Count() }).Reverse().ToList().OrderByDescending(x => x.MyCount);

            TableReasonLabels = new string[res.Count()];
            ChartValues<int> Val = new ChartValues<int>();

            int j = 0;
            foreach (var item in res)
            {
                TableReasonLabels[j] = item.MalfunctionType;
                Val.Add(item.MyCount);
                j++;
            }

            TableReasonSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Mulfunction Reasons",
                    Values = Val,
                    DataLabels = true,
                    FontSize=18,
                    MaxColumnWidth=40,
                    Fill=Brushes.LightSkyBlue,
                    Foreground = Mode?Brushes.White:Brushes.Black,
                    LabelsPosition= BarLabelPosition.Perpendicular,
                    ScalesYAt=0
                }
            };

            TableReasonFormatter = value => value.ToString("G");
            DataContext = this;
            TableReasonChart.Series = TableReasonSeries;
            TableCloseAxisX.Labels = TableReasonLabels;
            TableCloseAxisX.Separator.Step = 1;
            TableCloseAxisY.Separator.Step = 5;
            TableCloseAxisY.LabelFormatter = TableReasonFormatter;
            TableCloseAxisY.MinValue = 0;
            TableCloseAxisX.Separator.StrokeThickness = 0;
            TableCloseAxisY.Separator.StrokeThickness = 0;
            TableCloseAxisX.LabelsRotation = 20;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.mn.ItemStatistics.IsEnabled = true;
            Close();
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth > 1)
                CurrentMonth--;
            else
            {
                CurrentMonth = 12;
                CurrentYear--;
            }
            FillFeederReasonChart(MainWindow.FeederMalList);
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth < 12)
                CurrentMonth++;
            else
            {
                CurrentMonth = 1;
                CurrentYear++;
            }
            FillFeederReasonChart(MainWindow.FeederMalList);
        }

        private void TableBtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth > 1)
                CurrentMonth--;
            else
            {
                CurrentMonth = 12;
                CurrentYear--;
            }
            FillTableReasonChart(MainWindow.TableMalList);

        }

        private void TableBtnRight_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonth < 12)
                CurrentMonth++;
            else
            {
                CurrentMonth = 1;
                CurrentYear++;
            }
            FillTableReasonChart(MainWindow.TableMalList);
        }
    }
}
