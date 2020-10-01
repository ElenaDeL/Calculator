using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalulatorService.Server.Models;
using CalculatorService.Server.Models;
using CalculatorService.Server.servicios;

namespace CalculatorService.Server.Controllers
{

    public class DefaultController : ApiController
    {
		public static servicioOPeraciones servicio = new servicioOPeraciones();
     

		// POST: api/Default/Sum
		[HttpPost]
		public AddResponse Sum(AddRequest request)
        {	
			
			return servicio.Sum(request);

		}

		// POST: api/Default/Product
		[HttpPost]
		public MultResponse Product(MultRequest request)
		{
			return servicio.Product(request);

		}

		// POST: api/Default/Div
		[HttpPost]
		public DivResponse Div(DivRequest request)
		{

			return servicio.Div(request);
		}

		// POST: api/Default/Diference
		[HttpPost]
		public SubResponse Diference(SubRequest request)
		{
			return servicio.Diference(request);

		}

		// POST: api/Default/Sqrt
		[HttpPost]
		public SqrtResponse Sqrt(SqrtRequest request)
		{
			return servicio.Sqrt(request);

		}

	}
}
