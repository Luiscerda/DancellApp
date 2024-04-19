using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        #region Properties

        #endregion

        #region ViewModels
        public LoginViewModels LoginView { get; set; }
        public LoginScreenViewModels LoginScreenView { get; set; }
        #endregion

        #region Constructor
        public MainViewModels()
        {
            instance = this;
            this.LoginView = new LoginViewModels();
        }
        #endregion

        #region Singleton
        private static MainViewModels instance;
        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();
            }
            return instance;
        }
        #endregion
    }
}
