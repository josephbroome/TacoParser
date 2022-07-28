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

        static readonly ILog logger2 = new BurgerKingLogger();
        const string csvPath2 = "BurgerKing-US-AL.csv";

        static void Main(string[] args)
        {


            logger.LogInfo("Log initialized");


            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            var tacoparser = new TacoParser();


            var locations = lines.Select(tacoparser.Parse).ToArray();


            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;
            const double MetersToMiles = 0.000621371;

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
            logger.LogInfo($"{tacoBellA.Name} and {tacoBellB.Name} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");



            logger2.LogInfo("Log initialized");


            var line = File.ReadAllLines(csvPath2);

            logger2.LogInfo($"Lines: {line[0]}");


            var burgerkingparser = new BurgerKingParser();


            var burgerKingLocations = line.Select(burgerkingparser.Parse).ToArray();
            

            ITrackable burgerKingA = null;
            ITrackable burgerKingB = null;
            const double MetersToMiles1 = 0.000621371;

            double burgerKingDistance = 0;
            for (int i = 0; i < burgerKingLocations.Length - 1; i++)
            {
                var burgerKinglocationA = burgerKingLocations[i];
                var burgerKingcoordinateA = new GeoCoordinate
                {
                    Latitude = burgerKinglocationA.Location.Latitude,
                    Longitude = burgerKinglocationA.Location.Longitude,
                };
                for (int j = 0; j < burgerKingLocations.Length-1; j++)
                {
                    var burgerKinglocationB = burgerKingLocations[j];
                    var burgerKingcoordinateB = new GeoCoordinate()
                    {
                        Latitude= burgerKinglocationB.Location.Latitude,
                        Longitude= burgerKinglocationB.Location.Longitude,
                    };

                   

                    if (burgerKingcoordinateA.GetDistanceTo(burgerKingcoordinateB) > burgerKingDistance)
                    {
                        burgerKingDistance = burgerKingcoordinateA.GetDistanceTo(burgerKingcoordinateB);
                        burgerKingA = burgerKinglocationA;
                        burgerKingB = burgerKinglocationB;
                    }
                }
            }
            logger2.LogInfo($"{burgerKingA.Name} and {burgerKingB.Name} are the farthest apart from eachother and are {Convert.ToUInt32(burgerKingDistance) * MetersToMiles1} miles apart");


        }
    }
}
