using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

		// POST: api/Default/Add/AddRequest
		[HttpPost]
		public int Sum(AddRequest request)
        {
			int result = 0;

			foreach (int i in request.Addends)
			{
				result += i;
			}

			return result;

		}

		// POST: api/Default/Sub/SubRequest
		[HttpPost]
		public int Diference(SubRequest request)
		{
			int result = 0;

			result = request.Minuend - request.Subtrahend;

			return result;

		}

		// PUT: api/Default/5
		public void Put(int id, string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
