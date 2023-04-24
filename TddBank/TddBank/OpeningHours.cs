using System;
using System.IO;

namespace TddBank
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime dt)
        {
            DayOfWeek dayOfWeek = dt.DayOfWeek;

            // Öffnungszeiten für Montag bis Freitag
            TimeSpan openingTimeWeekdays = new TimeSpan(10, 30, 0);
            TimeSpan closingTimeWeekdays = new TimeSpan(19, 0, 0);

            // Öffnungszeiten für Samstag
            TimeSpan openingTimeSaturday = new TimeSpan(10, 30, 0);
            TimeSpan closingTimeSaturday = new TimeSpan(14, 0, 0);

            // Überprüfen, ob es sich um einen Wochentag handelt
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                // Samstag Öffnungszeiten
                if (dt.TimeOfDay >= openingTimeSaturday && dt.TimeOfDay < closingTimeSaturday)
                {
                    return true;
                }
            }
            if (dayOfWeek == DayOfWeek.Saturday)
            {
                // Samstag Öffnungszeiten
                if (dt.TimeOfDay >= openingTimeSaturday && dt.TimeOfDay < closingTimeSaturday)
                {
                    return true;
                }
            }
            else if (dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Friday)
            {
                // Wochentag Öffnungszeiten
                if (dt.TimeOfDay >= openingTimeWeekdays && dt.TimeOfDay < closingTimeWeekdays)
                {
                    return true;
                }
            }

            // Geschlossen an allen anderen Tagen und Zeiten
            return false;
        }


        public bool IsNowOpen()
        {
            return IsOpen(DateTime.Now);
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }


        public bool ReadConfigFile()
        {
            return File.ReadAllText("b:\\confg.sys")
                       .Contains("🧀");
        }
    }
}
