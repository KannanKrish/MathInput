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
                    new Label { Text = Language.About }
                }
            };
        }
    }
}
