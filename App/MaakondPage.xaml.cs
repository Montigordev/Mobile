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
    public partial class MaakondPage : ContentPage
    {
        Picker capital, county;
        Label label;
        Image img;
        public MaakondPage()
        {
            county = new Picker
            {
                Title = "Maakond"
            };
            county.Items.Add("Harjumaa");
            county.Items.Add("Ida-Virumaa");
            county.Items.Add("Tartumaa");
            county.Items.Add("Järvamaa");
            county.Items.Add("Pärnumaa");
            county.Items.Add("Saaremaa");
            county.Items.Add("Viljandimaa");
            county.Items.Add("Hiiumaa");
            county.Items.Add("Läänemaa");
            county.Items.Add("Valgamaa");
            county.Items.Add("Võrumaa");
            county.Items.Add("Põlvamaa");
            county.Items.Add("Jõgevamaa");
            county.Items.Add("Raplamaa");
            county.Items.Add("Lääne-Virumaa");

            capital = new Picker
            {
                Title = "Linn"
            };
            capital.Items.Add("Tallinn");
            capital.Items.Add("Jõhvi");
            capital.Items.Add("Tartu");
            capital.Items.Add("Paide");
            capital.Items.Add("Pärnu");
            capital.Items.Add("Kuressaare");
            capital.Items.Add("Viljandi");
            capital.Items.Add("Kärdla");
            capital.Items.Add("Haapsalu");
            capital.Items.Add("Valga");
            capital.Items.Add("Võru");
            capital.Items.Add("Põlva");
            capital.Items.Add("Jõgeva");
            capital.Items.Add("Rapla");
            capital.Items.Add("Rakvere");

            county.SelectedIndexChanged += SetData;
            capital.SelectedIndexChanged += SetData;

            label = new Label
            {
                Text = "Hello",
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            img = new Image
            {
                Source = ImageSource.FromFile("Eesti.jpg"),
            };
            StackLayout st = new StackLayout
            {
                Children = { county, capital, label, img }
            };
            Content = st;
        }

        private void SetData(object sender, EventArgs e)
        {
            if(sender == county)
            {
                capital.SelectedIndex = county.SelectedIndex;
            }
            else
            {
                county.SelectedIndex = capital.SelectedIndex;
            }

            label.Text = "Maakond: " + county.Items[county.SelectedIndex] + " Linn: " + capital.Items[capital.SelectedIndex];
            string picName = ConvertChars(county.Items[county.SelectedIndex]);
            img.Source = picName + ".jpg";
            if(img.Source == null)
            {
                img.Source = picName + ".png";
                if(img.Source == null)
                {
                    img.Source = "Eesti.jpg";
                }
            }
        }

        private string ConvertChars(string _line)
        {
            _line = _line.Replace('Ä', 'A');
            _line = _line.Replace('ä', 'a');
            _line = _line.Replace('Ö', 'O');
            _line = _line.Replace('ö', 'o');
            _line = _line.Replace('Ü', 'U');
            _line = _line.Replace('ü', 'u');
            _line = _line.Replace('Õ', 'O');
            _line = _line.Replace('õ', 'o');
            _line = _line.Replace('-', 'i');

            return _line;
        }
    }
}