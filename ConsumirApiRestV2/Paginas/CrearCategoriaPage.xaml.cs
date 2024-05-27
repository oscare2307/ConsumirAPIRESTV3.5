using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class CrearCategoriaPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public CrearCategoriaPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nuevaCategoria = new CrearNuevaCategoria
            {
                Name = EntryNombre.Text,
                Image = EntryImagen.Text
            };

            var url = "https://api.escuelajs.co/api/v1/categories/";
            var json = JsonSerializer.Serialize(nuevaCategoria);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PostAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Categoría creada correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear la categoría", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}