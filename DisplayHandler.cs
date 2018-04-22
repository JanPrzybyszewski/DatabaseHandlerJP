using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Channels;

namespace DataBaseHandler
{
    class DisplayHandler
    {
        // Handling database login

        static public void InsertDBInfo(ref string server,ref string database,ref string ID,ref string pass)
        {
            Console.WriteLine("Welcome to the DatabaseHandler. First, insert Your db information to login: \n");
            Console.WriteLine("Serwer name: ");
            server = Console.ReadLine();
            Console.WriteLine("\nDB name: ");
            database = Console.ReadLine();
            Console.WriteLine("\nUserID: ");
            ID = Console.ReadLine();
            Console.WriteLine("\nPassword: ");
            pass = Console.ReadLine();
            Console.Clear();
        }
        // Inserting table names into a list to display them.
        static public void TableNamesIntoList(SqlConnection conn, List<string> tables)
        {
            tables.Clear();
            int i = 1;
            DataTable dt = conn.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {

                string tablename = (string)row[2];
                if (i != 1)
                    tables.Add(tablename);
                i++;
            }
        }
        // Displaying Table names.
        static public void WriteTableNames(List<string> tables)
        {
            Console.Clear();
            Console.WriteLine("Tables in the current DB: \n");
            foreach (var r in tables)
            {
                Console.WriteLine("\n" + r);
            }
            Console.WriteLine("\nPress ENTER to go back to Main Menu");
            Console.ReadLine();
        }

        // Displaying the table.
        public static void DisplaySpecificTable(string name, SqlConnection conn)
        {

            SqlCommand command = new SqlCommand("SELECT * FROM " + name, conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
              DisplayTable(reader);
            }
            Console.WriteLine("\nPress enter to go back to Main Menu");
            Console.ReadLine();
        }

       
       

        // Columns displaying.

        public static void DisplayTable(SqlDataReader reader)
        {
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
            int i = 0;
            int length = reader.FieldCount;

            while (i < length)
            {
                Console.Write(columns[i].ToString().PadRight(30));
                i++;
            }
            Console.WriteLine();

            while (reader.Read())
            {
                i = 0;
                while (i < length)
                {
                    Console.Write(reader[i].ToString().PadRight(20));
                    i++;
                }
                Console.WriteLine();
            }
        }


    }
}
