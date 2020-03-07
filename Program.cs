using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data.Common; 
using MySql.Data.MySqlClient;
using Tutorial.SqlConn;
namespace gittest
{
    class Program
    {
    
    
            static void Main(string[] args)
        {
            // Получить объект Connection подключенный к DB.
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
		Console.WriteLine("Connect Succses");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Уничтожить объект, освободить ресурс.
                conn.Dispose();
            }       
            Console.Read();
        }
 
        private static void QueryEmployee(MySqlConnection conn)
        { 
            string sql = "Select * from Users"; 
 
            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
 
            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql; 
 
             
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                     
                    while (reader.Read())
                    {
                        // Индекс (index) столбца Emp_ID в команде SQL.
                        int number = Convert.ToInt32(reader.GetValue(0));
                        string name = reader.GetString(1);
                         
                        // Проверить значение данного столбца может являться null или нет.
                        Console.WriteLine("--------------------");
			Console.WriteLine("Number: " + number);
                        Console.WriteLine("name: " + name);
                    }
                }
       
	    }
	}
    }
}
