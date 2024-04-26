using AndroidX.Navigation;
using CommunityToolkit.Mvvm.Input;
using DancellApp.Models;
using DancellApp.Services;
using DancellApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
        MenuItemModel selectedItem;
        #endregion

        #region Propperties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public MenuItemModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                }
            }
        }

        public ICommand SelectNavPageCommand => new Command<MenuItemModel>(SelectNavPage);
        public ObservableCollection<MenuItemModel> MenuItems { get; private set; }
        
        #endregion

        #region Methods

        public void LoadMenu() 
        {
            menu.Add(new MenuItemModel 
            { 
                Icon = "home", 
                Name = "INICIO",
                TargetType = typeof(HomePage),
            });
            menu.Add(new MenuItemModel
            {
                Icon = "user",
                Name = "PERFIL",
                TargetType = typeof(ProfilePage)
            });

            MenuItems = new ObservableCollection<MenuItemModel>(menu);
        }

        public async void SelectNavPage(MenuItemModel menuItem)
        {
            switch(menuItem.Name)
            {
                case "INICIO":
                    App.Master.IsPresented = false;
                    await App.Navigator.PopAsync();
                    break;
                case "PERFIL":
                    App.Master.IsPresented = false;
                    await App.Navigator.PushAsync(new ProfilePage());                  
                    break;
            }
        }
        #endregion

        #region Commands

        #endregion

    }
}
