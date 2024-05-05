using DancellApp.Models;
using DancellApp.Services;

namespace DancellApp.Views;

public partial class MasterPage : FlyoutPage
{
	public MasterPage()
	{
		InitializeComponent();
        App.Navigator = Navigator;
        App.Master = this;
    }
}