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
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        List <string> lehed = new List<string> {"https://tahvel.edu.ee", "https://moodle.edu.ee"};
        ImageButton add, home, back;
        Entry line;
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Webpages"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");

            picker.SelectedIndexChanged += PickerSelectIndexChanged;
            webView = new WebView {  };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += SwipeSwiped;
            swipe.Direction = SwipeDirection.Right;

            line = new Entry { Placeholder = "Type the webadress" };
            line.Completed += LineCompleted;

            add = new ImageButton
            {
                Source = "web_site_plus.jpg",
                HorizontalOptions = LayoutOptions.Center
            };
            add.Clicked += AddPageClicked;

            home = new ImageButton
            {
                Source = "web_site_home.jpg",
                HorizontalOptions = LayoutOptions.Center
            };
            home.Clicked += HomePageClicked;

            back = new ImageButton
            {
                Source = "web_site_back.jpg",
                HorizontalOptions = LayoutOptions.Center
            };
            back.Clicked += BackClicked;

            StackLayout buttons = new StackLayout
            {
                Children = { line, home, back, add},
                Orientation = StackOrientation.Horizontal
            };

            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 40,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            st = new StackLayout { Children = { picker, frame} };
            frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void BackClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void HomePageClicked(object sender, EventArgs e)
        {
            webView.Source = lehed[0];
        }

        private void LineCompleted(object sender, EventArgs e)
        {
            webView.Source = "https://" + line.Text;
        }

        private async void AddPageClicked(object sender, EventArgs e)
        { 
            string result = await DisplayPromptAsync("Add page", "Type the page name");
            if (!string.IsNullOrWhiteSpace(result))
            {
                lehed.Add("https://" + result);
                string name = await DisplayPromptAsync("Add page", "Type the picker name");
                if (!string.IsNullOrWhiteSpace(name))
                {
                    picker.Items.Add(name);
                }
                else
                {
                    await DisplayAlert("Error", "The field is empty", "Okay");
                    lehed.Remove(result);
                }
            }
            else
            {
                    await DisplayAlert("Error", "The field is empty", "Okay");
            }
        }


        private void PickerSelectIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        private void SwipeSwiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }
    }
}