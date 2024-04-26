using DancellApp.Models;

namespace DancellApp.Views;

public partial class MasterPage : FlyoutPage
{
	public MasterPage()
	{
		InitializeComponent();
        App.Navigator = Navigator;
        App.Master = this;
        //flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as MenuItemModel;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    }
}