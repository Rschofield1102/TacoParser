using System.Linq;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null; 
            }

            var latitude = double.Parse(cells[0]); // latitude from array(cells) at index 0
                                                   // latitude is double so parse

            var longitude= double.Parse(cells[1]); // longitude from array(cells) at index 1
                                                   // longitude is double so parse 

            var name = cells[2]; // name of array (cells) at index 2

            var point = new Point(); // create instance Point
            point.Latitude = latitude; // set values long, lati
            point.Longitude = longitude;

            var tacoBell = new Tacobell(); // create instance of tacebell
            tacoBell.Name = name;   // set values name, location
            tacoBell.Location = point;

            return tacoBell; // return instance tacobell since it confirm to itrackable
        }
    }
}
