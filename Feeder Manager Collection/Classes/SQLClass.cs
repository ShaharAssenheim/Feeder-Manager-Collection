using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Feeder_Manager
{
    public class SQLClass
    {
        private SqlConnection conn;
        private readonly string connectionString = "";

        public SQLClass(string ServerName, string DataBaseName, string UserName, string Secret)
        {
            connectionString =
           "Data Source=" + ServerName + ";" +
           "Initial Catalog=" + DataBaseName + ";" +
           "User id=" + UserName + ";" +
           "Password=" + Secret + ";";
        }

        private bool OpenConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 53:
                        MessageBox.Show("Cannot connect to server. check your internet connection");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int InsertScalar(string query)
        {
            int n = -1;
            if (this.OpenConnection() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    n = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return n;
        }

        public void Update(string query)
        {
            if (this.OpenConnection() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
        }

        public void InsertNonQuery(string query)
        {
            if (this.OpenConnection() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
        }

        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                catch (Exception ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
            }
        }


        internal List<FeederMalfunction> SelectFeederMalfunction(string query)
        {
            List<FeederMalfunction> list = new List<FeederMalfunction>();
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FeederMalfunction M = new FeederMalfunction();
                            M.FeederId = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                            M.UserId = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                            M.FeederType = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            M.FeederStatus = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
                            M.CalibrationDateExpired = reader.IsDBNull(4) ? "" : reader.GetDateTime(4).ToString("dd/MM/yyyy HH:mm");
                            M.MalfunctionCount = reader.GetInt32(5);
                            M.MalfunctionType = reader.IsDBNull(6) ? "" : reader.GetString(6).Trim();
                            M.MalfunctionDateOpened = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd/MM/yyyy HH:mm");
                            M.OpenWeek = reader.GetDateTime(7).Year.ToString() + "-" + MainWindow.GetIso8601WeekOfYear(reader.GetDateTime(7));
                            M.OpenYear = reader.GetDateTime(7).Year.ToString();
                            M.MalfunctionDateClosed = reader.IsDBNull(8) ? "" : reader.GetDateTime(8).ToString("dd/MM/yyyy HH:mm");
                            M.CloseWeek = M.MalfunctionDateClosed == "" ? "" : reader.GetDateTime(8).Year.ToString() + "-" + MainWindow.GetIso8601WeekOfYear(reader.GetDateTime(8));
                            M.MalfunctionResult = reader.IsDBNull(9) ? "" : reader.GetString(9).Trim();
                            M.TechnicianId = reader.IsDBNull(10) ? "" : reader.GetString(10).Trim();
                            list.Add(M);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }

        internal List<Feeder> SelectFeeders(string query)
        {
            List<Feeder> list = new List<Feeder>();
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feeder F = new Feeder();
                            F.FeederID = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                            F.UserID = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                            F.FeederType = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            F.CreationDate = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                            F.FeederStatus = reader.IsDBNull(4) ? "" : reader.GetString(4).Trim();
                            F.CalibrationDateExpired = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToString("dd/MM/yyyy HH:mm");
                            F.MalfunctionCount = reader.GetInt32(6);
                            F.LastTimeChecked = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd/MM/yyyy HH:mm");
                            F.FeederSensor = reader.IsDBNull(8) ? "" : reader.GetString(8).Trim();
                            F.ID = reader.GetInt32(9);
                            list.Add(F);
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }

        internal List<Table> SelectTables(string query)
        {
            List<Table> list = new List<Table>();
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Table T = new Table();
                            T.TableID = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                            T.UserID = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                            T.TableType = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            T.CreationDate = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                            T.TableStatus = reader.IsDBNull(4) ? "" : reader.GetString(4).Trim();
                            T.MalfunctionCount = reader.GetInt32(5);
                            T.LastTimeChecked = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString("dd/MM/yyyy HH:mm");
                            list.Add(T);
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }

        internal List<TableMalfunction> SelectTableMalfunction(string query)
        {
            List<TableMalfunction> list = new List<TableMalfunction>();
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableMalfunction M = new TableMalfunction();
                            M.TableId = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                            M.UserId = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                            M.TableType = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            M.TableStatus = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
                            M.MalfunctionCount = reader.GetInt32(4);
                            M.MalfunctionType = reader.IsDBNull(5) ? "" : reader.GetString(5).Trim();
                            M.MalfunctionDateOpened = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString("dd/MM/yyyy HH:mm");
                            M.OpenWeek = reader.GetDateTime(6).Year.ToString() + "-" + MainWindow.GetIso8601WeekOfYear(reader.GetDateTime(6));
                            M.OpenYear = reader.GetDateTime(6).Year.ToString();
                            M.MalfunctionDateClosed = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd/MM/yyyy HH:mm");
                            M.CloseWeek = M.MalfunctionDateClosed == "" ? "" : reader.GetDateTime(7).Year.ToString() + "-" + MainWindow.GetIso8601WeekOfYear(reader.GetDateTime(7));
                            M.MalfunctionResult = reader.IsDBNull(8) ? "" : reader.GetString(8).Trim();
                            M.TechnicianId = reader.IsDBNull(9) ? "" : reader.GetString(9).Trim();
                            list.Add(M);
                        }

                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }

        internal List<User> SelectUsers(string query)
        {
            List<User> list = new List<User>();
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User U = new User();
                            U.UserID = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                            U.UserName = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                            U.Password = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            U.Role = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
                            list.Add(U);
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }

        internal DataTable SelectDb(string query)
        {
            var cmdResult = new DataTable();

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                if (cmd != null)
                {
                    try
                    {
                        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        cmdResult.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open) conn.Close();
                    }
                }
            }
            return cmdResult;
        }

        internal List<Segment> SelectSegment(string v)
        {
            List<Segment> list = new List<Segment>();

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(v, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string Color = "White";
                        string Last = "";
                        while (reader.Read())
                        {
                            Segment row = new Segment();
                            row.SegmentNumber = reader.GetDouble(0) / 1000;
                            row.OmitSegment = reader.GetInt32(1);
                            row.Line = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                            row.Station = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
                            row.Setup = reader.IsDBNull(4) ? "" : reader.GetString(4).Trim();

                            if (list.Exists(x => x.Line == row.Line && x.Station == row.Station && x.SegmentNumber == row.SegmentNumber)) continue;
                            if (Last != row.Line)
                                Color = Color == "White" ? "LightGray" : "White";
                            row.RowColor = Color;
                            list.Add(row);
                            Last = row.Line;
                        }
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    this.CloseConnection();
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
            }
            return list;
        }
    }
}
