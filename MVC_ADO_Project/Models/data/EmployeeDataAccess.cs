using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MVC_ADO_Project.Models.data
{
    public class EmployeeDataAccess
    {
        DbConnection connection;
        public EmployeeDataAccess()
        {
            connection = new DbConnection();
        }

        public List<Employee>GetEmployeeList()
        {
            string sp = "SP_EMPLOYEE"; // define procedure name
            SqlCommand sql = new SqlCommand(sp,connection.Connection); //create instance of sql command, procedure variable nd connection in parameter
            sql.CommandType = CommandType.StoredProcedure;  //delere command type like store procedure
            sql.Parameters.AddWithValue("@action", "JOIN"); //passed here action and condition
            if(connection.Connection.State==ConnectionState.Closed) // if for connection close or open
            {
                sql.Connection.Open();
            }
            SqlDataReader dr=sql.ExecuteReader(); //sqldatareader and executereader
            List<Employee> employees = new List<Employee>(); // get values in list
            while(dr.Read())
            {
                Employee emp=new Employee();
                emp.id = (int)dr["id"];
                emp.Name = (string)dr["name"];   //Data Mapping from database
                emp.Age = (int)dr["age"];
                emp.Salary = (int)dr["salary"];
                emp.Department = dr["department"].ToString();
                employees.Add(emp);
            }
            connection.Connection.Close();
            return employees;

        }
    }
}
