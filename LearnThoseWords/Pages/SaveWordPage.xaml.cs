using LearnThoseWords.Infrastructure;
using LearnThoseWords.Resources;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace LearnThoseWords.Pages
{
    public partial class SaveWordPage : PhoneApplicationPage
    {
        private readonly SaveWordViewModel _saveWordViewModel;

        public SaveWordPage()
        {
            InitializeComponent();
            buildLocalizedAppBar();
            this._saveWordViewModel = NinjectContainer.Get<SaveWordViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                base.OnNavigatedFrom(e);
                string wordIdParameter;

                if (NavigationContext.QueryString.TryGetValue("wordId", out wordIdParameter))
                {
                    int wordId;
                    if (int.TryParse(wordIdParameter, out wordId))
                    {
                        _saveWordViewModel.Initialize(wordId);
                    }
                }
                else
                {
                    _saveWordViewModel.Initialize();
                }

                DataContext = _saveWordViewModel;
            }
        }

        private void buildLocalizedAppBar()
        {
            var cancelButton = new ApplicationBarIconButton(new Uri("/Assets/Cancel.png", UriKind.Relative));
            cancelButton.Text = AppResources.SaveWordPageCancel;
            cancelButton.Click += cancelButton_Click;
            ApplicationBar.Buttons.Add(cancelButton);

            var saveButton = new ApplicationBarIconButton(new Uri("/Assets/Save.png", UriKind.Relative));
            saveButton.Text = AppResources.SaveWordPageSave;
            saveButton.Click += saveButton_Click;
            ApplicationBar.Buttons.Add(saveButton);

            var deleteButton = new ApplicationBarIconButton(new Uri("/Assets/Delete.png", UriKind.Relative));
            deleteButton.Text = AppResources.SaveWordPageSave;
            deleteButton.Click += deleteButton_Click;
            ApplicationBar.Buttons.Add(deleteButton);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _saveWordViewModel.SaveWord();
            goBack();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(AppResources.SaveWordPageDeleteConfirmation, AppResources.SaveWordPageDeleteCaption, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                _saveWordViewModel.DeleteWord();
                goBack();
            }
        }
        
        private void webButton_Click(object sender, RoutedEventArgs e)
        {
            _saveWordViewModel.GetDefinition();
        }

        private void goBack()
        {
            NavigationService.Navigate(new Uri("/Pages/WordListPage.xaml", UriKind.Relative));
        }
    }
}