using MathInput.DependService;
using Windows.ApplicationModel.DataTransfer;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathInput.UW.DependService.ClipboardService))]

namespace MathInput.UW.DependService
{
    class ClipboardService : IClipboard
    {
        public void CopyToClipboard(string Text)
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(Text);
            Clipboard.SetContent(dataPackage);
        }
    }
}
