using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dot_net_web_api_project.Models;

namespace dot_net_web_api_project.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"
                        SELECT EmployeeID, EmployeeName, Department, MailID, CONVERT(varchar(10),DOJ,120) AS DOJ
                        FROM dbo.Employees;
                            ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(Employee employee)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"
                        INSERT INTO dbo.Employees (EmployeeName, Department, MailID, DOJ) VALUES (
                                '" + employee.EmployeeName + @"',
                                '" + employee.Department + @"',
                                '" + employee.MailID + @"',
                                '" + employee.DOJ + @"'
                                )";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dataTable);
                }
                return "Added Successfully";
            }
            catch(Exception ex)
            {
                return "Faild to Add";
            }
        }
    }
}
