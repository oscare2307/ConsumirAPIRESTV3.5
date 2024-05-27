using System.Text.Json;
using System.Text;
using ConsumirApiRestV2.Models;

namespace ConsumirApiRestV2.Paginas;

public partial class ActualizarUsuarioPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ActualizarUsuarioPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var userId = EntryUserId.Text;
            var updatedUser = new ActualizarUsuario
            {
                Email = EntryEmail.Text,
                Name = EntryName.Text
            };

            var url = $"https://api.escuelajs.co/api/v1/users/{userId}";
            var json = JsonSerializer.Serialize(updatedUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PutAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario actualizado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el usuario", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}
