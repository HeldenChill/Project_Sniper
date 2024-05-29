using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public static class Locator
    {
        static IDataService dataService;
        public static IDataService DataService
        {
            get => dataService;
            set
            {
                if (dataService == null)
                    dataService = value;
            }
        }
    }
}