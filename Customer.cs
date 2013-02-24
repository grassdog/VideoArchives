using System;
using System.Collections;

namespace StartingPoint
{
	/// <summary>
	/// Customer represents a customer of the store.
	/// </summary>
	public class Customer
	{
		/* Fields */
		
		private readonly string name;
		private readonly ArrayList  rentals = new ArrayList();

		/* Constructor */
		public Customer(string name)
		{
			this.name = name;
		}

		/* Properties */

		public string Name
		{
			get {return name;}
		}

		/* Methods */

		public void AddRental(Rental arg)
		{
			rentals.Add(arg);
		}

		public string Statement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			IEnumerator rentals = this.rentals.GetEnumerator();
			string result = "Rental record for " + name + "\n";
			while ( rentals.MoveNext() )
			{
				double thisAmount = 0;
				Rental each = (Rental)rentals.Current;

				// Determine amounts for each line
				switch(each.Movie.PriceCode)
				{
					case PriceCodes.Regular:
						thisAmount += 2;
						if (each.DaysRented > 2)
						{
							thisAmount += (each.DaysRented - 2) * 1.5;
						}
						break;

					case PriceCodes.NewRelease:
						thisAmount += each.DaysRented *3;
						break;

					case PriceCodes.Childrens:
						thisAmount += 1.5;
						if (each.DaysRented > 3)
						{
							thisAmount = (each.DaysRented - 3) * 1.5;
						}
						break;
				}

				// Add frequent renter points
				frequentRenterPoints++;

				// Add bonus for a two-day new-release rental
				if ((each.Movie.PriceCode == PriceCodes.NewRelease) && (each.DaysRented > 1))
				{
					frequentRenterPoints ++;
				}

				// Show figures for this rental
				result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
				totalAmount += thisAmount;
			}

			// Add footer lines
			result += "Amount owed is " + totalAmount.ToString() + "\n";
			result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points.";
			return result;
		}
	}
}
