using System;
using NUnit.Framework;

namespace StartingPoint
{
	/// <summary>
	/// Unit tests for StartingPoint project.
	/// </summary>
	[TestFixture]
	public class UnitTests
	{
		/* Fields */

		// Movies
		Movie cinderella;
		Movie starWars;
		Movie gladiator;

		// Rentals
		Rental rental1;
		Rental rental2;
		Rental rental3;

		// Customers
		Customer mickeyMouse;
		Customer donaldDuck;
		Customer minnieMouse;

		/* Methods */

		[SetUp]
		public void Init()
		{
			// Create movies
			cinderella = new Movie("Cinderella", PriceCodes.Childrens);
			starWars = new Movie("Star Wars", PriceCodes.Regular);
			gladiator = new Movie("Gladiator", PriceCodes.NewRelease);

			// Create rentals
			rental1 = new Rental(cinderella, 5);
			rental2 = new Rental(starWars, 5);
			rental3 = new Rental(gladiator, 5);

			// Create customers
			mickeyMouse = new Customer("Mickey Mouse");
			donaldDuck = new Customer("Donald Duck");
			minnieMouse = new Customer("Minnie Mouse");
		}

		[Test]
		public void TestMovie()
		{
			// Test title property
			Assert.AreEqual("Cinderella", cinderella.Title);
			Assert.AreEqual("Star Wars", starWars.Title);
			Assert.AreEqual("Gladiator", gladiator.Title);

			// Test price code
			Assert.AreEqual(PriceCodes.Childrens, cinderella.PriceCode);
			Assert.AreEqual(PriceCodes.Regular, starWars.PriceCode);
			Assert.AreEqual(PriceCodes.NewRelease, gladiator.PriceCode);
		}

		[Test]
		public void TestRental()
		{
			// Test Movie property
			Assert.AreEqual(cinderella, rental1.Movie);
			Assert.AreEqual(starWars, rental2.Movie);
			Assert.AreEqual(gladiator, rental3.Movie);

			// Test DaysRented property
			Assert.AreEqual(5, rental1.DaysRented);
			Assert.AreEqual(5, rental1.DaysRented);
			Assert.AreEqual(5, rental1.DaysRented);
		}

		[Test]
		public void TestCustomer()
		{
			// Test Name property
			Assert.AreEqual("Mickey Mouse", mickeyMouse.Name);
			Assert.AreEqual("Donald Duck", donaldDuck.Name);
			Assert.AreEqual("Minnie Mouse", minnieMouse.Name);

			// Test AddRental() method - set up for test
			mickeyMouse.AddRental(rental1);
			mickeyMouse.AddRental(rental2);
			mickeyMouse.AddRental(rental3);

			/* At this point, the structure of the program begins getting in the
			 * way of testing. Rentals are imbedded in the Customer object, but
			 * there is no property to access them. They can only be accessed 
			 * internally, by the Statement() method, which imbeds them in the
			 * text string passed as it's return value. So, to get these amounts,
			 * we will have to parse that value. */

			// Test the Statement() method
			string theResult = mickeyMouse.Statement();

			// Parse the result
			char[] delimiters = "\n\t".ToCharArray();
			string[] results = theResult.Split(delimiters);

			/* The results[] array will have the following elements:
			 *		[0] = junk
			 *		[1] = junk
			 *		[2] = title #1
			 *		[3] = price #1
			 *		[4] = junk
			 *		[5] = title #2
			 *		[6] = price #2
			 *		[7] = junk
			 *		[8] = title #3
			 *		[9] = price #3
			 *		[10] = "Amount owed is x"
			 *		[11] = "You earned x frequent renter points."
			 * We will test the title and price elements, and the total 
			 * and frequent renter points items. If these tests pass, then 
			 * we know that AddRentals() is adding rentals to a Customer 
			 * object properly, and that the Statement() method is
			 * generating a statement in the expected format. */

			// Test the title and price items
			Assert.AreEqual("Cinderella", results[2]);
			Assert.AreEqual(3, Convert.ToDouble(results[3]));
			Assert.AreEqual("Star Wars", results[5]);
			Assert.AreEqual(6.5, Convert.ToDouble(results[6]));
			Assert.AreEqual("Gladiator", results[8]);
			Assert.AreEqual(15, Convert.ToDouble(results[9]));
		}

	}
}
