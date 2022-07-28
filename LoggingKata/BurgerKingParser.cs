using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class BurgerKingParser
    {

        readonly ILog logger = new BurgerKingLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }
            var longitude = double.Parse(cells[0]);

            var latitude = double.Parse(cells[1]);

            var name = cells[2];

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var burgerKing = new BurgerKing()
            {
                Name = name,
                Location = point,

            };

            logger.LogInfo($"Finished parsing location {burgerKing.Name}");

            return burgerKing;

        }
    }
}