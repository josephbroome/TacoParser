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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------
          ITrackable tacoBellA=null;
            ITrackable tacoBellB=null;
            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            double distance = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                var locationA = locations[i];
                var coordinateA = new GeoCoordinate
                {
                    Latitude = locationA.Location.Latitude,
                    Longitude = locationA.Location.Longitude,
                };
                for (int j = 0; j < locations.Length; j++)
                {
                    var locationB = locations[j];
                    var coordinateB = new GeoCoordinate();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        tacoBellA = locationA;
                        tacoBellB = locationB;
                    }
                }
            }
            logger.LogInfo($"{tacoBellA.Name} and {tacoBellB.Name} are the farthest apart from eachother");




        }
    }
}
