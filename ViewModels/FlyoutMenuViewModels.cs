using CommunityToolkit.Mvvm.Input;
using DancellApp.Models;
using DancellApp.Services;
using DancellApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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
            int indName = User.Nombre.IndexOf(" ");
            var name = User.Nombre.Substring(0, indName);
            int indLastName = User.Apellido.IndexOf(" ");
            var lastName = User.Apellido.Substring(0, indLastName);
            NameProfile = name + " " + lastName;
            menu = new List<MenuItemModel>();
            LoadMenu();
            PickImageCommand = new Command(() => DoPickImage());
        }

        public FlyoutMenuViewModels(Usuario user)
        {
            User = user;
        }
        #endregion

        #region Attributes
        private Usuario user;
        readonly IList<MenuItemModel> menu;
        private string text;
        private string nameProfile;
        MenuItemModel selectedItem;
        private ImageSource image;
        private bool isImageVisible;
        #endregion

        #region Propperties
        public Usuario User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string NameProfile
        {
            get => nameProfile;
            set => SetProperty(ref nameProfile, value);
        }
        public ImageSource Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        public bool IsImageVisible
        {
            get => isImageVisible;
            set => SetProperty(ref isImageVisible, value);
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
        public ICommand PickImageCommand { get; }
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

        async Task<FileResult> PickAndShow(MediaPickerOptions options)
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync(options);

                if (result != null)
                {
                    var size = await GetStreamSizeAsync(result);

                    Text = $"File Name: {result.FileName} ({size:0.00} KB)";

                    var ext = Path.GetExtension(result.FileName).ToLowerInvariant();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        var stream = await result.OpenReadAsync();

                        Image = ImageSource.FromStream(() => stream);
                        IsImageVisible = true;
                    }
                    else
                    {
                        IsImageVisible = false;
                    }
                }
                else
                {
                    Text = $"Pick cancelled.";
                }

                return result;
            }
            catch (Exception ex)
            {
                Text = ex.ToString();
                IsImageVisible = false;
                return null;
            }
        }

        async Task<double> GetStreamSizeAsync(FileResult result)
        {
            try
            {
                using var stream = await result.OpenReadAsync();
                return stream.Length / 1024.0;
            }
            catch
            {
                return 0.0;
            }
        }

        async void DoPickImage()
        {
            var options = new MediaPickerOptions
            {
                Title = "Please select an image"
            };

            await PickAndShow(options);
        }
        #endregion

        #region Commands

        #endregion

    }
}
