using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalculatorService.Server.Models;
using CalulatorService.Server.Models;

namespace CalculatorService.Server.servicios
{
	public class servicioOPeraciones 
	{
		public SubResponse Diference(SubRequest request)
		{
			SubResponse sub = new SubResponse();
			sub.Diference =  request.Minuend - request.Subtrahend;
			return sub;
		}

		public DivResponse Div(DivRequest request)
		{
			DivResponse div = new DivResponse();
		
			
			var result = request.Dividend / request.Divisor;
			var result1 = request.Dividend % request.Divisor;
			div.Quotient = result;
			div.Remainder = result1;

			return div;
		}

		public MultResponse Product(MultRequest request)
		{
			MultResponse mult = new MultResponse();

			int result = 1;

			foreach (int i in request.Factors)
			{
				mult.Product= result *= i;
			}

			return mult;
		}

		public SqrtResponse Sqrt(SqrtRequest request)
		{
			SqrtResponse sqrt = new SqrtResponse();
			sqrt.Square = (int)Math.Sqrt(request.Number);
			return sqrt;

		}

		public AddResponse Sum(AddRequest request)
		{
			AddResponse add = new AddResponse();
			int result = 0;

			foreach (int i in request.Addends)
			{
				add.Addens=	result += i;
			}
			
			return add;
		}


	}
}