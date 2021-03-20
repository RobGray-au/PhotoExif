using System;
using GeoTimeZone;


namespace FixExifTimeStamp
{
    static class GPSMethods
    {
        /// <summary>
        /// get the Local time at a Lat/long at particualar date
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="utcDate"></param>
        /// <returns></returns>
        public static DateTime GetLocalTimefromGPS(double latitude, double longitude, DateTime utcDate)
        {
            string tzIana = TimeZoneLookup.GetTimeZone(latitude, longitude).Result;
            TimeZoneInfo tzInfo = TimeZoneConverter.TZConvert.GetTimeZoneInfo(tzIana);
            
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDate, tzInfo);
            return localTime;
        }
        /// <summary>
        /// returns UTC offset for particular datetime
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="utcDate"></param>
        /// <returns></returns>
        public static float GetGPStimeOffset(double latitude, double longitude, DateTime utcDate)
        {
            string tzIana = TimeZoneLookup.GetTimeZone(latitude, longitude).Result;
            TimeZoneInfo tzInfo = TimeZoneConverter.TZConvert.GetTimeZoneInfo(tzIana);
            return (float)tzInfo.GetUtcOffset(utcDate).TotalHours;

        }
    }

    //public static class GPSData
    //{
    //    static float Latitude;
    //    static float Longitude;
    //    static DateTimeOffset Date;
    //}
 }
