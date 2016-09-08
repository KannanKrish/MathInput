using MathInput.DependService;
using MathInput.Resources;
using System;
using System.Threading.Tasks;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Services.Media;

namespace MathInput.Views
{
    public partial class OCRPage : ContentPage
    {
        private readonly IMediaPicker _mediaPicker;
        private readonly ITesseractApi _tesseract;
        public OCRPage()
        {
            InitializeComponent();
            LoadImageButton.Text = Language.OCRPageLoadImageButton;
            GetPhotoButton.Text = Language.OCRPageGetPhotoButton;
            Copy.Text = Language.ToolbarCopy;
            _mediaPicker = Resolver.Resolve<IMediaPicker>();
            _tesseract = Resolver.Resolve<ITesseractApi>();
        }
        private async void LoadImageButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions());
                if (result != null)
                    await Recognise(result);
            }
            catch (Exception)
            {
                await DisplayAlert(Language.DisplayAlertFailed, Language.OCRPageLoadError, Language.DisplayAlertOK);
            }
        }

        private async void GetPhotoButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions());
                if (result != null)
                    await Recognise(result);
            }
            catch (Exception)
            {
                await DisplayAlert(Language.DisplayAlertFailed, Language.OCRPageCaptureError, Language.DisplayAlertOK);
            }
        }

        private async void CopyButton_OnClicked(object sender, EventArgs e)
        {
            if (!TextLabel.Text.Equals(""))
            {
                IClipboard clipboard = DependencyService.Get<IClipboard>();
                clipboard.CopyToClipboard(TextLabel.Text);
                await DisplayAlert(Language.DisplayAlertSuccess, Language.DisplayAlertMessage, Language.DisplayAlertOK);
            }
        }

        async Task Recognise(MediaFile result)
        {
            if (result.Source == null)
                return;
            try
            {
                activityIndicator.IsRunning = true;
                if (!_tesseract.Initialized)
                {
                    var initialised = await _tesseract.Init("eng+equ");
                    if (!initialised)
                        return;
                }
                if (!await _tesseract.SetImage(result.Source))
                    return;
            }
            catch (Exception ex)
            {
                await DisplayAlert(Language.DisplayAlertFailed, ex.Message, Language.DisplayAlertOK);
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
            TextLabel.Text = _tesseract.Text;
            var words = _tesseract.Results(PageIteratorLevel.Word);
            var symbols = _tesseract.Results(PageIteratorLevel.Symbol);
            var blocks = _tesseract.Results(PageIteratorLevel.Block);
            var paragraphs = _tesseract.Results(PageIteratorLevel.Paragraph);
            var lines = _tesseract.Results(PageIteratorLevel.Textline);
        }
    }
}
