using System;

namespace VideoArchives
{
	/// <summary>
	/// Rental represents a customer renting a movie.
	/// </summary>
	public class Rental
	{
		/* Fields */

		// Data members
		private readonly Movie movie;
		private readonly int daysRented;

		/* Constructor */

		public Rental(Movie movie, int daysRented)
		{
			this.movie = movie;
			this.daysRented = daysRented;
		}

		/* Properties */

		public int DaysRented
		{
			get {return daysRented;}
		}

		public Movie Movie
		{
			get {return movie;}
		}
	}
}
