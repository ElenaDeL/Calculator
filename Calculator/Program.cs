using System;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using RestSharp;
using CalculatorService.Server.Models;

namespace Calculator
{
	public class Program
	{

		static void Main(string[] args)
		{
			
				// MENU
				int i;
				do
				{
				//TIPO DE OPERACION CON LA RUTA
					Console.WriteLine("1. suma 2. resta 3.multi 4.dividir 5.raiz 6.salir");
					i = int.Parse(Console.ReadLine());
					switch (i)
					{
						case 1:						
							var cabecera= "Sum";
							string url = "http://localhost:53556/api/default/Sum";
							AddRequest add = new AddRequest();
							add.Addends = new int[] { 2, 2, 3 };
							SendRequestAndReturnResponse(cabecera, url,add);
							break;
						case 2:
							var cabecera1 = "Diference";
							string url1 = "http://localhost:53556/api/default/Diference";
							SubRequest sub = new SubRequest();
							sub.Minuend = 3;
							sub.Subtrahend = -7;
							SendRequestAndReturnResponse(cabecera1,url1, sub);
						break;
						case 3:
							var cabecera2 = "Product";
							string url2 = "http://localhost:53556/api/default/Product";
							MultRequest mult = new MultRequest();
							mult.Factors = new int[] {8,3,2};
							SendRequestAndReturnResponse(cabecera2, url2, mult);

						break;
						case 4:
							var cabecera3 = "Div";
							string url3 = "http://localhost:53556/api/default/Div";
							DivRequest div = new DivRequest();
							div.Dividend = 11;
							div.Divisor = 2;
							SendRequestAndReturnResponse(cabecera3, url3, div);
						break;
						case 5:
							var cabecera4 = "Div";
							string url4 = "http://localhost:53556/api/default/Sqrt";
							SqrtRequest sqrt = new SqrtRequest();
							sqrt.Number = 16;
							SendRequestAndReturnResponse(cabecera4, url4, sqrt);
						break;
						case 6:
							break;
					}

				} while (i != 6);
				
			Console.ReadLine();

		}

		//OBTIENE NUMEROS DE LA CONSOLA DEL USUARIO
		public static void pedirnum(string url) {

			string n;
			int num;
			int resultado =0;
			string e;
			int[] numeros = new int[5];

			//meto los numeros en el array de operacion
			do
			{
				Console.WriteLine("intro numeros a sumar");
				e = Console.ReadLine();
				num = int.Parse(e);
				numeros = new int[] { num };
				Console.WriteLine("más? (s/n)");
				n = Console.ReadLine();
			} while (!n.Equals("n"));



			Console.WriteLine($"El resultado es: {resultado}");		
		}

		public static void SendRequestAndReturnResponse(string nombre, string url, Object ob)
		{			
			var client = new RestClient(url);
			var request = new RestRequest(nombre, Method.POST);
			string json = JsonConvert.SerializeObject(ob);
			// 'application/json'
			request.AddJsonBody(json);
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}

	}
}
