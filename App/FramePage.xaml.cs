using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FramePage : ContentPage
    {
        Frame frame;
        Label lbl;
        Grid grid;
        BoxView b;
        
        public FramePage()
        {
            lbl = new Label
            {
                Text = "Frame display",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height = new GridLength(2, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                }
            };

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    b = new BoxView { Color = Color.White };
                    grid.Children.Add(b,c,r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += TapTapped;
                    b.GestureRecognizers.Add(tap);
                }
            }

            grid.Children.Add(new BoxView { Color = Color.Red }, 0, 0);
            grid.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.Blue }, 0, 1);
            grid.Children.Add(new BoxView { Color = Color.Yellow }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.MediumPurple }, 0, 2);
            grid.Children.Add(new BoxView { Color = Color.Beige }, 1, 2);

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.Chartreuse,
                CornerRadius = 30,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout st = new StackLayout
            {
                Children = { lbl, frame }
            };
            Content = st;
        }

        private void TapTapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            b.Color = Color.Black;
        }
    }
}