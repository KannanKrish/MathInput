using MathInput.Resources;
using Xamarin.Forms;

namespace MathInput.Views
{
    public class PrivacyPage : ContentPage
    {
        public PrivacyPage()
        {
            Title = Language.Privacy;
            string content = @"<html><head><title>Privacy Policy</title></head><body><h2>Privacy Policy</h2><p>This Privacy Policy explains our policy regarding the collection and use of your information. As we update and expand our products, this policy may change, so please refer back to it periodically. By accessing our website or using our apps, you consent to our information practices.</p><h2>What information do we collect?</h2><ul><li>We are not collect any information from our clients.</li><li>We are only provide the information to clients.</li></ul><h2>California Online Privacy Protection Act Compliance</h2><p>Because we value your privacy we have taken the necessary precautions to be in compliance with the California Online Privacy Protection Act. We therefore will not distribute your personal information to outside parties without your consent.</p><p>As part of the California Online Privacy Protection Act, all users of our site may make any changes to their information by emailing us.</p><h2>Children Online Privacy Protection Act Compliance</h2><p>We are in compliance with the requirements of COPPA (Children Online Privacy Protection Act), we do not collect any information from anyone under 13 years of age. Our website, products and services are all directed to people who are at least 13 years old or older.</p><h2>Changes to our Privacy Policy</h2><p>If we decide to change our privacy policy, we will post those changes on this page, and/or update the Privacy Policy modification date below.</p><p>This policy was last modified on 05-Dec-2015.</p><h2>Contacting Us</h2><p>If there are any questions regarding this privacy policy you may contact us using the information below.</p>Website : <a href=""http://himalayatechnology.in"" target=""_self"">himalayatechnology.in</a><br/>Mail : <a href=""mailto:ckannan759153@gmail.com?Subject=Himalaya Browser Privacy"" target=""_self"">ckannan759153@gmail.com</a></body></html>";
            var webSource = new HtmlWebViewSource();
            webSource.Html = content;
            Content = new StackLayout
            {
                Children = {
                    new WebView {Source=webSource,VerticalOptions=LayoutOptions.FillAndExpand,HorizontalOptions=LayoutOptions.FillAndExpand }
                }
            };
        }
    }
}
