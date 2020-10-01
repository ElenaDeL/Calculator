using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Calculator
{
	public class Operacion
	{
		public ArrayList numeros;
		public string operacion;

		public Operacion () { }

		public Operacion(ArrayList numeros, String operacion) {

			this.numeros = numeros;
			this.operacion = operacion;

		}
	}
}
