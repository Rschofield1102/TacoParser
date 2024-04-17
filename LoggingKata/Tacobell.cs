using System;
namespace LoggingKata
{
	public class Tacobell : ITrackable  // tacobell confirms to itracakable. 
	{									// gets name and point location from itrackable
        public string Name { get; set; }
		public Point Location { get; set; }
	}
}

