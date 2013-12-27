using LearnThoseWords.Entities;
using LearnThoseWords.Infrastructure;
using LearnThoseWords.Resources;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows.Input;

namespace LearnThoseWords.Pages
{
    public partial class WordListPage : PhoneApplicationPage
    {
        private readonly WordListViewModel _wordListViewModel;

        public WordListPage()
        {
            InitializeComponent();
            buildLocalizedAppBar();
            _wordListViewModel = NinjectContainer.Get<WordListViewModel>();
            DataContext = _wordListViewModel;
            _wordListViewModel.Initialize();
        }

        private void buildLocalizedAppBar()
        {
            var addButton = new ApplicationBarIconButton(new Uri("/Assets/Add.png", UriKind.Relative));
            addButton.Text = AppResources.WordListPageAddNew;
            addButton.Click += addButton_Click;
            ApplicationBar.Buttons.Add(addButton);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SaveWordPage.xaml", UriKind.Relative));
        }

        private void LongListSelector_Tap(object sender, GestureEventArgs e)
        {
            var longListSelector = sender as LongListSelector;
            if (longListSelector != null)
            {
                var word = longListSelector.SelectedItem as Word;
                if (word != null)
                {
                    Uri detailsUri = new Uri(string.Format("/Pages/SaveWordPage.xaml?wordId={0}", word.WordId), UriKind.Relative);
                    NavigationService.Navigate(detailsUri);
                }
            }
        }
    }
}