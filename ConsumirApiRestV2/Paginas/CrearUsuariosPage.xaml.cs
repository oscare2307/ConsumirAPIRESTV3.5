using System.Text.Json;
using System.Text;
using ConsumirApiRestV2.Models;

namespace ConsumirApiRestV2.Paginas;

public partial class CrearUsuariosPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public CrearUsuariosPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nuevoUsuario = new CrearUsuario
            {
                Name = EntryNombre.Text,
                Email = EntryEmail.Text,
                Password = EntryPassword.Text,
                Avatar = EntryAvatar.Text
            };

            var url = "https://api.escuelajs.co/api/v1/users/";
            var json = JsonSerializer.Serialize(nuevoUsuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PostAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario creado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el usuario", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}