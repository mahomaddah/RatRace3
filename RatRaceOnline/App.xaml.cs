using Syncfusion.Licensing;

namespace RatRace3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
      
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH1cc3VVRmhYWE1xXUI=");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            UserAppTheme = AppTheme.Dark;
            return new Window(new AppShell());
        }
    }
}