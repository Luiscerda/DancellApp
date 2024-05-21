using System.Globalization;

namespace DancellApp.Views;

public partial class ComitionPage : ContentPage
{
	public ComitionPage()
	{
		InitializeComponent();
	}
    //private void EntryEfectivo_Completed(object sender, EventArgs e)
    //{
    //    var value = string.IsNullOrEmpty(entryEfectivo.Text) ? 0 : entryEfectivo.Text.Contains('$') ? 
    //        Convert.ToDecimal(entryEfectivo.Text.Replace("$", "").Replace(",", "")) : Convert.ToDecimal(entryEfectivo.Text);
    //    var restante = string.IsNullOrEmpty(labelRestante.Text) ? 0 : labelRestante.Text.Contains('$') ?
    //        Convert.ToDecimal(labelRestante.Text.Replace("$", "").Replace(",", "")) : Convert.ToDecimal(labelRestante.Text);
    //    var resta = value - restante;
    //    entryEfectivo.Text = value.ToString("C0", CultureInfo.CurrentCulture);
    //    labelRestante.Text = resta.ToString("C0", CultureInfo.CurrentCulture);
    //}
}