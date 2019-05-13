using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using RegistroCombustibles.Common.Utils.Utilitarios;

namespace RegistroCombustibles.Utilitarios
{
    /// <summary>
    /// Analytic service.
    /// </summary>
    public class AnalyticService
    {
        /// <summary>
        /// Tracks the analytics.
        /// </summary>
        /// <param name="eventClass">Event class.</param>
        /// <param name="dictionary">Dictionary.</param>
        public static void TrackAnalytics(string eventClass, Dictionary<string, string> dictionary)
        {
            if (DataManager.AppCenterActive)
                Analytics.TrackEvent(eventClass, dictionary);
        }
    }
}
