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
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
        }
        bool onOff = true;
        
        private async void ShowTime()
        {
            while (onOff)
            {
                timerBtn.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        private void timerBtnClicked(object sender, EventArgs e)
        {
            if(onOff)
            {
                onOff = false;
            }
            else
            {
                onOff = true;
                ShowTime();
            }
        }

        private void TapGestureRecognizerTapped(object sender, EventArgs e)
        {
            lbl.Text = "Pressed";
        }

        private async void backClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}