using DancellApp.Models;
using DancellApp.Services;
using System.Collections.ObjectModel;

namespace DancellApp.ViewModels
{
    public class FlyoutMenuViewModels : BaseViewModels
    {
        #region Services
        private DataBaseConstants baseConstants;
        #endregion

        #region Constructor
        public FlyoutMenuViewModels()
        {
            baseConstants = new DataBaseConstants();
            User = baseConstants.GetUserAsync();
            menu = new List<MenuItemModel>();
            LoadMenu();

        }

        public FlyoutMenuViewModels(Usuario user)
        {
            User = user;
        }
        #endregion

        #region Attributes
        private Usuario user;
        readonly IList<MenuItemModel> menu;
        #endregion

        #region Propperties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public ObservableCollection<MenuItemModel> MenuItems { get; private set; }
        
        #endregion

        #region Methods

        public void LoadMenu() 
        {
            menu.Add(new MenuItemModel 
            { 
                Icon = "home", 
                Name = "INICIO" 
            });
            menu.Add(new MenuItemModel
            {
                Icon = "user",
                Name = "PERFIL"
            });

            MenuItems = new ObservableCollection<MenuItemModel>(menu);
        }
        #endregion

    }
}
