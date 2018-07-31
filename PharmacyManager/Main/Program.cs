using System;
using System.Collections.Generic;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowMenu.MainMenu();
			string command = "";
			do
			{
				ConsoleEx.Write("Podaj komende: ", ConsoleColor.Blue);
				command = Console.ReadLine();
				switch (command)
				{
					case "SellModule":
					case "sm":
						SellModuleView();
						ShowMenu.MainMenu();
						break;

					case "EditModule":
					case "em":
						EditModuleView();
						ShowMenu.MainMenu();
						break;

					case "Showlist":
					case "sl":
						ShowListView();
						ShowMenu.MainMenu();
						break;

					case "exit":
						Console.Clear();
						ShowMenu.MainMenu();
						break;

					default:
						Console.Clear();
						ShowMenu.MainMenu();
						ConsoleEx.WriteLine("Nie rozpoznano polecenia", ConsoleColor.Red);
						break;
				}
			}
			while (command != "exit");
		}

		public static void SellModuleView()
		{
			List<Medicine> listmed = new List<Medicine>();
			List<Order> listrorder = new List<Order>();
			List<Prescription> listprescript = new List<Prescription>();
			string command = "";
			do
			{
				Console.Clear();
				ShowMenu.MenuSell();
				SellModule.ShowSM(listmed);
				SellModule.SummarySM(listmed);
				ShowMenu.OptionsSell();
				ConsoleEx.Write("Podaj komende: ", ConsoleColor.Blue);
				command = Console.ReadLine();
				switch (command)
				{
					case "Add":
					case "ad":
						SellModule.AddSM(listmed, listrorder, listprescript);
						Console.Clear();
						break;

					case "Delete":
					case "de":
						SellModule.DeleteSM(listmed);
						Console.Clear();
						break;
					
					case "Confirm":
					case "cm":
						SellModule.ConfirmSM(listmed, listrorder, listprescript);
						Console.Clear();
						break;

					case "return":
						Console.Clear();
						break;

					default:
						ConsoleEx.WriteLine("nie rozpoznano polecenia", ConsoleColor.Red);
						break;
				}
			}
			while (command != "return");
		}

		public static void EditModuleView()
		{
			string command = "";
			do
			{
				Console.Clear();
				ShowMenu.MenuEdit();
				ConsoleEx.Write("Podaj komende: ", ConsoleColor.Blue);
				command = Console.ReadLine();
				switch (command)
				{
					case "Add":
					case "ad":
						EditModule.AddEM();
						Console.Clear();
						break;

					case "Delete":
					case "de":
						EditModule.DeleteEM();
						Console.Clear();
						break;

					case "EditQuantity":
					case "eq":
						EditModule.EditQuantityEM();
						Console.Clear();
						break;

					case "ShowList":
					case "sh":
						EditModule.ShowEM();
						Console.Clear();
						break;

					case "return":
						Console.Clear();
						break;

					default:
						ConsoleEx.WriteLine("nie rozpoznano polecenia", ConsoleColor.Red);
						break;
				}
			}
			while (command != "return");
		}
		
		public static void ShowListView()
		{
			string command = "";
			do
			{
				Console.Clear();
				ShowMenu.MenuList();
				ConsoleEx.Write("Podaj komende: ", ConsoleColor.Blue);
				command = Console.ReadLine();
				switch (command)
				{
					case "return":
						Console.Clear();
						break;

					case "Medicines":
					case "me":
						ShowList.ShowMed();
						Console.Clear();
						break;

					case "Orders":
					case "or":
						ShowList.ShowOrd();
						Console.Clear();
						break;

					case "Prescriptions":
					case "pr":
						ShowList.ShowPrescript();
						Console.Clear();
						break;
					
					default:
						ConsoleEx.WriteLine("nie rozpoznano polecenia", ConsoleColor.Red);
						break;
				}
			}
			while (command != "return" );
		}
	}   
}
