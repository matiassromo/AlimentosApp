using AlimentosApp.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AlimentosApp;



public partial class LoginPage : ContentPage
    
{

    private readonly APIService aPIService;

    public LoginPage(APIService apiservice)
	{
        InitializeComponent();
        aPIService = apiservice;
    }

    private async void OnIngresar(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AlimentoPage(aPIService));
		var toast = Toast.Make("Login Exitoso", ToastDuration.Short, 14);
		await toast.Show();
    }
}