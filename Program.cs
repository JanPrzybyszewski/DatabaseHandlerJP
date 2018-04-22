using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Channels;

namespace DataBaseHandler
{
    class Program
    {

        static void Main(string[] args)
            {
                List<string> tables = new List<string>();
                int actionChoice;
                string server = "",database = "",userID = "",password = "",tableName;

                DisplayHandler.InsertDBInfo(ref server,ref database,ref userID,ref password);

           // Example: "Server=serwerlink;Database=JPDB1;User ID = serwerid;Password=**************;Trusted_Connection=False;Encrypt = True";

            using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString =
                        "Server=tcp:" + server + ";Database=" + database + ";User ID=" + userID + ";Password=" + password + ";Trusted_Connection=False;Encrypt = True";
                    conn.Open();


                    while(true)
                    {
                    Console.Clear();
                    Console.WriteLine("\nWelcome to the DataBaseHandler. What do You want to do? \n\n \t 1 - See database tables' names \t 2 - See a specific database table \t 3 - EXIT\n Choose the number and type it in:");
                    actionChoice = int.Parse(Console.ReadLine());


                switch (actionChoice)
                {
                    case 1:
                    {
                        DisplayHandler.TableNamesIntoList(conn,tables);
                        DisplayHandler.WriteTableNames(tables);
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("\nInsert table name: ");
                        tableName = Console.ReadLine();
                        DisplayHandler.DisplaySpecificTable(tableName,conn);
                        break;
                    }
                    case 3:
                    {
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Insert a proper table\n");
                        break;
                    }
                }
                    };

                }
            }
        }
    }

