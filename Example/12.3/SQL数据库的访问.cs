using System.Data.SQLite; 
 
   public void Demo()
        {
            //如果不存在，则创建一个空的数据库,
            if(!System.IO.File.Exists("MyDatabase.sqlite"))
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
 
            //创建一个连接
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
 
            //创建一个数据表
            string sql = "create table book (title varchar(20), author varchar(10), pages int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
 
            //插入一些记录
            sql = "insert into book (title, author, pages) values ('C#程序设计教程', '唐大仕', 570)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
 
            sql = "insert into book (title, author, pages) values ('Java程序设计', '唐大仕', 390)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
 
            sql = "insert into book (title, author, pages) values ('Visual C++.NET程序设计', '唐大仕，刘光', 410)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
 
            //使用sql查询语句，并显示结果
            sql = "select * from book order by pages desc";
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("书名: " + reader["title"] + "\t页数: " + reader["pages"]);
             
            //关闭连接
            m_dbConnection.Close();
 
            Console.ReadLine();
 
 
        }