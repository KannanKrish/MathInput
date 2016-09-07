using MathInput.Resources;
using Plugin.Messaging;
using System.Linq;

using Xamarin.Forms;

namespace MathInput.Views
{
    public class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            Title = Language.Feedback;

            //StackLayout 1
            StackLayout layout1 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Label layout1_label = new Label() { Text = Language.layout1_labelText, FontSize = Font.SystemFontOfSize(NamedSize.Large).FontSize };
            Entry layout1_entry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            layout1.Children.Add(layout1_label);
            layout1.Children.Add(layout1_entry);

            //StackLayout 2
            StackLayout layout2 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Picker layout2_entry = new Picker() { HorizontalOptions = LayoutOptions.FillAndExpand };
            Label layout2_label = new Label() { Text = Language.layout2_labelText, FontSize = Font.SystemFontOfSize(NamedSize.Large).FontSize };
            layout2_entry.Items.Add(Language.FeedbackItem1);
            layout2_entry.Items.Add(Language.FeedbackItem2);
            layout2_entry.Items.Add(Language.FeedbackItem3);
            layout2_entry.Items.Add(Language.FeedbackItem4);
            layout2.Children.Add(layout2_label);
            layout2.Children.Add(layout2_entry);

            //StackLayout 3
            StackLayout layout3 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Label layout3_label = new Label() { Text = Language.layout3_labelText, FontSize = Font.SystemFontOfSize(NamedSize.Large).FontSize };
            Entry layout3_entry = new Entry() { HeightRequest = 50, HorizontalOptions = LayoutOptions.FillAndExpand };
            layout3.Children.Add(layout3_label);
            layout3.Children.Add(layout3_entry);

            // Donation Layout
            StackLayout layout4 = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Label layout4_label = new Label() { Text = Language.layout4_labelText, FontSize = Font.SystemFontOfSize(NamedSize.Large).FontSize };
            string donationURL = @"<form name=""_xclick"" action=""https://www.paypal.com/cgi-bin/webscr"" method=""post""><input type=""hidden"" name=""cmd"" value=""_xclick""><input type=""hidden"" name=""business"" value=""ckannan759153@gmail.com""><input type=""hidden"" name=""item_name"" value=""Donation for Development""><input type=""hidden"" name=""currency_code"" value=""USD""><input type=""hidden"" name=""amount"" value=""25.00""><input type=""image"" src=""https://www.paypal.com/en_US/i/btn/btn_donate_LG.gif"" border=""0"" name=""submit"" alt=""Make a donation with PayPal""></form>";
            var webSource = new HtmlWebViewSource();
            webSource.Html = donationURL;
            Entry amount = new Entry() { Placeholder = Language.AmountPlaceholder, Keyboard = Keyboard.Numeric };
            Button makeDonation = new Button() { Text = Language.Donate, HorizontalOptions = LayoutOptions.End, TranslationX = -5 };
            string previousAmount = null;
            makeDonation.Clicked += (s, e) =>
            {
                if (amount.Text.ToString().Equals("")) return;
                if (donationURL.Contains("25.00"))
                {
                    donationURL = donationURL.Replace("25.00", amount.Text.ToString());
                    previousAmount = amount.Text.ToString();
                }
                else
                {
                    donationURL = donationURL.Replace(previousAmount, amount.Text.ToString());
                    previousAmount = amount.Text.ToString();
                }
                DonatePage.DonationURI.Html = donationURL;
                Navigation.PushAsync(new DonatePage());
            };
            layout4.Children.Add(layout4_label);
            layout4.Children.Add(amount);

            Button btn = new Button() { Text = Language.EmailSend, HorizontalOptions = LayoutOptions.EndAndExpand };
            btn.Clicked += (s, e) =>
            {
                var emailTask = MessagingPlugin.EmailMessenger;
                if (emailTask.CanSendEmail)
                {
                    emailTask.SendEmail(Language.FeedbackMail, Language.AppName + " " + layout2_entry.Items.ElementAt(layout2_entry.SelectedIndex), "Name : " + layout1_entry.Text + "\n" + "Message : " + layout3_entry.Text);
                }
                else
                    DisplayAlert(Language.DisplayAlertFailed, Language.DisplayAlertFailedMessage, Language.DisplayAlertOK);
            };

            ScrollView scrollView = new ScrollView();
            scrollView.Content = new StackLayout
            {
                Children = {
                    new Label { Text = Language.Feedback,FontSize = Font.SystemFontOfSize(NamedSize.Large).FontSize,HorizontalTextAlignment=TextAlignment.Center },
                    layout1,layout2,layout3,btn,layout4,makeDonation
                },
                Padding = new Thickness(20)
            };
            Content = new StackLayout
            {
                Children = { scrollView }
            };
        }
    }
}
