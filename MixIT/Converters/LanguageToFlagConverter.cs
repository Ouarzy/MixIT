using System;
using Windows.UI.Xaml.Data;
using MixIT.Shared.Models;

namespace MixIT.Converters
{
    public class LanguageToFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var currrentLanguage = value is LanguageEnum ? (LanguageEnum)value : LanguageEnum.fr;

            switch (currrentLanguage)
            {
                case LanguageEnum.en:
                    {
                        return @"/Assets/en.jpg";
                    }

                default:
                    {
                        return @"/Assets/fr.jpg";
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
