using MathInput.DependService;
using MathInput.Resources;
using Xamarin.Forms;

namespace MathInput.Views
{
    class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            string[] pages = new string[]
            {
                Language.MathInput,Language.ImageOCR,Language.Privacy,Language.Feedback,Language.About
            };
            ListView listViewPage = new ListView();
            listViewPage.ItemsSource = pages;
            listViewPage.ItemSelected += (s, e) =>
            {
                if (e.SelectedItem != null)
                {
                    IsPresented = false;
                    listViewPage.SelectedItem = null;
                    if (e.SelectedItem.ToString() == Language.MathInput)
                    {
                        Detail = new MathInputPage();
                        ToolbarItems.Clear();
                        ToolbarItemMathInput(this);
                    }
                    if (e.SelectedItem.ToString() == Language.ImageOCR)
                    {
                        ToolbarItems.Clear();
                        Detail = new OCRPage();
                    }
                    if (e.SelectedItem.ToString() == Language.Privacy)
                    {
                        ToolbarItems.Clear();
                        Detail = new PrivacyPage();
                    }
                    if (e.SelectedItem.ToString() == Language.Feedback)
                    {
                        ToolbarItems.Clear();
                        Detail = new FeedbackPage();
                    }
                    if (e.SelectedItem.ToString() == Language.About)
                    {
                        ToolbarItems.Clear();
                        Detail = new AboutPage();
                    }
                }
            };
            Master = new ContentPage
            {
                Title = Language.AppName,
                Content = listViewPage
            };
            Detail = new MathInputPage();
            ToolbarItemMathInput(this);
        }

        private void ToolbarItemMathInput(RootPage rootPage)
        {
            ToolbarItem Clear = new ToolbarItem() { Text = Language.ToolbarClear };
            Clear.Clicked += (s2, e2) => MathInputPage.entry.Text = "";
            ToolbarItem Copy = new ToolbarItem() { Text = Language.ToolbarCopy };
            Copy.Clicked += (s2, e2) =>
            {
                if (!MathInputPage.entry.Text.Equals(""))
                {
                    IClipboard clipboard = DependencyService.Get<IClipboard>();
                    clipboard.CopyToClipboard(MathInputPage.entry.Text);
                    DisplayAlert(Language.DisplayAlertSuccess, Language.DisplayAlertMessage, Language.DisplayAlertOK);
                }
            };
            rootPage.ToolbarItems.Add(Clear);
            rootPage.ToolbarItems.Add(Copy);
        }
    }
}
