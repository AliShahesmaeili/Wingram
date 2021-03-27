using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingram.Classes.Models;

namespace Wingram.Classes.Commons
{
    public class LocalizationManager : BindableBase
    {

        #region Singleton

        private static LocalizationManager _instance;

        public static LocalizationManager Instance => _instance ?? (_instance = new LocalizationManager());

        #endregion

        #region Fields

        private readonly Dictionary<CultureInfo, Dictionary<string, LocalizationModel>> _languageEntries = new Dictionary<CultureInfo, Dictionary<string, LocalizationModel>>();
        private CultureInfo _currentCulture;

        #endregion

        #region Properties

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture?.Equals(value) == true)
                    return;

                if (!_languageEntries.ContainsKey(value))
                    return;

                Set(ref _currentCulture, value);
            }
        }

        public List<CultureInfo> AvailableCultures => _languageEntries.Keys.ToList();

        #endregion

        #region Public Methods

        public void AddCulture(CultureInfo culture, Dictionary<string, LocalizationModel> values)
        {
            if (_languageEntries.ContainsKey(culture))
            {
                _languageEntries[culture] = values;
            }
            else
            {
                _languageEntries.Add(culture, values);
            }
        }

        public string GetValue(string key, bool nullWhenUnfound = true)
        {
            if (_languageEntries == null || CurrentCulture == null)
                return key;

            var entries = _languageEntries[CurrentCulture];

            if (key == null || !entries.ContainsKey(key))
                return nullWhenUnfound ? null : key;

            return entries[key].Value;
        }


        #endregion


    }
}
