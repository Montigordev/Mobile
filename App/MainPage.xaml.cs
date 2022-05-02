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
            Button PickerBtn = new Button
            {
                Text = "Picker page",
                BackgroundColor = Color.BlueViolet
            };
            Button TableBtn = new Button
            {
                Text = "Table page",
                BackgroundColor = Color.LawnGreen
            };
            Button HoroskopBtn = new Button
            {
                Text = "Horoskoop page",
                BackgroundColor = Color.BlueViolet
            };
            Button CountyBtn = new Button
            {
                Text = "Maakond page",
                BackgroundColor = Color.Blue
            };
            StackLayout st = new StackLayout
            {
                Children = {EntBtn, TimerBtn, RgbBtn, TicTacToeBtn, PickerBtn, TableBtn, HoroskopBtn, CountyBtn}
            };
            st.BackgroundColor = Color.Aqua;
            Content = st;
            EntBtn.Clicked += EntBtnClicked;
            TimerBtn.Clicked += TimerBtnClicked;
            RgbBtn.Clicked += RgbBtnClicked;
            TicTacToeBtn.Clicked += TicTacToeClicked;
            PickerBtn.Clicked += PickerClicked;
            TableBtn.Clicked += TableClicked;
            HoroskopBtn.Clicked += HoroskopClicked;
            CountyBtn.Clicked += CountyClicked;
        }

        private async void CountyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MaakondPage());
        }

        private async void HoroskopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HoroskopPage());
        }

        private async void TableClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TablePage());
        }

        private async void PickerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickerPage());
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