using System;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using RestSharp;
using NLog;
using CalulatorService.Client.Request;

namespace Calculator
{
	public class Program
	{
		public static string id;
		public static string url = "http://localhost:53556/api/Calculator/";
		static void Main(string[] args)
		{
			//this is the menu

			Console.WriteLine("¿quieres hacer un traking de las operaciones (s/n)?");
			var y = Console.ReadLine();
			if (y.Equals("s"))
			{
				Console.WriteLine("dime tu id");
				id = Console.ReadLine();
			}
			int i=-1;
		do
			{
				//type of operation 
				Console.WriteLine("1. suma 2. resta 3.multi 4.dividir 5.raiz 6.journal 7.salir");

				//read an option 
				i = leer();

				string operationUrl = url;
				switch (i)
				{
					case 1:
						AddRequest add = new AddRequest();
						operationUrl = url + "Sum";
						add.Addends = leerArray();
						SendRequestAndReturnResponseWithTraking("Sum", operationUrl, add, id);
						i = -1;
						break;
					case 2:
						SubRequest sub = new SubRequest();
						operationUrl = url + "Diference";
						Console.WriteLine("introduce Minuend");
						sub.Minuend = leer();
						Console.WriteLine("introduce Minuend");
						sub.Subtrahend = leer();
						SendRequestAndReturnResponseWithTraking("Diference", operationUrl, sub, id);
						i = -1;

						break;
					case 3:
						MultRequest mult = new MultRequest();
						operationUrl = url + "Product";
						mult.Factors = leerArray();
						SendRequestAndReturnResponseWithTraking("Product", operationUrl, mult, id);
						i = -1;

						break;
					case 4:
						DivRequest div = new DivRequest();
						operationUrl = url + "Div";
						Console.WriteLine("introduce Dividend");
						div.Dividend = leer();
						Console.WriteLine("introduce Divisor");
						div.Divisor = leer();
						SendRequestAndReturnResponseWithTraking("Div", operationUrl, div, id);
						i = -1;

						break;
					case 5:
						SqrtRequest sqrt = new SqrtRequest();
						operationUrl = url + "Sqrt";
						Console.WriteLine("intro num");
						sqrt.Number = leer();
						SendRequestAndReturnResponseWithTraking("Sqrt", operationUrl, sqrt, id);
						i = -1;

						break;
					case 6:
						JournalRequest jour = new JournalRequest();
						operationUrl = url + "Journal";
						Console.WriteLine("dime id");
						jour.id = id;
						SendRequestAndReturnResponseWithTraking("Journal", operationUrl, jour, id);
						i = -1;
						break;
					case 7:
						Console.WriteLine("bye");
						break;
				}
			} while (!(i > 0 && i < 8));
		Console.ReadLine();
	}
	
	//method for reading an int
	public static int leer()
	{

		bool salir = false;
		var n = 0;
		do
		{
			try
			{
				n = int.Parse(Console.ReadLine());
				salir = true;
			}
			catch
			{
				salir = false;
				Console.WriteLine("mete un numero");
			}
		} while (salir == false);
		return n;
	}
	// method for reading an array
	public static int[] leerArray()
	{

		int tamanio = 0;
		Console.WriteLine("¿cuántos números quieres introducir?");
		do
		{
			tamanio = leer();
		} while (tamanio < 1);
		int[] numeros = new int[tamanio];
		for (int i = 0; i < numeros.Length; i++)
		{
			Console.WriteLine("intro numero");
			numeros[i] = leer();
		}


		return numeros;
	}
	//method for making a request and getting a response

	public static void SendRequestAndReturnResponseWithTraking(string nombre, string url, Object ob, string id)
	{
		var client = new RestClient(url);
		var request = new RestRequest(nombre, Method.POST);
		string json = JsonConvert.SerializeObject(ob);
		// 'application/json'
		request.AddJsonBody(json);
		if (!String.IsNullOrEmpty(id))
		{
			request.AddHeader("X-Evi-Tracking-Id", id);
		}
		var response = client.Execute(request);
		Console.WriteLine(response.Content);
	}

	}
}
