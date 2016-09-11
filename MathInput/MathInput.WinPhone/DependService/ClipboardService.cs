using MathInput.DependService;
using Windows.ApplicationModel.DataTransfer;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathInput.WinPhone.DependService.ClipboardService))]
namespace MathInput.WinPhone.DependService
{
    class ClipboardService : IClipboard
    {
        public void CopyToClipboard(string Text)
        {
            

        }
    }
}
