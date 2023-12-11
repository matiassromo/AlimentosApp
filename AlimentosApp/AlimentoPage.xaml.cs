using AlimentosApp.Models;
using System.Collections.ObjectModel;

namespace AlimentosApp;

public partial class AlimentoPage : ContentPage
{
	public AlimentoPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var productos = new ObservableCollection<Alimento>(Utils.Utils.ListaAlimentos);
        ListaAlimentos.ItemsSource = productos;

    }

    private async void OnNuevoAlimento(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NuevoAlimentoPage());
    }
}