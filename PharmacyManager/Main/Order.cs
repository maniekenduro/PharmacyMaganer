using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
	public class Order : ActiveRecord
	{
		public int MedicineID { get; set; }
		public int PrescriptionID { get; set; }
		public DateTime Date { get; set; }
		public int Amount { get; set; } 


		public Order()
		{
		}

		public Order(int medicineID, int prescriptionID, DateTime date, int amount)
		{
			MedicineID = medicineID;
			PrescriptionID = prescriptionID;
			Date = date;
			Amount = amount;
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
