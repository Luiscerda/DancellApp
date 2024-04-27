using DancellApp.Models;
using DancellApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.ViewModels
{
    public  class ProfileViewModels : BaseViewModels
    {
        #region Services
        private DataBaseConstants baseConstants;
        #endregion

        #region Attributes
        private Usuario user;
        #endregion

        #region Constructor
        public ProfileViewModels()
        {
            baseConstants = new DataBaseConstants();
            User = baseConstants.GetUserAsync();
        }
        #endregion

        #region Properties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        #endregion
    }
}
