using MathInput.DependService;
using System.Windows;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathInput.WinPhone.DependService.ClipboardService))]
namespace MathInput.WinPhone.DependService
{
    class ClipboardService : IClipboard
    {
        public void CopyToClipboard(string Text)
        {
            Clipboard.SetText(Text);
        }
    }
}
