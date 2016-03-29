using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MixIT.ViewModels;

namespace MixIT.Views
{
    public partial class MainPage : Page
    {
        private readonly MainViewModel _mainViewModel;

        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            Talks.IsChecked = true;
            FirstDay.IsChecked = true;
        }

        private void GoHomeRequired(object sender, RoutedEventArgs e)
        {
            _mainViewModel.DisplayTalks();
        }
        private void OnTalksSelected(object sender, RoutedEventArgs e)
        {
            LightningsTalks.IsChecked = false;
            _mainViewModel.MainPage.TalkClickCommand.Execute(null);
        }

        private void OnLightningTalkSelected(object sender, RoutedEventArgs e)
        {
            Talks.IsChecked = false;
            _mainViewModel.MainPage.LigthtalkClickCommand.Execute(null);
        }

        private void OnFirstDaySelected(object sender, RoutedEventArgs e)
        {
            SecondDay.IsChecked = false;
            _mainViewModel.MainPage.FirstDayClickCommand.Execute(null);
        }

        private void OnSecondTalkSelected(object sender, RoutedEventArgs e)
        {
            FirstDay.IsChecked = false;
            _mainViewModel.MainPage.SecondDayClickCommand.Execute(null);
        }
    }
}