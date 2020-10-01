using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.servicios
{
	public class servicioOPeraciones : IServicioOperaciones
	{
	

		public int suma(int[] numeros)
		{
			var resultado = 0;
			for (int i = 0; i < numeros.Length; i++)
				resultado += numeros[i];

			return resultado;
		}
	}
}