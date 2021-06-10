using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using dot_net_web_api_project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dot_net_web_api_project.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            string query = @"
                        SELECT DepartmentID, DepartmentName FROM dbo.Departments
                            ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString)) 
            using (var cmd = new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dataTable);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        public string Post(Department department)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"
                        INSERT INTO dbo.Departments VALUES ('" + department.DepartmentName + @"')
                            ";
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
