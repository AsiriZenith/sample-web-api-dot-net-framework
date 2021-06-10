using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dot_net_web_api_project.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("DepID");
            dataTable.Columns.Add("DepName");

            dataTable.Rows.Add(1, "IT");
            dataTable.Rows.Add(2, "Support");

            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
