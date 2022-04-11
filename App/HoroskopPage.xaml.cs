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
    public partial class HoroskopPage : ContentPage
    {
        DatePicker date;
        DateTime dateTime;
        Image img;
        Label name, description;
        public HoroskopPage()
        {
            date = new DatePicker
            {
                Format = "D",
                MinimumDate = new DateTime(2022, 1, 1),
                MaximumDate = new DateTime(2022, 12, 31)
            };
            date.DateSelected += DateSelected;
            img = new Image
            {
                Source = ImageSource.FromFile("horoscope.jpg"),
            };
            name = new Label
            {
                Text = "Выбери дату",
                FontSize = 26,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            description = new Label
            {
                Text = "Получи знак зодиака",
                FontSize = 26,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout st = new StackLayout
            {
                Children = {date,img,name,description}
            };
            Content = st;
        }
        private void SetHoroscope(string _name, string _desc, String _img)
        {
            name.Text = _name;
            description.Text = _desc;
            img.Source = _img;
        }
        private void DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;
            switch (m)
            {
                case 1:
                    if(d>=20)
                    {
                        SetHoroscope("Водолей", "Водолей - одаренный воображением, идеалистический, интуитивный", "iWater.png");
                    }
                    else
                    {
                        SetHoroscope("Козерог", "Козерог - дотошный, умный, деятельный", "iLambHorns.png");
                    }
                    break;
                case 2:
                    if (d >= 20)
                    {
                        SetHoroscope("Рыбы", "Рыбы - справдливый, гибкий, спокойный", "iFish.png");
                    }
                    else
                    {
                        SetHoroscope("Водолей", "Водолей - одаренный воображением, идеалистический, интуитивный", "iWater.png");
                    }
                    break;
                case 3:
                    if (d >= 21)
                    {
                        SetHoroscope("Овен", "Овен- упрямый, своевольный, добрый", "iLamb.png");
                    }
                    else
                    {
                        SetHoroscope("Рыбы", "Рыбы - справдливый, гибкий, спокойный", "iFish.png");
                    }
                    break;
                case 4:
                    if (d >= 21)
                    {
                        SetHoroscope("Овен", "Телец - спокойный, умный, красивый", "iBull.png");
                    }
                    else
                    {
                        SetHoroscope("Овен", "Овен - упрямый, своевольный, добрый", "iLamb.png");
                    }
                    break;
                case 5:
                    if (d >= 21)
                    {
                        SetHoroscope("Близнецы", "Близнецы - утончённый, умный, внимательный", "iTwins.png");
                    }
                    else
                    {
                        SetHoroscope("Овен", "Телец - спокойный, умный, красивый", "iBull.png");
                    }
                    break;
                case 6:
                    if (d >= 21)
                    {
                        SetHoroscope("Рак", "Рак - добрый, настойчивый, внимательный", "iCrab.png");
                    }
                    else
                    {
                        SetHoroscope("Близнецы", "Близнецы - утончённый, умный, внимательный", "iTwins.png");
                    }
                    break;
                case 7:
                    if (d >= 23)
                    {
                        SetHoroscope("Лев", "Лев- добрый, лидер, сильный", "iLion.png");
                    }
                    else
                    {
                        SetHoroscope("Рак", "Рак - добрый, настойчивый, внимательный", "iCrab.png");
                    }
                    break;
                case 8:
                    if (d >= 23)
                    {
                        SetHoroscope("Дева", "Дева - целеустремлённый, изысканый, добрый", "iGirl.png");
                    }
                    else
                    {
                        SetHoroscope("Лев", "Лев- добрый, лидер, сильный", "iLion.png");
                    }
                    break;
                case 9:
                    if (d >= 23)
                    {
                        SetHoroscope("Весы", "Весы- уравновешенный, терпеливый, красивый", "iWeight.png");
                    }
                    else
                    {
                        SetHoroscope("Дева", "Дева - целеустремлённый, изысканый, добрый", "iGirl.png");
                    }
                    break;
                case 10:
                    if (d >= 23)
                    {
                        SetHoroscope("Скорпион", "Скорпион- противный, ядовитый, красивый", "iScorpion.png");
                    }
                    else
                    {
                        SetHoroscope("Весы", "Весы- уравновешенный, терпеливый, красивый", "iWeight.png");
                    }
                    break;
                case 11:
                    if (d >= 23)
                    {
                        SetHoroscope("Стрелец", "Стрелец- политик, лидер и борец", "iSaggitarius.png");
                    }
                    else
                    {
                        SetHoroscope("Скорпион", "Скорпион- противный, ядовитый, красивый", "iScorpion.png");
                    }
                    break;
                case 12:
                    if (d >= 22)
                    {
                        SetHoroscope("Козерог", "Козерог - дотошный, умный, деятельный", "iLambHorns.png");
                    }
                    else
                    {
                        SetHoroscope("Стрелец", "Стрелец- политик, лидер, и борец", "iSaggitarius.png");
                    }
                    break;
                default:
                    name.Text = "Error";
                    break;
            }
        }
    }
}