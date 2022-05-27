using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPage : ContentPage
    {
        Label lblList;
        ListView list;
        Button addCountry, deleteCountry, editCountry;
        Entry country, capital, population, flag;
        public ObservableCollection<Country> countries { get; set; }
        public class Country
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public string Population { get; set; }
            public string Flag { get; set; }

        }
        public CountryPage()
        {
            countries = new ObservableCollection<Country>
            {
                new Country {Name="Russia", Capital="Moscow", Population="140 mln", Flag="RussiaFlag.jpg"},
                new Country {Name="Estonia", Capital="Tallinn", Population="1,3 mln", Flag="EstoniaFlag.png"},
                new Country {Name="Ireland", Capital="Dublin", Population="5 mln", Flag="IrelandFlag.png"},
            };

            lblList = new Label
            {
                Text = "Countries",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            list = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = countries,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding companyBinding = new Binding { Path = "Capital", StringFormat = "Capital: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Flag");
                    return imageCell;
                })
            };

            list.ItemSelected += SelectCountry;
            country = new Entry
            {
                Placeholder = "Country"
            };
            capital = new Entry
            {
                Placeholder = "Capital"
            };
            population = new Entry
            {
                Placeholder = "Population"
            };
            flag = new Entry
            {
                Placeholder = "FlagPic"
            };
            addCountry = new Button { Text = "Add Contry" };
            addCountry.Clicked += AddCountry;

            deleteCountry = new Button { Text = "Delete Country" };
            deleteCountry.Clicked += DeleteCountry;

            editCountry = new Button { Text = "Edit Country" };
            editCountry.Clicked += EditCountry;

            Content = new StackLayout { Children = { lblList, list, country, capital, population, flag, addCountry, editCountry, deleteCountry } };
        }
        private async void AddCountry(object sender, EventArgs e)
        {
            var name = country.Text;
            if (countries.Any(x => x.Name == name))
            {
                await DisplayAlert("Warning:", "Country already exists", "OK");
            }
            else
            {
                countries.Add(new Country { Name = country.Text, Capital = capital.Text, Population = population.Text, Flag = flag.Text });
            }
        }

        private void DeleteCountry(object sender, EventArgs e)
        {
            Country c = list.SelectedItem as Country;
            if (c != null)
            {
                countries.Remove(c);
                list.SelectedItem = null;
            }
        }
        private void EditCountry(object sender, EventArgs e)
        {
            Country c = list.SelectedItem as Country;

            var name = country.Text;
            if (countries.Any(x => x.Name == name))
            {
                DisplayAlert("Warning:", "Counry already exists", "OK");
            }

            else
            {
                if (c != null)
                {
                    countries.Remove(c);
                    list.SelectedItem = null;
                }
                countries.Add(new Country { Name = country.Text, Capital = capital.Text, Population = population.Text, Flag = flag.Text });

            }
        }

        private async void SelectCountry(object sender, SelectedItemChangedEventArgs e)
        {
            var country = ((ListView)sender).SelectedItem as Country;
            if (country == null)
                return;
            await DisplayAlert("Information:", "Country:" + country.Name + "\n Capital:" + country.Capital + " \n Population:" + country.Population, "Ok");
        }

    }
}