using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using WebApplication1.Models;
using WebApplication1.servicios;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class OperacionesController : ApiController
    {

		public static servicioOPeraciones operatorService;
		public static AddRequest request;


		// POST: api/Operaciones
		[HttpPost]
		public int Sum(AddRequest request)
		{
			//int result = 0;
/*
			foreach (int i in request.Sumandos)
			{
				result += i;
			}*/

			//var result = operatorService.suma();


			return result;
	//	}


	
//	}

}
