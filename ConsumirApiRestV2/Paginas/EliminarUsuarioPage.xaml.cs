using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class EliminarUsuarioPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public EliminarUsuarioPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var userId = EntryUserId.Text;
            var url = $"https://api.escuelajs.co/api/v1/users/{userId}";

            var resp = await _httpClient.DeleteAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario eliminado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar el usuario", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}