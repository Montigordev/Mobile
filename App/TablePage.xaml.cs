using Plugin.Messaging;
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
    public partial class TablePage : ContentPage
    {
        TableView tabelview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection, lisa;
        ViewCell viewCell;
        Button emailBtn, smsBtn, callBtn;
        EntryCell callCell, smsCell, emailCell;
        public TablePage()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += ScOnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("patrick.jpg"),
                Text = "Patrick",
                Detail = "Smart guy"
            };

            emailBtn = new Button
            {
                Text = "Send email",
                HorizontalOptions = LayoutOptions.Center
            };
            emailBtn.Clicked += emailBtnPressed;
            smsBtn = new Button
            {
                Text = "Send sms",
                HorizontalOptions = LayoutOptions.Center
            };
            smsBtn.Clicked += smsBtnPressed;

            callBtn = new Button
            {
                Text = "Make a call",
                HorizontalOptions = LayoutOptions.Center
            };

            callBtn.Clicked += callBtnPressed;
            fotosection = new TableSection();
            lisa = new TableSection();
            callCell = new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            };
            emailCell = new EntryCell
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email
            };
            smsCell = new EntryCell
            {
                Label = "SMS",
                Placeholder = "Sisesta SMS",
                Keyboard = Keyboard.Email
            };


            tabelview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sisesta oma sõbra nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        callCell,
                        emailCell,
                        smsCell,
                        sc
                    },
                    fotosection,
                    lisa
                }
            };

            viewCell = new ViewCell
            {
                View = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        emailBtn, smsBtn, callBtn
                    }
                }
            };
            lisa.Add(viewCell);
            Content = tabelview;
        }

        private void callBtnPressed(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if(call.CanMakePhoneCall)
            {
                call.MakePhoneCall(callCell.Text);
            }
        }

        private void smsBtnPressed(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if(sms.CanSendSms)
            {
               sms.SendSms(callCell.Text, smsCell.Text);
            }
        }

        private void emailBtnPressed(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if(mail.CanSendEmail)
            {
                mail.SendEmail(emailCell.Text,"Subject","SomeText");
            }
        }

        private void ScOnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }

        }
    }
}