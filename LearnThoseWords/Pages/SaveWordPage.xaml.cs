using LearnThoseWords.Infrastructure;
using LearnThoseWords.Resources;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
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
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}