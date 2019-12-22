using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace CH12
{
    public class DB
    {
        
        public static int intCount;
        public DB()
        {

            if (!System.IO.File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            }
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM Grade4", m_dbConnection);
            intCount = Convert.ToInt16(command.ExecuteScalar());
            m_dbConnection.Close();
        }
        public struct infor
        {
            public int i;
            public string eng;
            public string chi;
            public int fami;
        }

        public void creatTable()
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                string sql = "create table Grade4(ID int, English varchar(50), Chinese varchar(50), familiarity int)";
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void insertData(int intID, string strEnglish, string strChinese, int intFamiliarity)
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                string sql = string.Format("insert into Grade4 (ID, English, Chinese, familiarity) values ({0},'{1}', '{2}',{3} )", intID, strEnglish, strChinese, intFamiliarity);
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                Console.WriteLine(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public infor searchInfo(int i)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            infor s = new infor();
            string sql = string.Format("select * from Grade4 where ID={0}", i);
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            s.i = (int)reader[0];
            s.eng = (string)reader["English"];
            s.chi = (string)reader["Chinese"];
            s.fami = (int)reader[3];
            reader.Close();
            m_dbConnection.Close();
            return s;

        }

        public void updata(int intVal, int ID)
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                string sql = string.Format("UPDATE Grade4 SET familiarity = {0} WHERE ID = {1}", intVal, ID);
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                Console.WriteLine(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataSet showFamiliarityLess5()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            string sql = "select * from grade4 where familiarity < 5 order by familiarity ASC";
            SQLiteDataAdapter daAdapter = new SQLiteDataAdapter(sql, m_dbConnection);

            //OleDbCommandBuilder cmdbld = new OleDbCommandBuilder( daAdapter );

            DataSet dsMyData = new DataSet();

            daAdapter.Fill(dsMyData);

            return dsMyData;
        }
        public DataSet showFamiliarityHigher5()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            string sql = "select * from grade4 where familiarity > 4 order by familiarity ASC";
            SQLiteDataAdapter daAdapter = new SQLiteDataAdapter(sql, m_dbConnection);

            //OleDbCommandBuilder cmdbld = new OleDbCommandBuilder( daAdapter );

            DataSet dsMyData = new DataSet();

            daAdapter.Fill(dsMyData);

            return dsMyData;
        }
    }
}
