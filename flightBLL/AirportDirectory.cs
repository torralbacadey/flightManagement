using System;
using System.Collections.Generic;

namespace flightManagement.BLL
{
    public static class AirportDirectory
    {
        public const string DefaultOriginCode = "MNL";

        public static readonly Dictionary<string, string> KnownAirports =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "MNL", "Ninoy Aquino International Airport (Manila)" },
            { "NRT", "Narita International Airport (Tokyo)" },
            { "BKK", "Suvarnabhumi Airport (Bangkok)" },
            { "DPS", "Ngurah Rai International Airport (Bali)" },
            { "HKG", "Hong Kong International Airport (Hongkong)" },
            { "ICN", "Incheon International Airport (Seoul)" },
            { "KUL", "Kuala Lumpur International Airport (Kuala Lumpur)" },
            { "SYD", "Sydney Kingsford Smith Airport (Sydney)" },
            { "DEL", "Indira Gandhi International Airport (New Delhi)" },
            { "SIN", "Singapore Changi Airport (Singapore)" }
        };

        public static bool IsKnownCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            return KnownAirports.ContainsKey(code.Trim());
        }
    }
}