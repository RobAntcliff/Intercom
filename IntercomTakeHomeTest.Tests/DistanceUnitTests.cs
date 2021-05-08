using System;
using Xunit;

namespace IntercomTakeHomeTest.Tests
{
    public class DistanceUnitTests
    {
        [Fact]
        public void Given_TwoPointsWithin100KmOfEachother_When_ValuesPassedIntoIsLessThan100KilometersBetweenPointsFunction_Then_TrueReturned()
        {
            double latitude1 = 53.2451022;
            double longitude1 = -6.238335;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            bool result = Distance.IsLessThan100KilometersBetweenPoints(latitude1, longitude1, latitude2, longitude2);

            Assert.True(result);
        }

        [Fact]
        public void Given_TwoPointsNotWithin100KmOfEachother_When_ValuesPassedIntoIsLessThan100KilometersBetweenPointsFunction_Then_FalseReturned()
        {
            double latitude1 = 52.3191841;
            double longitude1 = -8.5072391;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            bool result = Distance.IsLessThan100KilometersBetweenPoints(latitude1, longitude1, latitude2, longitude2);

            Assert.False(result);
        }

        [Fact]
        public void Given_InvalidLongitudeValue_When_ValuesPassedIntoIsLessThan100KilometersBetweenPointsFunction_Then_FalseReturned()
        {
            double latitude1 = 52.3191841;
            double longitude1 = -800.5072391;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            bool result = Distance.IsLessThan100KilometersBetweenPoints(latitude1, longitude1, latitude2, longitude2);

            Assert.False(result);
        }

        [Fact]
        public void Given_InvalidLatitudeValue_When_ValuesPassedIntoIsLessThan100KilometersBetweenPointsFunction_Then_FalseReturned()
        {
            double latitude1 = 520.3191841;
            double longitude1 = -8.5072391;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            bool result = Distance.IsLessThan100KilometersBetweenPoints(latitude1, longitude1, latitude2, longitude2);

            Assert.False(result);
        }

        [Fact]
        public void Given_TwoPointsInSameLocation_When_ValuesPassedIntoIsLessThan100KilometersBetweenPointsFunction_Then_TrueReturned()
        {
            double latitude1 = 52.3191841;
            double longitude1 = -8.5072391;

            double latitude2 = 52.3191841;
            double longitude2 = -8.5072391;

            bool result = Distance.IsLessThan100KilometersBetweenPoints(latitude1, longitude1, latitude2, longitude2);

            Assert.True(result);
        }

        [Fact]
        public void Given_InvalidLatitudeValue_When_AreValidCoordinatesCalled_Then_FalseReturned()
        {
            double latitude1 = 520.3191841;
            double longitude1 = -8.5072391;

            bool result = Distance.AreValidCoordinates(latitude1, longitude1);

            Assert.False(result);
        }

        [Fact]
        public void Given_InvalidLongitudeValue_When_AreValidCoordinatesCalled_Then_FalseReturned()
        {
            double latitude1 = 52.3191841;
            double longitude1 = -800.5072391;

            bool result = Distance.AreValidCoordinates(latitude1, longitude1);

            Assert.False(result);
        }

        [Fact]
        public void Given_ValidValues_When_AreValidCoordinatesCalled_Then_TrueReturned()
        {
            double latitude1 = 52.3191841;
            double longitude1 = -8.5072391;

            bool result = Distance.AreValidCoordinates(latitude1, longitude1);

            Assert.True(result);
        }

        [Fact]
        public void Given_APairOfCoordinates_When_GreatCircleDistanceOnEarthCalled_Then_ExpectedValueReturned()
        {
            double latitude1 = 53.2451022;
            double longitude1 = -6.238335;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            double expectedResult = 10.566936;

            double result = Distance.GreatCircleDistanceOnEarth(latitude1, longitude1, latitude2, longitude2);

            //6 decimal places of accuracy is accurate enough
            result = Math.Round(result, 6);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Given_APairOfCoordinatesAtSamePoints_When_GreatCircleDistanceOnEarthCalled_Then_ZeroReturned()
        {
            double latitude1 = 53.2451022;
            double longitude1 = -6.238335;

            double latitude2 = 53.2451022;
            double longitude2 = -6.238335;

            double expectedResult = 0;

            double result = Distance.GreatCircleDistanceOnEarth(latitude1, longitude1, latitude2, longitude2);

            //6 decimal places of accuracy is accurate enough
            result = Math.Round(result, 6);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Given_AnInvalidLatitude_When_GreatCircleDistanceOnEarthCalled_Then_ArgumentOutOfRangeExceptionThrown()
        {
            double latitude1 = 530.2451022;
            double longitude1 = -6.238335;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            Assert.Throws<ArgumentOutOfRangeException>(() => Distance.GreatCircleDistanceOnEarth(latitude1, longitude1, latitude2, longitude2));
        }

        [Fact]
        public void Given_AnInvalidLongitude_When_GreatCircleDistanceOnEarthCalled_Then_ArgumentOutOfRangeExceptionThrown()
        {
            double latitude1 = 53.2451022;
            double longitude1 = -600.238335;

            double latitude2 = 53.339428;
            double longitude2 = -6.257664;

            Assert.Throws<ArgumentOutOfRangeException>(() => Distance.GreatCircleDistanceOnEarth(latitude1, longitude1, latitude2, longitude2));
        }

        [Fact]
        public void Given_ValueInDegrees_When_DegreesToRadiansCalled_Then_ExpectedResultReturned(){
            double degrees = 57.2958;
            double expectedResult = 1.000000;

            double result = Distance.DegreesToRadians(degrees);

            //6 decimal places of accuracy is accurate enough
            result = Math.Round(result, 6);

            Assert.Equal(expectedResult, result);
        }
    }
}