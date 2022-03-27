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
    public partial class EntryPage : ContentPage
    {
        Editor ed;
        Label lb;
        public EntryPage()
        {
            ed = new Editor
            {
                Placeholder = "Type the text here",
                BackgroundColor = Color.White,
                TextColor = Color.Red
            };
            ed.TextChanged += EdTextChanged;
            lb = new Label
            {
                Text = "Some text",
                TextColor = Color.Orange
            };
            Button back = new Button
            { Text = "Back"};
            back.Clicked += BackClicked;
            StackLayout st = new StackLayout
            { Children = {ed, lb, back}};
            st.BackgroundColor = Color.Aqua;
            Content = st;
        }
        int i = 0;
        private async void BackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void EdTextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= EdTextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if(key == 'A')
            {
                i++;
                lb.Text = key.ToString() + ": " + i;
            }
            ed.TextChanged += EdTextChanged;
        }
    }
}