using LodgeMinutesMiddleWare.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeMinutesMiddleWare.Helpers
{
    public static class FormattingHelper
    {
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <returns></returns>
        public static string GetDate()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "MM/dd/yyyy" : "dd/MM/yyyy" );
        }

        public static string GetDateForFileSystem()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "MM_dd_yyyy" : "dd_MM_yyyy" );
        }

        /// <summary>
        /// Gets the short time.
        /// </summary>
        /// <returns></returns>
        public static string GetShortTime()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "hh:mm" : "HH:mm" );
        }

        public static string GetShortTimeWithAmPm()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "hh:mm tt" : "HH:mm tt" );
        }

        /// <summary>
        /// Gets the long time.
        /// </summary>
        /// <returns></returns>
        public static string GetLongTime()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "hh:mm" : "HH:mm" );
        }

        /// <summary>
        /// Gets the date and time.
        /// </summary>
        /// <returns></returns>
        public static string GetDateAndTime()
        {
            return DateTime.Now.ToString( SettingsViewModel.Instance.IsTwelveHourFormat ? "MM/dd/yyyy hh:mm" : "dd/MM/yyyy HH:mm" );
        }


    }
}
