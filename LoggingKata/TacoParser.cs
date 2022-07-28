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
            if(line == null)
                return null;
            if(line.Length == 0)
                return null;
            if(line.Length <3)
                return null;

            var cells = line.Split(',');

            if (cells.Length< 3)
            {
               return null; 
            }
            var latitude = double.Parse(cells[0]);

            var longitude = double.Parse(cells[1]);

            var name=cells[2];
           
            var point = new Point();
            point.Latitude =latitude;
            point.Longitude = longitude;

            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = point,

            };

            logger.LogInfo($"Finished parsing location {tacoBell.Name}");

            return tacoBell;

            
        
        }
    }
}