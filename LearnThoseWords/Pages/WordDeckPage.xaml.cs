using LearnThoseWords.Entities;
using LearnThoseWords.Infrastructure;
using LearnThoseWords.ViewModels;
using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace LearnThoseWords.Pages
{
    public partial class WordDeckPage : PhoneApplicationPage
    {
        private readonly WordDeckViewModel _wordDeckViewModel;

        public WordDeckPage()
        {
            InitializeComponent();
            _wordDeckViewModel = NinjectContainer.Get<WordDeckViewModel>();
            DataContext = _wordDeckViewModel;
            _wordDeckViewModel.Initialize();
        }

        private void Grid_Tap(object sender, GestureEventArgs e)
        {
            var tappedGrid = sender as Button;
            if (tappedGrid != null)
            {
                Storyboard board = new Storyboard();
                DoubleAnimation da = new DoubleAnimation();
                da.Duration = new Duration(new System.TimeSpan(0, 0, 1));
                da.From = (tappedGrid.GetValue(ProjectionProperty) as PlaneProjection).RotationY;
                if (da.From > 180)
                {
                    da.From = 0;
                }
                bool isFlipped = da.From == 180;
                da.To = da.From + 180;

                Storyboard.SetTarget(board, tappedGrid);
                Storyboard.SetTargetProperty(board, new PropertyPath("(UIElement.Projection).(PlaneProjection.RotationY)"));
                board.Children.Add(da);
                board.Begin();
                
                TextBlock textBlock = tappedGrid.FindName("cardContent") as TextBlock;
                Word word = tappedGrid.DataContext as Word;
                if (textBlock != null && word != null)
                {
                    if (isFlipped)
                    {
                        textBlock.Text = word.Title;
                        var textProjection = textBlock.Projection as PlaneProjection;
                        if (textProjection != null)
                        {
                            textProjection.RotationY = 0;
                        }
                    }
                    else
                    {
                        textBlock.Text = word.Definition;
                        var textProjection = textBlock.Projection as PlaneProjection;
                        if (textProjection != null)
                        {
                            textProjection.RotationY = 180;
                        }
                    }
                }
            }
        }
    }
}