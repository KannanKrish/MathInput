using MathInput.DependService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathInput.iOS.DependService.ClipboardService))]
namespace MathInput.iOS.DependService
{
    class ClipboardService : IClipboard
    {
        public void CopyToClipboard(string Text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = Text;
        }
    }
}
