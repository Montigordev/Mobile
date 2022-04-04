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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Button EntBtn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Red
            };
            Button TimerBtn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.Green
            };
            Button RgbBtn = new Button
            {
                Text = "RGB",
                BackgroundColor = Color.Blue
            };
            Button TicTacToeBtn = new Button
            {
                Text = "Tic Tac Toe",
                BackgroundColor = Color.MediumPurple
            };
            StackLayout st = new StackLayout
            {
                Children = {EntBtn, TimerBtn, RgbBtn, TicTacToeBtn}
            };
            st.BackgroundColor = Color.Aqua;
            Content = st;
            EntBtn.Clicked += EntBtnClicked;
            TimerBtn.Clicked += TimerBtnClicked;
            RgbBtn.Clicked += RgbBtnClicked;
            TicTacToeBtn.Clicked += TicTacToeClicked;
        }

        private async void TicTacToeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicTacToe());
        }

        private async void RgbBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RgbPage());
        }

        private async void EntBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }

        private async void TimerBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

    }
}