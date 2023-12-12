using AlimentosApp.Models;
using AlimentosApp.Services;
using System.Collections.ObjectModel;

namespace AlimentosApp;

public partial class AlimentoPage : ContentPage
{

    private readonly APIService aPIService;
    public AlimentoPage(APIService apiservice)
	{
		InitializeComponent();
        aPIService = apiservice;

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Alimento> listaAlimentos = await aPIService.GetPlato();
        var alimentos = new ObservableCollection<Alimento>(listaAlimentos);
        ListaAlimentos.ItemsSource = alimentos;

    }

    private async void OnDetalleAlimentos(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new DetalleAlimentosPage(aPIService));
    }

    private async void OnCarritoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarritoPage());  
    }
}