using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
	public class Prescription : ActiveRecord
	{	
		public string CustomerName { get; protected set; }
		public string PESEL { get; protected set; }
		public string PrescriptionNumber { get; set; }

		public Prescription()
		{

		}

		public Prescription(string customerName, string pesel, string prescriptionNumber)
		{
			CustomerName = customerName;
			PESEL = pesel;
			PrescriptionNumber = prescriptionNumber;
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

