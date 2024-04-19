using CommunityToolkit.Mvvm.ComponentModel;
using DancellApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.ViewModels
{
    public partial class NavigationViewModels : ObservableObject
    {
        protected readonly INavigationService NavigationService;

        public NavigationViewModels(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }
    }
}
