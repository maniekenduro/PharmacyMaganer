using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Main
{
	class EditModule
	{
		static string connectionString = @"Integrated Security=SSPI;" +
										 "Initial Catalog=Pharmacy;" +
										 "Data Source=.\\SQLEXPRESS;";

		public static void AddEM()
		{
			Console.Write("Podaj nazwę leku: ");
			string name = Console.ReadLine().Trim();

			Console.Write("Podaj nazwę producenta: ");
			string manufacturer = Console.ReadLine().Trim();

			Console.Write("Podaj cenę leku: ");
			decimal price = Decimal.Parse(Console.ReadLine().Trim());

			Console.Write("Podaj ilość: ");
			string amountstr = Console.ReadLine().Trim();
			int amount = Int32.Parse(amountstr);
			Console.Write("Czy jest to lek na recepte [T/N]: ");
			string withPrescriptionstr = Console.ReadLine().Trim().ToLower();
			bool withPrescription;
			if (withPrescriptionstr == "t")
			{
				withPrescription = true;
			}
			else if (withPrescriptionstr == "n")
			{
				withPrescription = false;
			}
			else
			{
				withPrescription = false;
				Console.WriteLine("Podano zła Komende. Przyjęto N");
			}
			
			Medicine medicine = new Medicine(name, manufacturer, price, amount, withPrescription);
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"INSERT INTO Mediciness (Name, Manufacturer, Price, Amount, WithPrescription)
											VALUES (@Name, @Manufacturer, @Price, @Amount, @WithPrescription);";

					var sqlNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Name,
						ParameterName = "@Name"
					};

					var sqlManufacturerParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = medicine.Manufacturer,
						ParameterName = "@Manufacturer"
					};

					var sqlPriceParam = new SqlParameter
					{
						DbType = System.Data.DbType.Decimal,
						Value = medicine.Price,
						ParameterName = "@Price"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = medicine.Amount,
						ParameterName = "@Amount"
					};

					var sqlWithPrescriptionParam = new SqlParameter
					{
						DbType = System.Data.DbType.Boolean,
						Value = medicine.WithPrescription,
						ParameterName = "@WithPrescription"
					};

					sqlCommand.Parameters.Add(sqlNameParam);
					sqlCommand.Parameters.Add(sqlManufacturerParam);
					sqlCommand.Parameters.Add(sqlPriceParam);
					sqlCommand.Parameters.Add(sqlAmountParam);
					sqlCommand.Parameters.Add(sqlWithPrescriptionParam);
					connection.Open();
					sqlCommand.ExecuteNonQuery();
					connection.Close();
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static void DeleteEM()
		{
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("Name (n) - usunięcie leku podając jego nazwę");
			Console.WriteLine("ID (i) - usunięcie leku podając jego ID");
			string x = Console.ReadLine().Trim();
			if (x == "Name" || x=="n")
			{
				try
				{
					Console.Write("Podaj nazwe leku do usunięcia: ");
					string name = Console.ReadLine().Trim();
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText =

							@"DELETE FROM Mediciness WHERE Name = @Name;";

						var sqlIdParam = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = name,
							ParameterName = "@Name"
						};

						sqlCommand.Parameters.Add(sqlIdParam);
						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
						Console.WriteLine("Akcja wykonana prawidłowo");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else if (x == "ID" || x == "i")
			{
				try
				{
					Console.Write("Podaj id leku do usunięcia: ");
					int id = Int32.Parse(Console.ReadLine().Trim());
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText =

							@"DELETE FROM Mediciness WHERE ID = @id;";

						var sqlIdParam = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = id,
							ParameterName = "@id"
						};

						sqlCommand.Parameters.Add(sqlIdParam);
						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
						Console.WriteLine("Akcja wykonana prawidłowo");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.WriteLine("Podano zła Komende.");
			}
		}

		public static void EditQuantityEM()
		{
			Console.WriteLine("Wybierz opcje: ");
			Console.WriteLine("Name (n) - edycja leku podając jego nazwę");
			Console.WriteLine("ID (i) - edycja leku podając jego ID");
			string x = Console.ReadLine().Trim();
			if (x == "Name" || x == "n")
			{
				try
				{
					Console.Write("Podaj nazwe leku do edycji: ");
					string name = Console.ReadLine().Trim();
					Console.Write("Podaj nową ilość leku: ");
					int amount = Int32.Parse(Console.ReadLine().Trim());
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText =

							@"UPDATE Mediciness Set Amount = @amount WHERE Name = @Name;";

						var sqlIdParam1 = new SqlParameter
						{
							DbType = System.Data.DbType.AnsiString,
							Value = name,
							ParameterName = "@Name"
						};
						var sqlIdParam2 = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = amount,
							ParameterName = "@amount"
						};

						sqlCommand.Parameters.Add(sqlIdParam1);
						sqlCommand.Parameters.Add(sqlIdParam2);
						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
						Console.WriteLine("Akcja wykonana prawidłowo");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else if (x == "ID" || x == "i")
			{
				try
				{
					Console.Write("Podaj id leku do edycji: ");
					int id = Int32.Parse(Console.ReadLine().Trim());
					Console.Write("Podaj nową ilość leku: ");
					int amount = Int32.Parse(Console.ReadLine().Trim());
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText =

							@"UPDATE Mediciness Set Amount = @amount WHERE ID = @id;";

						var sqlIdParam1 = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = id,
							ParameterName = "@id"
						};
						var sqlIdParam2 = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = amount,
							ParameterName = "@amount"
						};

						sqlCommand.Parameters.Add(sqlIdParam1);
						sqlCommand.Parameters.Add(sqlIdParam2);
						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
						Console.WriteLine("Akcja wykonana prawidłowo");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.WriteLine("Podano zła Komende.");
			}
		}


		public static void ShowEM()
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
					sqlCommand.CommandText = @"SELECT * FROM Mediciness;";
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
	}
}
