using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeder_Manager
{
   
    public class FeederMalfunction
    {
        public string FeederId { get; set; }
        public string UserId { get; set; }
        public string FeederType { get; set; }
        public string FeederStatus { get; set; }
        public string CalibrationDateExpired { get; set; }
        public int MalfunctionCount { get; set; }
        public string MalfunctionType { get; set; }
        public string MalfunctionDateOpened { get; set; }
        public string MalfunctionDateClosed { get; set; }
        public string MalfunctionResult { get; set; }
        public string TechnicianId { get; set; }
        public string OpenWeek { get; set; }
        public string CloseWeek { get; set; }
        public string OpenYear { get; set; }
        public string FeederSensor { get; set; }
    }

    public class Feeder
    {
        public int ID { get; set; }
        public string FeederID { get; set; }
        public string UserID { get; set; }
        public string FeederType { get; set; }
        public string CreationDate { get; set; }
        public string FeederStatus { get; set; }
        public string CalibrationDateExpired { get; set; }
        public int MalfunctionCount { get; set; }
        public string LastTimeChecked { get; set; }
        public string FeederSensor { get; set; }
    }

    public class Table
    {
        public string TableID { get; set; }
        public string UserID { get; set; }
        public string TableType { get; set; }
        public string CreationDate { get; set; }
        public string TableStatus { get; set; }
        public int MalfunctionCount { get; set; }
        public string LastTimeChecked { get; set; }
    }

    public class TableMalfunction
    {
        public string TableId { get; set; }
        public string UserId { get; set; }
        public string TableType { get; set; }
        public string TableStatus { get; set; }
        public int MalfunctionCount { get; set; }
        public string MalfunctionType { get; set; }
        public string MalfunctionDateOpened { get; set; }
        public string MalfunctionDateClosed { get; set; }
        public string MalfunctionResult { get; set; }
        public string TechnicianId { get; set; }
        public string OpenWeek { get; set; }
        public string CloseWeek { get; set; }
        public string OpenYear { get; set; }
    }

    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class Segment
    {
        public double SegmentNumber { get; set; }
        public int OmitSegment { get; set; }
        public string Line { get; set; }
        public string Station { get; set; }
        public string Setup { get; set; }
        public string RowColor { get; set; }
    }
}
