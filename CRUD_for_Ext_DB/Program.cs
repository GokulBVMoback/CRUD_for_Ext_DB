using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_for_Ext_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD crud=new CRUD();
            Console.WriteLine("Employee Management Application");
            Console.WriteLine("Select Operation:");
            Console.WriteLine("1 Add Employee Details");
            Console.WriteLine("2 Display All Employee");
            Console.WriteLine("3 Display Employee you want to see");
            Console.WriteLine("4 Edit Employees");
            Console.WriteLine("5 Delete Employee Detail");
            Console.WriteLine("Press 'x' key to exit");
            var operation = Console.ReadLine();
            while (true)
            {
                switch (operation)
                {
                    case "1":
                        crud.Create();
                        break;
                    case "2":
                        crud.RetrieveAll();
                        break;
                    case "3":
                        crud.Retrieve();
                        break;
                    case "4":
                        crud.Update();
                        break;
                    case "5":
                        crud.Delete();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select valid Operation");
                        break;
                }
                Console.Write("\nSelect Operation:");
                operation = Console.ReadLine();
            }
        }
    }
}
