using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fifteen
{
    class SQlite
    {
        string db_name = @"C:\Users\HP\Desktop\Пятнашки C#. 08.06.19\Исходный код\Fifteen\scores.db";

        public class data
        {
            public string name { get; set; }
            public int time { get; set; }
        }
        List<data> spisok = new List<data>();
        List<data> info = new List<data>();
        public int tumes = 0;

        public List<data> output()
        {
            info.Clear();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM Hightscore ORDER BY time DESC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data st = new data
                {
                    name = reader["name"].ToString(),
                    time = int.Parse(reader["time"].ToString()),
                };
                info.Add(st);

            }
            m_dbConnection.Close();
            return (info);
        }
        bool make_add = true;
        public bool input(int time, string name)
        {

           
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "select name from Hightscore";
            SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (reader["name"].ToString() == name)
                {
                    if ((MessageBox.Show("Имя уже есть в таблице. Заменить?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        {
                            sql = "UPDATE Hightscore SET time = " + time + " WHERE name = '" + name + "'";
                            command1 = new SQLiteCommand(sql, m_dbConnection);
                            command1.ExecuteNonQuery();
                            make_add = false;
                            break;
                        }
                        

                        // иначе оставляем результат из таблицы
                    }
                    else make_add = false;
                }

            }
            
          
                if (make_add == true)
                {
                    SQLiteCommand command = new SQLiteCommand();
                    sql = "INSERT INTO  Hightscore ( name, time ) VALUES (" + "'" + name + "'" + "," + time + ")";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
            
            m_dbConnection.Close();
            return (true);
        }
    }
}
