using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tesseract;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Services.Media;

namespace MathInput.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var containerBuilder = new Autofac.ContainerBuilder();

            //containerBuilder.RegisterType<MediaPicker>().As<IMediaPicker>();
            containerBuilder.RegisterType<ITesseractApi>().As<ITesseractApi>();

            Resolver.SetResolver(new AutofacResolver(containerBuilder.Build()));

            LoadApplication(new MathInput.App());
        }
    }
}
