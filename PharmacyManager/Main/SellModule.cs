using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Main
{
	public class SellModule
	{
		static string connectionString = @"Integrated Security=SSPI;" +

										"Initial Catalog=Pharmacy;" +

										"Data Source=.\\SQLEXPRESS;";

		

		public static void ShowSM(List<Medicine> listmed)
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

			foreach (var med in listmed)
			{
				Console.Write($"{med.ID}".PadLeft(5) + " |");
				Console.Write($"{med.Name}".ToString().PadLeft(15) + " |");
				Console.Write($"{med.Manufacturer}".ToString().PadLeft(15) + " |");
				Console.Write($"{med.Price}".ToString().PadLeft(15) + " |");
				Console.Write($"{med.Amount}".ToString().PadLeft(15) + " |");
				Console.Write($"{med.WithPrescription}".ToString().PadLeft(15) + " |");
				Console.WriteLine();
			}
		}

		public static void SummarySM(List<Medicine> listmed)
		{
			try
			{
				Console.WriteLine("".PadLeft(92, '_'));
				ConsoleEx.WriteLine("Podsumowanie zamówienia:", ConsoleColor.DarkYellow);
				decimal sum = 0;
				foreach (var med in listmed)
				{
					sum += (med.Price * med.Amount);
				}
				Console.Write(" - Suma do zapłaty: " + sum + " złotych");
				Console.WriteLine();
				Console.WriteLine("".PadLeft(92, '_'));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		
		public static void AddSM(List<Medicine> listmed, List<Order> listrorder, List<Prescription> listprescript)
		{
			int prescriptionId = 0;
			Console.Write("Czy klient posiada recepte? [T/N]");
			string x = Console.ReadLine().Trim();
			Console.WriteLine();
			if (x == "t")
			{
				Console.Write("Podaj nazwisko klienta: ");
				string custname = Console.ReadLine().Trim();

				Console.Write("Podaj numer PESEL: ");
				string pesel = Console.ReadLine().Trim();

				Console.Write("Podaj numer klienta: ");
				string custnr = Console.ReadLine().Trim();

				Prescription prescription = new Prescription(custname, pesel, custnr);
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText = @"INSERT INTO Prescriptions (CustomerName, PESEL, PrescriptionNumber)
											VALUES (@CustomerName, @PESEL, @PrescriptionNumber);";

						var sqlCustomerNameParam = new SqlParameter
						{
							DbType = System.Data.DbType.AnsiString,
							Value = prescription.CustomerName,
							ParameterName = "@CustomerName"
						};

						var sqlPESELParam = new SqlParameter
						{
							DbType = System.Data.DbType.AnsiString,
							Value = prescription.PESEL,
							ParameterName = "@PESEL"
						};

						var sqlPrescriptionNumberParam = new SqlParameter
						{
							DbType = System.Data.DbType.AnsiString,
							Value = prescription.PrescriptionNumber,
							ParameterName = "@PrescriptionNumber"
						};

						sqlCommand.Parameters.Add(sqlCustomerNameParam);
						sqlCommand.Parameters.Add(sqlPESELParam);
						sqlCommand.Parameters.Add(sqlPrescriptionNumberParam);

						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				prescriptionId = Int32.Parse(custnr);
			}

			else
			{
				prescriptionId = 0;
			}

			int id = 0;
			do
			{
				Console.Write("Podaj id leku do zakupu: ");
				id = Int32.Parse(Console.ReadLine().Trim());
			}
			while (!CheckMed(id));

			int amount = 0;
			do
			{
				Console.Write("Podaj ilość: ");
				
				amount = Int32.Parse(Console.ReadLine().Trim());

				
			}
			while (!CheckAmount(id, amount));

			listrorder.Add(new Order(id, prescriptionId , DateTime.Now, amount));

			listmed.Add(GetMedByID(id, amount));

		   
		}
   	   
		public static Medicine GetMedByID(int id, int amount)
		{	
			
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"SELECT * FROM Mediciness where ID = @id";

					var sqlIDParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@id"
					};
					connection.Open();
					sqlCommand.Parameters.Add(sqlIDParam);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

					while (sqlDataReader.Read())
					{
						return new Medicine(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDecimal(3), amount, sqlDataReader.GetBoolean(5));
						
					}
					return new Medicine(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDecimal(3), amount, sqlDataReader.GetBoolean(5));

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}



		public static void AddPres()
		{
			Console.Write("Podaj nazwisko klienta: ");
			string custname = Console.ReadLine().Trim();

			Console.Write("Podaj numer PESEL: ");
			string pesel = Console.ReadLine().Trim();

			Console.Write("Podaj numer klienta: ");
			string custnr = Console.ReadLine().Trim();

			Prescription prescription = new Prescription(custname, pesel, custnr);
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"INSERT INTO Prescriptions (CustomerName, PESEL, PrescriptionNumber)
											VALUES (@CustomerName, @PESEL, @PrescriptionNumber);";

					var sqlCustomerNameParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = prescription.CustomerName,
						ParameterName = "@CustomerName"
					};

					var sqlPESELParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = prescription.PESEL,
						ParameterName = "@PESEL"
					};

					var sqlPrescriptionNumberParam = new SqlParameter
					{
						DbType = System.Data.DbType.AnsiString,
						Value = prescription.PrescriptionNumber,
						ParameterName = "@PrescriptionNumber"
					};

					sqlCommand.Parameters.Add(sqlCustomerNameParam);
					sqlCommand.Parameters.Add(sqlPESELParam);
					sqlCommand.Parameters.Add(sqlPrescriptionNumberParam);

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

		public static bool CheckAmount(int id, int amount)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"select * from Mediciness where ID = @Id and Amount >= @Amount;";

					var sqlIDParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@Id"
					};

					var sqlAmountParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = amount,
						ParameterName = "@Amount"
					};

					sqlCommand.Parameters.Add(sqlIDParam);
					sqlCommand.Parameters.Add(sqlAmountParam);
					connection.Open();

					int userCount = (int)sqlCommand.ExecuteScalar();
					if (userCount > 0)
					{

					}
					return true;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		
		public static bool CheckMed(int id)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"select * from Mediciness where ID = @Id;";

					var sqlIDParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = id,
						ParameterName = "@Id"
					};

					sqlCommand.Parameters.Add(sqlIDParam);
					connection.Open();

					int userCount = (int)sqlCommand.ExecuteScalar();
					if (userCount > 0)
					{
						
					}
					return true;
				}
			}
			catch (Exception e)
			{

				return false;
			}

		}


		public static bool CheckPresc(Medicine medicine)
		{
			bool a = false;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var sqlCommand = new SqlCommand();
					sqlCommand.Connection = connection;
					sqlCommand.CommandText = @"select WITHPRESCRIPTION from Mediciness where ID = @id";

					var sqlIDParam = new SqlParameter
					{
						DbType = System.Data.DbType.Int32,
						Value = medicine.ID,
						ParameterName = "@id"
					};

					sqlCommand.Parameters.Add(sqlIDParam);
					connection.Open();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						a = sqlDataReader.GetBoolean(0);
						
					}
					
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				
			}
			return a;
		}

		public static void DeleteSM(List<Medicine> listmed)
		{
			try
			{
				Console.Write("Podaj id leku do usunięcia: ");
				int id = Int32.Parse(Console.ReadLine().Trim());
				foreach (var med in listmed)
				{
					if (med.ID == id)
					{
						listmed.Remove(med);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		
		public static void ConfirmSM(List<Medicine> listmed, List<Order> listrorder)
		{
			foreach(var med in listmed)
			{
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText =

							@"UPDATE Mediciness Set Amount = Amount - @amount WHERE ID = @id;";

						var sqlIdParam1 = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = med.ID,
							ParameterName = "@id"
						};
						var sqlIdParam2 = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = med.Amount,
							ParameterName = "@amount"
						};

						sqlCommand.Parameters.Add(sqlIdParam1);
						sqlCommand.Parameters.Add(sqlIdParam2);
						connection.Open();
						sqlCommand.ExecuteNonQuery();
						connection.Close();
						Console.WriteLine($"Sprzedano {med.Name} w ilości sztuk {med.Amount}");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			foreach(var ord in listrorder)
			{
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						var sqlCommand = new SqlCommand();
						sqlCommand.Connection = connection;
						sqlCommand.CommandText = @"INSERT INTO Orders (MedicineID, PrescriptionID, Date, Amount)
											VALUES (@MedicineID, @PrescriptionID , @Date, @Amount);";

						var sqlMedicineIDParam = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = ord.MedicineID,
							ParameterName = "@MedicineID"
						};

						var sqlPresciptionrParam = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = ord.PrescriptionID,
							ParameterName = "@PrescriptionID"
						};

						var sqlDateParam = new SqlParameter
						{
							DbType = System.Data.DbType.Date,
							Value = ord.Date,
							ParameterName = "@Date"
						};

						var sqlAmountParam = new SqlParameter
						{
							DbType = System.Data.DbType.Int32,
							Value = ord.Amount,
							ParameterName = "@Amount"
						};
						sqlCommand.Parameters.Add(sqlMedicineIDParam);
						sqlCommand.Parameters.Add(sqlPresciptionrParam);
						sqlCommand.Parameters.Add(sqlDateParam);
						sqlCommand.Parameters.Add(sqlAmountParam);
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
			Console.ReadKey();

		}



	}
}
