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
		AddResponse Sum(AddRequest request);
		SubResponse Diference(SubRequest request);
		MultiResponse Product(MultRequest request);
		DivResponse Div(DivRequest request);
		SqrtResponse Sqrt(SqrtRequest request);

	}
}
