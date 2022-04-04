using Android.Views;
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
    public partial class TicTacToe : ContentPage
    {
        Button beginPlay;
        int[,] buttonsInPlay;
        int turn = 1;
        int steps = 9;
        bool gameOver = false;
        public TicTacToe()
        {
            beginPlay = new Button
            {
                Text = "Begin",
                TextColor = Color.Black,
                BackgroundColor = Color.MediumPurple,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            beginPlay.Clicked += BeginPlayClicked;

            StackLayout st = new StackLayout
            {
                Children = {beginPlay}
            };
            Content = st;
        }

        private void BeginPlayClicked(object sender, EventArgs e)
        {
            if(sender == beginPlay)
            {
                beginPlay.IsVisible = false;
                beginPlay.IsEnabled = false;
            }
            DrawButtons();
        }

        private void DrawButtons()
        {

            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };

            buttonsInPlay = new int[3,3];
            turn = 1;
            steps = 9;
            gameOver = false;
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                   Button ticButton = new Button
                    {
                        BackgroundColor = Color.DarkGray,
                        WidthRequest = 200,
                        HeightRequest = 150,
                        FontSize = 30,
                        FontAttributes = FontAttributes.Bold,
                        Text = "Press"
                    };
                    grid.Children.Add(ticButton, i, k);
                    buttonsInPlay[i, k] = -1;
                    ticButton.Clicked += TicButtonClicked;
                }
            }

            StackLayout st = new StackLayout
            {
                Children = { grid }
            };
            Content = st;
        }

        private void TicButtonClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            steps--;
            if (turn == 0)
            {
                buttonsInPlay[r, c] = 0;
                b.FontSize = 80;
                b.FontAttributes = FontAttributes.Bold;
                b.Text = "O";
                b.BackgroundColor = Color.PaleVioletRed;
                CheckWin();
                turn = 1;
            }
            else
            {
                buttonsInPlay[r, c] = 1;
                b.FontSize = 80;
                b.FontAttributes = FontAttributes.Bold;
                b.Text = "X";
                b.BackgroundColor = Color.LightSkyBlue;
                CheckWin();
                turn = 0;
            }
        }

        void CheckWin()
        {
            //Check Columns
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                var a = buttonsInPlay[i, k];
                var b = buttonsInPlay[i, k + 1];
                var c = buttonsInPlay[i, k + 2];
                if (a == b && a == c && a != -1)
                {
                    CallWin(turn);

                    break;
                }
                else
                {
                CheckDraw();
                }

            }

            //Check Rows
            for (int i = 0; i < 3; i++)
            {
                var a = buttonsInPlay[k, i];
                var b = buttonsInPlay[k + 1, i];
                var c = buttonsInPlay[k + 2, i];
                if (a == b && a == c && a != -1)
                {
                    CallWin(turn);
                    break;
                }
                else
                {
                    CheckDraw();
                }
            }

            //Check Diags
            for (int i = 0; i < 2; i++)
            {
                var a = buttonsInPlay[i, k];
                var b = buttonsInPlay[i + 1, k + 1];
                var c = buttonsInPlay[i + 2, k + 2];
                if (a == b && a == c && a != -1)
                {
                    CallWin(turn);
                    break;
                }
                else
                {
                   // CheckDraw();
                }

                i = 2;
                a = buttonsInPlay[i, k];
                b = buttonsInPlay[i - 1, k + 1];
                c = buttonsInPlay[i - 2, k + 2];
                if (a == b && a == c && a != -1)
                {
                    CallWin(turn);
                    break;
                }
                else
                {
                    CheckDraw();
                }
            }
        }

        void CheckDraw()
        {
            if(steps <= 0 && gameOver == false)
            {
                CallWin(-1);
            }
        }

        async void CallWin(int winner)
        {
            string win;
            gameOver = true;
            switch (winner)
            { 
                case 0:
                    win = "O ";
                    break;
                case 1:
                    win = "X ";
                    break;
                default:
                    win = "Nobody";
                    break;
            }
            bool result = await DisplayAlert(win + " wins!", "Try Again? ", "Yes", "No");
            if(result)
            {
                DrawButtons();
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}