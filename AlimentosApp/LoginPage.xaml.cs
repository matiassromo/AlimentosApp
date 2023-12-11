using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AlimentosApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnIngresar(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NavigationPage(new AlimentoPage()));
		var toast = Toast.Make("Login Exitoso", ToastDuration.Short, 14);
		await toast.Show();
    }
}