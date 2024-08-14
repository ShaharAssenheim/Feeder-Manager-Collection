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
    public partial class ChangeMalType : Window
    {
        List<string> MalType = new List<string>() {"תקלה כללית", "STEP פידר מאבד", "מנהרת סרט סתומה", "ויברטור לא מתכוון) עוצמה)", "מסילת סרט פגומה", "סרגל עקום",
                                                  "השמת רכיבים על הצד", "לא יציב) פידר רוטט)", "אין פקודת הפעלה לפידר ממכונה", "סרט רוטט / פידר קורע ניילון", "Type Spring / מכסה אחורי",
                                                  "תיקון גוף", "Pickup Position", "מנוע קדמי לא תקין ", "פידר קורע ניילון", "סוגר קפיץ / קפיץ קדמי פגום", "מנוע אחורי לא תקין",
                                                  "אין פקודה ממכונה / פידר לא מגיב כלל", "פידר לא מגיב כלל", "פידר מפזר רכיבים", "פידר לא יציב, רוטט ", "מנוע אחורי לא תקין / לא מושך ניילון",
                                                  "לא מכויל", "מנוע קדמי לא תקין / לא מושך סרט", "השמתת רכיבים/פידר מפזר רכיבים", "ויברטור לא מגיב כלל "};

        FeederMalfunction CurrentMal = new FeederMalfunction();
        public ChangeMalType(FeederMalfunction F)
        {
            InitializeComponent();
            Mal_Type.ItemsSource = MalType;
            Mal_Type.SelectedIndex = MalType.IndexOf(F.MalfunctionType);
            CurrentMal = F;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string qry = string.Format(@"UPDATE FeederMalfunctions SET MalfunctionType=N'{0}'
                                       WHERE FeederId='{1}' AND UserId='{2}' AND FeederStatus='Malfunction Opened'",
                                       Mal_Type.Text, CurrentMal.FeederId, CurrentMal.UserId);
            MainWindow.sql.Update(qry);
            MainWindow.mn.MalType_txt.Text = Mal_Type.Text;
            Close();
        }
    }
}
