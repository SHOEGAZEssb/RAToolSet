using Caliburn.Micro;

namespace RAToolSetWPF
{
  class AppBootstrapper : BootstrapperBase
  {
    public AppBootstrapper()
    {
      Initialize();
    }

    protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
    {
      if (RAToolSetWPF.Properties.Settings.Default.Username == "" || RAToolSetWPF.Properties.Settings.Default.APIKey == "")
      {
        LoginWindow lw = new LoginWindow();
        lw.ShowDialog();
      }

      DisplayRootViewFor<MainViewModel>();
    }
  }
}