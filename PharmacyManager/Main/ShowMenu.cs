using System;

namespace Main
{
	public class ShowMenu
	{
		public static void MainMenu()
		{
			Logo();
			ConsoleEx.WriteLine("Main Menu".PadLeft(55, ' '), ConsoleColor.Green);
			OptionsMain();
		}

		public static void MenuSell()
		{
			Logo();
			ConsoleEx.WriteLine("Sell Module".PadLeft(54, ' '), ConsoleColor.Green);
			
		}

		public static void MenuEdit()
		{
			Logo();
			ConsoleEx.WriteLine("Edit Module".PadLeft(54, ' '), ConsoleColor.Green);
			OptionsEdit();
		}

		public static void MenuList()
		{
			Logo();
			ConsoleEx.WriteLine("List of Medicines".PadLeft(54, ' '), ConsoleColor.Green);
			OptionsList();
		} 

		public static void Logo()
		{
			Console.WriteLine("".PadLeft(100, '*'));
			Console.Write("".PadLeft(42, '*'));
			ConsoleEx.Write("PHARMACY MANAGER", ConsoleColor.Yellow);
			Console.WriteLine("".PadLeft(42, '*'));
			Console.WriteLine("".PadLeft(100, '*'));
		}

		public static void OptionsMain()
		{
			ConsoleEx.WriteLine("DOSTĘPNE KOMENDY:", ConsoleColor.Blue);
			Console.WriteLine("SellModule (sm) - Moduł sprzedaży leków");
			Console.WriteLine("EditModule (em) - Moduł edycji bazy leków");
			Console.WriteLine("ShowList (sl) - Pokaż liste leków");
			Console.WriteLine("exit - Wyjście z programu ");
		}

		public static void OptionsSell()
		{
			ConsoleEx.WriteLine("DOSTĘPNE KOMENDY:", ConsoleColor.Blue);
			Console.WriteLine("Add (ad) - Dodaj lek do rachunku");
			Console.WriteLine("Delete (de) - Usuń lek z rachunku");
			Console.WriteLine("Confirm (cm) - Dodanie rachunku do bazy");
			Console.WriteLine("return - Powrót");
		}

		public static void OptionsEdit()
		{
			ConsoleEx.WriteLine("DOSTĘPNE KOMENDY:", ConsoleColor.Blue);
			Console.WriteLine("Add (ad) - Dodaj lek do bazy");
			Console.WriteLine("Delete (de) - Usuń lek z bazy");
			Console.WriteLine("EditQuantity (eq) - Zmień ilość leku w bazie");
			Console.WriteLine("ShowList (sh) - Pokaż liste leków w bazie");
			Console.WriteLine("return - Powrót");
		}

		public static void OptionsList()
		{
			ConsoleEx.WriteLine("DOSTĘPNE KOMENDY:", ConsoleColor.Blue);
			Console.WriteLine("Medicines (me) - Pokaż liste leków");
			Console.WriteLine("Orders (or) - Pokaż liste zamówień");
			Console.WriteLine("Prescriptions (pr) - Pokaż liste recept/klientów");
			Console.WriteLine("return - Powrót");
		}

	}
}
