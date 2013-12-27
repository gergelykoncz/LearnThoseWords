using LearnThoseWords.Infrastructure;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using System;

namespace LearnThoseWords
{
    public partial class WelcomePage : PhoneApplicationPage
    {
        private readonly WelcomePageViewModel _welcomePageViewModel;

        public WelcomePage()
        {
            InitializeComponent();
            _welcomePageViewModel = NinjectContainer.Get<WelcomePageViewModel>();
            DataContext = _welcomePageViewModel;
        }

        private void _welcomePageViewModel_MoveForward(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/WordListPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _welcomePageViewModel.MoveForward += _welcomePageViewModel_MoveForward;
            _welcomePageViewModel.Initialize();
        }
    }
}