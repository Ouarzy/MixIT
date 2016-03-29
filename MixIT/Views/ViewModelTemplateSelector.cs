using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MixIT.Views
{
    public class ViewModelTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SearchTemplate(item)
                   ?? base.SelectTemplateCore(item, container);
        }

        private DataTemplate SearchTemplate(object viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            var formatKey = FormatKey(viewModel);
            return SearchTemplate(formatKey);
        }

        private static string FormatKey(object viewModel)
        {
            var viewModelType = viewModel.GetType();

            if (viewModelType.GenericTypeArguments.Length == 1)
            {
                return $"{viewModelType.Namespace}.{viewModelType.Name}[{viewModelType.GenericTypeArguments[0].Name}]";
            }

            return viewModelType.FullName;
        }

        private DataTemplate SearchTemplate(string key)
        {
            return SearchTemplate(Application.Current.Resources, key);
        }

        private DataTemplate SearchTemplate(ResourceDictionary dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key] as DataTemplate;
            }

            return null;
        }
    }
}
