using System;


namespace StartingPoint
{
	/// <summary>
	/// Price codes
	/// </summary>
	public enum PriceCodes
	{
		Regular,
		NewRelease,
		Childrens
	}

	/// <summary>
	/// Movie is just a simple data class.
	/// </summary>
	public class Movie
	{
		/* Fields */

		// Price code constants changed to enum

		// Data members
		private readonly string title;

	    /* Constructor */

		public Movie(string title, PriceCodes priceCode)
		{
			this.title = title;
			this.PriceCode = priceCode;
		}

		/* Properties */

	    public PriceCodes PriceCode { get; set; }

	    public string Title
		{
			get {return title;}
		}
	}
}
