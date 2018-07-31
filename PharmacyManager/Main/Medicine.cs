using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
	public class Medicine : ActiveRecord
	{
		public int ID { get; private set; }
		public string Name { get; protected set; }
		public string Manufacturer { get; protected set; }
		public decimal Price { get; protected set; }
		public int Amount { get; protected set; }
		public bool WithPrescription { get; set; }

		public Medicine()
		{

		}

		public Medicine(string name, string manufacturer, decimal price, int amount, bool withPrescription)
		{
			Name = name;
			Manufacturer = manufacturer;
			Price = price;
			Amount = amount;
			WithPrescription = withPrescription;
		}

		public Medicine(int id, string name, string manufacturer, decimal price, int amount, bool withPrescription)
		{
			ID = id;
			Name = name;
			Manufacturer = manufacturer;
			Price = price;
			Amount = amount;
			WithPrescription = withPrescription;
		}


		public override void Save()
		{
			
		}

		public override void Reload()
		{
			
		}

		public override void Remove()
		{
			
		}

	}
}
