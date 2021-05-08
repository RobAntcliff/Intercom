using System;

namespace IntercomTakeHomeTest
{
    public class Distance
    {
        //The mean radius of the Earth is 6371 kilometers according to Wikipedia
        private const int earthRadius = 6371;

        /// <summary>
        /// Determines wether a set of coordinates are valid coordinates
        /// </summary>
        /// <returns>
        /// True if valid, False if not valid 
        /// </returns>
        /// <param name="latitude">The point's latitude in degrees.</param>
        /// <param name="longitude">The point's longitude in degrees.</param>
        public static bool AreValidCoordinates(double latitude, double longitude){
            return Math.Abs(latitude) <= 90 && Math.Abs(longitude) <= 180;
        }

        /// <summary>
        /// Calculates if two points on Earth are within 100 Kilometers of eachother
        /// </summary>
        /// <returns>
        /// True if 2 points are within 100 Kilometers of eachother, False if the points are more than 100 Kilometers from eachother or
        /// if the points are invalid 
        /// </returns>
        /// <param name="latitude1">The first point's latitude in degrees.</param>
        /// <param name="longitude1">The first point's longitude in degrees.</param>
        /// <param name="latitude2">The second point's latitude in degrees.</param>
        /// <param name="longitude2">The second point's longitude in degrees.</param>
        public static bool IsLessThan100KilometersBetweenPoints(double latitude1, double longitude1, double latitude2, double longitude2){
            try{
                return Distance.GreatCircleDistanceOnEarth(latitude1, longitude1, latitude2, longitude2) < 100;
            } catch (ArgumentOutOfRangeException e) {
                Console.WriteLine($"Exception Caught: {e}");
                return false;
            }
        }

        /// <summary>
        /// Calculates the distance between 2 points on Earth
        /// </summary>
        /// <returns>
        /// A double that is the distance from one point of the earth to another in kilometers
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the latitude or longitude is out of bounds</exception>
        /// <param name="latitude1">The first point's latitude in degrees.</param>
        /// <param name="longitude1">The first point's longitude in degrees.</param>
        /// <param name="latitude2">The second point's latitude in degrees.</param>
        /// <param name="longitude2">The second point's longitude in degrees.</param>
        public static double GreatCircleDistanceOnEarth(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            //Making sure coordinates are valid
            if(!AreValidCoordinates(latitude1, longitude1) || !AreValidCoordinates(latitude2, longitude2))
            {
                throw new ArgumentOutOfRangeException("One or more of your arguments are out of range." + 
                    "The acceptable range for Latitude is -90 to +90 degrees and the acceptable range for Longitude is -180 to 180 degrees");
            }

            //We take in values in degrees but the formula uses radians so we need to convert the values
            var latitude1Radians = DegreesToRadians(latitude1);
            var longitude1Radians = DegreesToRadians(longitude1);
            var latitude2Radians = DegreesToRadians(latitude2);
            var longitude2Radians = DegreesToRadians(longitude2);

            var longitudeAbsoluteDifference = Math.Abs(longitude1Radians - longitude2Radians);

            //Calculates the central angle using the first formula from https://en.wikipedia.org/wiki/Great-circle_distance
            var centralAngle = 
                Math.Acos((Math.Sin(latitude1Radians) * Math.Sin(latitude2Radians))
                        + (Math.Cos(latitude1Radians) * Math.Cos(latitude2Radians) * Math.Cos(longitudeAbsoluteDifference)));

            var distance = earthRadius * centralAngle;

            return distance;
        }

        /// <summary>
        /// Converts an angle's value from degrees to radians
        /// </summary>
        /// <returns>
        /// A double value that is the degrees converted to radians
        /// </returns>
        /// <param name="degrees">The value in degrees to be converted to radians</param>
        public static double DegreesToRadians(double degrees){
            return degrees * Math.PI/180;
        }
    }  
}