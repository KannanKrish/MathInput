using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MathInput.Views
{
    public class DonatePage : ContentPage
    {
        public static HtmlWebViewSource DonationURI = new HtmlWebViewSource();
        public DonatePage()
        {
            Content = new StackLayout
            {
                Children = {
                   new WebView { Source=DonationURI,HorizontalOptions = LayoutOptions.FillAndExpand,VerticalOptions = LayoutOptions.FillAndExpand}
                }
            };
        }
    }
}