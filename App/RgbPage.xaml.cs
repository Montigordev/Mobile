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
    public partial class RgbPage : ContentPage
    {
        BoxView boxView;
        Slider redSlider, greenSlider, blueSlider;
        Label redLabel, greenLabel, blueLabel;
        Button randomButton;

        public RgbPage()
        {

            boxView = new BoxView
            {               
                CornerRadius = 10,
                WidthRequest=300, HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            redLabel = new Label
            {
                Text = "Red Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 200                
            };

            greenLabel = new Label
            {
                Text = "Green Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 100
            };

            blueLabel = new Label
            {
                Text = "Blue Color:",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 150
            };

            redSlider.ValueChanged += SliderValueChanged;
            greenSlider.ValueChanged += SliderValueChanged;
            blueSlider.ValueChanged += SliderValueChanged;

            randomButton = new Button
            {
                Text = "Press Me!",
                TextColor = Color.Black,
                BackgroundColor = Color.Azure,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            randomButton.Clicked += RndButtonClicked;

            StackLayout st = new StackLayout
            {
                Children = {randomButton, redSlider, redLabel, greenSlider, greenLabel, blueSlider, blueLabel}
            };
            Content = st;
        }

        private void RndButtonClicked(object sender, EventArgs e)
        {
            Random r = new Random();
            int rInt = r.Next(0, 255);
            redSlider.Value = rInt;
            rInt = r.Next(0, 255);
            greenSlider.Value = rInt;
            rInt = r.Next(0, 255);
            blueSlider.Value = rInt;
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {

            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }

            boxView.Color = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);

            randomButton.BackgroundColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);

            redSlider.ThumbColor = Color.Red;
            greenSlider.ThumbColor = Color.Green;
            blueSlider.ThumbColor = Color.Blue;

            redLabel.TextColor = Color.Red;
            greenLabel.TextColor = Color.Green;
            blueLabel.TextColor = Color.Blue;

            redSlider.MinimumTrackColor = Color.Red;
            redSlider.MaximumTrackColor = redSlider.MinimumTrackColor;

            greenSlider.MinimumTrackColor = Color.Green;
            greenSlider.MaximumTrackColor = redSlider.MinimumTrackColor;

            blueSlider.MinimumTrackColor = Color.Blue;
            blueSlider.MaximumTrackColor = redSlider.MinimumTrackColor;
        }
    }
}