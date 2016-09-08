using MathInput.Resources;
using Xamarin.Forms;

namespace MathInput.Views
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = Language.About;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = Language.About,FontSize=Font.SystemFontOfSize(NamedSize.Large).FontSize,HorizontalTextAlignment=TextAlignment.Center },
                    new Label {Text=Language.AboutDetails,FontSize=Font.SystemFontOfSize(NamedSize.Medium).FontSize }                    
                }
            };
        }
    }
}
