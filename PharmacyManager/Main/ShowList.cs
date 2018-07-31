using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Main
{
	public class ShowList
	{
		static string connectionString = @"Integrated Security=SSPI;" +

										"Initial Catalog=Pharmacy;" +

										"Data Source=.\\SQLEXPRESS;";

		public static void ShowMed()
		{
			Console.Write("ID".PadLeft(5) + " |");
			Console.Write("Nazwa".ToString().PadLeft(15) + " |");
			Console.Write("Producent".ToString().PadLeft(15) + " |");
			Console.Write("Cena".ToString().PadLeft(15) + " |");
			Console.Write("Ilość".ToString().PadLeft(15) + " |");
			Console.Write("Na recepte?".ToString().PadLeft(15) + " |");
			Console.WriteLine();
			Console.WriteLine("".PadLeft(92, '-'));
			Console.WriteLine();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"SELECT * FROM Mediciness";
					connection.Open();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						var a = sqlDataReader.GetInt32(0);
						var b = sqlDataReader.GetString(1);
						var c = sqlDataReader.GetString(2);
						var d = sqlDataReader.GetDecimal(3);
						var e = sqlDataReader.GetInt32(4);
						var f = sqlDataReader.GetBoolean(5);
						Console.Write(a.ToString().PadLeft(5) + " |");
						Console.Write(b.ToString().PadLeft(15) + " |");
						Console.Write(c.ToString().PadLeft(15) + " |");
						Console.Write(d.ToString().PadLeft(15) + " |");
						Console.Write(e.ToString().PadLeft(15) + " |");
						Console.Write(f.ToString().PadLeft(15) + " |");
						Console.WriteLine();
					 
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();
		}

		public static void ShowOrd()
		{
			Console.Write("ID".PadLeft(5) + " |");
			Console.Write("ID Leku".ToString().PadLeft(15) + " |");
			Console.Write("ID Klienta".ToString().PadLeft(15) + " |");
			Console.Write("Data".ToString().PadLeft(15) + " |");
			Console.Write("Ilość".ToString().PadLeft(15) + " |");
			Console.WriteLine();
			Console.WriteLine("".PadLeft(80, '-'));
			Console.WriteLine();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"SELECT * FROM Orders";
					connection.Open();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						var a = sqlDataReader.GetInt32(0);
						var b = sqlDataReader.GetInt32(1);
						var c = sqlDataReader.GetInt32(2);
						var d = sqlDataReader.GetDateTime(3);
						var e = sqlDataReader.GetInt32(4);
						Console.Write(a.ToString().PadLeft(5) + " |");
						Console.Write(b.ToString().PadLeft(15) + " |");
						Console.Write(c.ToString().PadLeft(15) + " |");
						Console.Write(d.ToString().PadLeft(15) + " |");
						Console.Write(e.ToString().PadLeft(15) + " |");
						Console.WriteLine();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();
		}

		public static void ShowPrescript()
		{
			Console.Write("ID".PadLeft(5) + " |");
			Console.Write("Nazwa Klienta".ToString().PadLeft(15) + " |");
			Console.Write("PESEL".ToString().PadLeft(15) + " |");
			Console.Write("Numer recepty".ToString().PadLeft(15) + " |");
			Console.WriteLine();
			Console.WriteLine("".PadLeft(80, '-'));
			Console.WriteLine();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"SELECT * FROM Prescriptions";
					connection.Open();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						var a = sqlDataReader.GetInt32(0);
						var b = sqlDataReader.GetString(1);
						var c = sqlDataReader.GetString(2);
						var d = sqlDataReader.GetString(3);
						Console.Write(a.ToString().PadLeft(5) + " |");
						Console.Write(b.ToString().PadLeft(15) + " |");
						Console.Write(c.ToString().PadLeft(15) + " |");
						Console.Write(d.ToString().PadLeft(15) + " |");
						Console.WriteLine();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();
		}

	}
 
}
