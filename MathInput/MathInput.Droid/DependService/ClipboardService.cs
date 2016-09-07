using Android.Content;
using MathInput.DependService;
using Xamarin.Forms;

[assembly: Dependency(typeof(MathInput.Droid.DependService.ClipboardService))]
namespace MathInput.Droid.DependService
{
    class ClipboardService : IClipboard
    {
        public void CopyToClipboard(string Text)
        {
            // Get the Clipboard Manager
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);

            // Create a new Clip
            ClipData clip = ClipData.NewPlainText("xxx_title", Text);

            // Copy the text
            clipboardManager.PrimaryClip = clip;
        }
    }
}