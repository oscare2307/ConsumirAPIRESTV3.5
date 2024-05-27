using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class ActualizarCategoriaPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ActualizarCategoriaPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var categoriaId = EntryCategoriaId.Text;
            var updatedCategory = new ActualizarCategoria
            {
                Name = EntryNombre.Text
            };

            var url = $"https://api.escuelajs.co/api/v1/categories/{categoriaId}";
            var json = JsonSerializer.Serialize(updatedCategory);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PutAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Categoría actualizada correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar la categoría", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}
