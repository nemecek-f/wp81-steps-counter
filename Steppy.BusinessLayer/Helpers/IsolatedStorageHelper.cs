using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steppy.BusinessLayer.Helpers
{
    public static class IsolatedStorageHelper
    {
        private static IsolatedStorageSettings _iso = IsolatedStorageSettings.ApplicationSettings;

        public static void AddKey(string key)
        {
            _iso.Add(key, true);
            Save();
        }

        public static void Add(string key, object value)
        {
            _iso.Add(key, value);
            Save();
        }

        public static void Remove(string key)
        {
            _iso.Remove(key);
            Save();
        }

        public static bool ContainsKey(string key)
        {
            return _iso.Contains(key);
        }

        public static T GetValue<T>(string key)
        {
            return (T) _iso[key];
        }

        private static void Save()
        {
            _iso.Save();
        }
    }
}
