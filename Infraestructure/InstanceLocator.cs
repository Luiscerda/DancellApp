using DancellApp.ViewModels;

namespace DancellApp.Infraestructure
{
    public class InstanceLocator
    {
        #region Properties
        public MainViewModels MainView { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator() { this.MainView = new MainViewModels(); }
        #endregion

    }
}
