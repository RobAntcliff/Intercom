using System;

namespace IntercomTakeHomeTest
{
    class Distance
    {
        //The mean radius of the Earth is 6371 kilometers according to Wikipedia
        private const int earthRadius = 6371;

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
            //Making sure 
            if(Math.Abs(latitude1) >= 90 || Math.Abs(latitude2) >= 90 || Math.Abs(longitude1) >= 180 || Math.Abs(longitude2) >= 180)
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