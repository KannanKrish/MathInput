using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using XLabs.Platform.Services.Media;
using Tesseract.Droid;
using Tesseract;
using XLabs.Ioc;
using Autofac;
using XLabs.Ioc.Autofac;

namespace MathInput.Droid
{
    [Activity(Label = "MathInput", Icon = "@drawable/icon", MainLauncher = true, WindowSoftInputMode = SoftInput.AdjustPan, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var containerBuilder = new Autofac.ContainerBuilder();

            containerBuilder.Register(c => this).As<Context>();
            containerBuilder.RegisterType<MediaPicker>().As<IMediaPicker>();
            containerBuilder.RegisterType<TesseractApi>()
                .As<ITesseractApi>()
                .WithParameter((pi, c) => pi.ParameterType == typeof(AssetsDeployment),
                (pi, c) => AssetsDeployment.OncePerVersion);

            Resolver.SetResolver(new AutofacResolver(containerBuilder.Build()));

            LoadApplication(new App());
        }
    }
}

