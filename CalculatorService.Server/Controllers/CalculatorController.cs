using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalulatorService.Server.Models;
using CalculatorService.Server.Models;
using CalculatorService.Server.servicios;
using NLog;
using RestSharp;

namespace CalculatorService.Server.Controllers
{

    public class CalculatorController : ApiController
    {
		public static servicioOPeraciones servicio = new servicioOPeraciones();
		public static ILogger log = LogManager.GetCurrentClassLogger();

		// POST: api/Default/Sum
		[HttpPost]
		public IHttpActionResult Sum(AddRequest request)
        {			
			log.Info("this is the controller -> Sum");
			if (request == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				return BadRequest();
			}

			var id = Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault();

			var res = servicio.Sum(request, id);
			return Ok(res);

		}

		// POST: api/Default/Product
		[HttpPost]
		public IHttpActionResult Product(MultRequest request)
		{
			log.Info("this is the controller -> Mult");

			if (request == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var id = Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault();

			var res = servicio.Product(request,id);
			return Ok(res);

		}

		// POST: api/Default/Div
		[HttpPost]
		public IHttpActionResult Div(DivRequest request)
		{
			log.Info("this is the controller -> Div");

			if (request == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var id = Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault();

			var res = servicio.Div(request,id);
			return Ok(res);
		}

		// POST: api/Default/Diference
		[HttpPost]
		public IHttpActionResult Diference(SubRequest request)
		{
			log.Info("this is the controller -> Difference");

			if (request == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var id = Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault();

			var res = servicio.Diference(request,id);
			return Ok(res);
		}

		// POST: api/Default/Sqrt
		[HttpPost]
		public IHttpActionResult Sqrt(SqrtRequest request)
		{
			log.Info("this is the controller -> Sqrt");
			if (request == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				return BadRequest();
			}
			var id = Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault();

			var res = servicio.Sqrt(request,id);
			return Ok(res);

		}

		// POST: api/Default/Journal
		[HttpPost]
		public IHttpActionResult Journal(JournalRequest request)
		{
			IEnumerable<string> trackingId;
			Request.Headers.TryGetValues("X-Evi-Tracking-Id", out trackingId);
			
			var res = servicio.Journal(request);

			return Ok(res);

		}

	}
}
