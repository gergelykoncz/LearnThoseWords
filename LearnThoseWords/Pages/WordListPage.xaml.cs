using LearnThoseWords.Infrastructure;
using LearnThoseWords.Resources;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;

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
            var addButton = new ApplicationBarIconButton(new Uri("/Assets/Cancel.png", UriKind.Relative));
            addButton.Text = AppResources.WordListPageAddNew;
            addButton.Click += addButton_Click;
            ApplicationBar.Buttons.Add(addButton);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SaveWordPage.xaml", UriKind.Relative));
        }
    }
}