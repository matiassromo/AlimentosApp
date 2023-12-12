using AlimentosApp.Models;
using AlimentosApp.Services;

namespace AlimentosApp;

public partial class DetalleAlimentosPage : ContentPage
{

    private Alimento alimento;
    private readonly APIService aPIService;
    public DetalleAlimentosPage(APIService apiservice)
    {
        InitializeComponent();
        aPIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        alimento = BindingContext as Alimento;
        if (alimento != null)
        {
            Nombre.Text = alimento.Nombre;
            Descripcion.Text = alimento.Descripcion;
            Cantidad.Text = alimento.Cantidad.ToString();
        }

    }

    private void OnAgregarAlimento(object sender, EventArgs e)
    {
    }

    private void OnIncremento(object sender, EventArgs e)
    {
        alimento.Cantidad++;
        Cantidad.Text = alimento.Cantidad.ToString();
    }

    private void OnDecremento(object sender, EventArgs e)
    {
        if (alimento.Cantidad > 1)
        {
            alimento.Cantidad--;
            Cantidad.Text = alimento.Cantidad.ToString();
        }
    }
}