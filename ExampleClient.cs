using System;

namespace VideoArchives
{
	/// <summary>
	/// This class acts as an example of how to use the video archives library.
	/// </summary>
	class ExampleClient
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Create movies
			Movie movCinderella = new Movie("Cinderella", PriceCodes.Childrens);
			Movie movStarWars = new Movie("Star Wars", PriceCodes.Regular);
			Movie movGladiator = new Movie("Gladiator", PriceCodes.NewRelease);

			// Create customers
			Customer custMickeyMouse = new Customer("Mickey Mouse");
			Customer custDonaldDuck = new Customer("Donald Duck");
			Customer custMinnieMouse = new Customer("Minnie Mouse");

			// Create rentals
			Rental rental1 = new Rental(movCinderella, 5);
			Rental rental2 = new Rental(movStarWars, 5);
			Rental rental3 = new Rental(movGladiator, 5);

			// Assign rentals to customers
			custMickeyMouse.AddRental(rental1);
			custMickeyMouse.AddRental(rental2);
			custMickeyMouse.AddRental(rental3);

			// Generate invoice
			string statement = custMickeyMouse.Statement();

			// Print the statement
			Console.WriteLine(statement);
			Console.ReadLine();
		}
	}
}
