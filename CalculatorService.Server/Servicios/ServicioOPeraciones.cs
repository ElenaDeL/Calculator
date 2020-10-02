using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;
using CalulatorService.Server.Models;
using NLog;
using System.Net;
using System.Web.Mvc;
using System.Collections.Specialized;
using RestSharp;

namespace CalculatorService.Server.servicios
{
	//service : logic business . Implements Interface of methods
	public class servicioOPeraciones : IServicioOperaciones
	{
		public static ILogger log = LogManager.GetCurrentClassLogger();
		public List<KeyValuePair<string, Operation>> JournalList = new List<KeyValuePair<string, Operation>>();

		public SubResponse Diference(SubRequest request, string trakingId)
		{
			log.Trace("this is the service -> Difference");
			SubResponse sub = new SubResponse();

			try
			{
				sub.Difference = request.Minuend - request.Subtrahend;
				log.Trace(HttpStatusCode.OK);

				if (trakingId != null)
				{
					var op = new Operation()
					{
						name = "Difference",
						date = DateTime.Now,
						calculation = ""
					};
					JournalList.Add(new KeyValuePair<string, Operation>(trakingId, op));
				}
			}
			catch (Exception e)
			{
				log.Error(HttpStatusCode.InternalServerError);
				log.Error("Error in the controller Difference " + e);
				throw new Exception();
			}

			return sub;
		}

		public DivResponse Div(DivRequest request, string trakingId)
		{

			log.Trace("this is the service -> Div");
			DivResponse div = new DivResponse();

			try
			{
				var result = request.Dividend / request.Divisor;
				var result1 = request.Dividend % request.Divisor;
				div.Quotient = result;
				div.Remainder = result1;
				log.Trace(HttpStatusCode.OK);

				if (trakingId != null)
				{
					var op = new Operation()
					{
						name = "Div",
						date = DateTime.Now,
						calculation = ""
					};
					JournalList.Add(new KeyValuePair<string, Operation>(trakingId, op));
				}
			}
			catch (Exception e)
			{
				log.Error("Error in the controller Div " + e);
				log.Error(HttpStatusCode.InternalServerError);
				throw new Exception();

			}
			return div;
		}

		public MultResponse Product(MultRequest request, string trakingId)
		{

			log.Trace("this is the service -> Product");
			MultResponse mult = new MultResponse();
			try
			{

				int result = 1;
				foreach (int i in request.Factors)
				{
					mult.Product = result *= i;
				}
				log.Trace(HttpStatusCode.OK);
				if (trakingId != null)
				{
					var op = new Operation()
					{
						name = "Product",
						date = DateTime.Now,
						calculation = ""
					};
					JournalList.Add(new KeyValuePair<string, Operation>(trakingId, op));
				}


			}
			catch (Exception e)
			{
				log.Error("Error in the controller Product " + e);
				log.Error(HttpStatusCode.InternalServerError);
				throw new Exception();
			}


			return mult;
		}

		public SqrtResponse Sqrt(SqrtRequest request, string trakingId)
		{
			log.Trace("this is the service -> Sqrt");
			SqrtResponse sqrt = new SqrtResponse();
			try
			{

				sqrt.Square = (int)Math.Sqrt(request.Number);
				log.Trace(HttpStatusCode.OK);
				if (trakingId != null)
				{
					var op = new Operation()
					{
						name = "Sqrt",
						date = DateTime.Now,
						calculation = ""
					};
					JournalList.Add(new KeyValuePair<string, Operation>(trakingId, op));
				}

			}
			catch (Exception e)
			{
				log.Error("Error in the controller Sqrt " + e);
				log.Error(HttpStatusCode.InternalServerError);
				throw new Exception();

			}
			return sqrt;

		}

		public AddResponse Sum(AddRequest request, string trakingId)
		{
			log.Trace("this is the service ->Sum");

			AddResponse add = new AddResponse();
			try
			{
				int result = 0;

				foreach (int i in request.Addends)
				{
					add.Sum = result += i;
				}
				log.Trace(HttpStatusCode.OK);

				if (trakingId != null)
				{
					var op = new Operation()
					{
						name = "Sum",
						date = DateTime.Now,
						calculation = ""
					};
					JournalList.Add(new KeyValuePair<string, Operation>(trakingId, op));
				}
			}
			catch (Exception e)
			{
				log.Error("Error in the controller Sum " + e);
				log.Error(HttpStatusCode.InternalServerError);
				throw new Exception();
			}

			return add;
		}

		public JournalResponse Journal(JournalRequest request)
		{
			log.Trace("this is the service ->Journal");
			JournalResponse jour = new JournalResponse();
			DateTime date = DateTime.Now;

			//objeto Operaction : name, calculation, date
			Operation op = new Operation();
			op.date = date;
			op.name = "Journal";

			//Request id and make a Operation for the response
			if (!string.IsNullOrEmpty(request.id))
			{
				//adding the key  =id and the object Operation
				JournalList.Add(new KeyValuePair<string, Operation>(request.id, op));		
			}

			// buscar en el journallist los que coinciden con el id
			var matches = JournalList.Where(x => x.Key == request.id).Select(z => z.Value).ToList();
			jour.Operations = matches;

			return jour;

		}

	}
}