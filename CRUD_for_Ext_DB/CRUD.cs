using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_for_Ext_DB
{
    public class CRUD
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=MOBACK;Integrated Security=True");
        public void Create()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Department ID:");
                Console.WriteLine("1 for HR\n2 for Developer\n3 for Devops");
                int DepId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary ID:");
                Console.WriteLine("1 for 9000\n2 for 45000\n3 for 35000");
                int SalId = Convert.ToInt32(Console.ReadLine());
                string createQuery = "INSERT INTO Employee(EmpID,Name,DepID,SalID) VALUES('" + name + "'," + DepId + "," + SalId + ")";
                SqlCommand createCommand = new SqlCommand(createQuery, sqlConnection);
                createCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void RetrieveAll()
        {
            try
            {
                sqlConnection.Open();
                string retrieveAllQuery = "SELECT Employee.Name, Department.DepName,Salary.Salary\r\nFROM Employee\r\nINNER JOIN Department ON (Employee.DepID = Department.DepID)\r\nINNER JOIN Salary ON  (Employee.SalID = Salary.SalID)";
                SqlCommand retrieveAllCommand = new SqlCommand(retrieveAllQuery, sqlConnection);
                SqlDataReader dataReader = retrieveAllCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nEmployee Name:" + dataReader.GetString(0));
                    Console.Write("\tDepartment:" + dataReader.GetString(1));
                    Console.Write("\tSalary:" + dataReader.GetValue(2));
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Retrieve()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter the Employee Id you want to display");
                int EmpID = Convert.ToInt32(Console.ReadLine());
                string retrieveQuery = "Select * From Employee Where EmpID=" + EmpID;
                SqlCommand retrieveCommand = new SqlCommand(retrieveQuery, sqlConnection);
                SqlDataReader dataReader = retrieveCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nEmployee ID:" + dataReader.GetValue(0));
                    Console.Write("\tName:" + dataReader.GetString(1));
                    Console.Write("\t:Department ID:" + dataReader.GetValue(2));
                    Console.Write("\t:Salary ID:" + dataReader.GetValue(3));
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Update()
        {
            try
            {
                sqlConnection.Open();
                int EmpID;
                Console.WriteLine("Enter Employee ID that you want to modify:");
                EmpID =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name you want to modify:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Department ID you want to modify:");
                Console.WriteLine("1 for HR\n2 for Developer\n3 for Devops");
                int DepId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Salary ID you want to modify:");
                Console.WriteLine("1 for 9000\n2 for 45000\n3 for 35000");
                int SalId = Convert.ToInt32(Console.ReadLine());
                string updateQuery = "UPDATE Employee SET Name = '"+name+"', DepID = "+DepId+", SalID = "+SalId+" WHERE EmpID = "+EmpID+";";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Delete()
        {
            try
            {
                sqlConnection.Open();
                int EmpID;
                Console.WriteLine("Enter Employee ID that you want to delete:");
                EmpID = Convert.ToInt32(Console.ReadLine()); 
                string deleteQuery = "DELETE FROM Employee WHERE EmpID="+EmpID;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
