using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CalculatorService.Server.Models;
using CalulatorService.Server.Models;

namespace CalculatorService.Server.servicios
{
	interface IServicioOperaciones
	{
		AddResponse Sum(AddRequest request, string trakingId);
		SubResponse Diference(SubRequest request, string trakingId);
		MultResponse Product(MultRequest request, string trakingId);
		DivResponse Div(DivRequest request, string trakingId);
		SqrtResponse Sqrt(SqrtRequest request, string trakingId);

	}
}
