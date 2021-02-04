using System;
using System.Collections.Generic;

namespace JoelMovies.Models
{
    public class TempStorage
    {
        //public TempStorage()
        //{
        //}

        private static List<ApplicationResponse> applications = new List<ApplicationResponse>();

        public static IEnumerable<ApplicationResponse> Applications => applications;
        //}

        public static void AddApplication(ApplicationResponse application)
        {
            applications.Add(application);
        }
    }
}
