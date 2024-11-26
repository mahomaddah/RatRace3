using Syncfusion.Licensing;

namespace RatRace3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
      
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH5ccHVURmJZWUJwV0U=");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            UserAppTheme = AppTheme.Dark;
            return new Window(new AppShell());
        }
    }
}