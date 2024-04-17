using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            logger.LogInfo("Log initialized");

            string[] lines = File.ReadAllLines(csvPath);
            
            logger.LogInfo($"Lines: {lines[0]}"); // display first item in array in terminal
                
                var parser = new TacoParser(); // new instance of tacoparser class

            // Use the Select LINQ method to parse every line in lines collection
            ITrackable[] locations = lines.Select(line =>parser.Parse(line)).ToArray();

            ITrackable tacoBell1 = null; // store tacebll 
            ITrackable tacoBell2 = null; // store tacobell 
            double distance = 0; // double varibale to store distance.

            // TODO: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library.
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];   // first tacobell location
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for(int a = 0; a < locations.Length; a++)
                {
                    var locB = locations[a];  // second tacbell location
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    double getDist = corB.GetDistanceTo(corA); // checking distances
                    if (getDist > distance)
                    {                       
                        distance = getDist;
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }
            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are greatest distance from each other.");
        }
    }
}
