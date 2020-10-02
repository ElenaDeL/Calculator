using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorService.Server.Models
{
	public class Operation
	{
		public string name { get; set; }
		public string calculation { get; set; }
		public DateTime date{ get; set; }
	}
}