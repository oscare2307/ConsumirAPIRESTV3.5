using System;
using System.Net.Http;
using ConsumirApiRestV2.Models;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class EliminarCategoriaPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public EliminarCategoriaPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var categoriaId = EntryCategoriaId.Text;

        if (string.IsNullOrEmpty(categoriaId))
        {
            await DisplayAlert("Error", "Por favor, ingrese un ID de categor�a v�lido", "OK");
            return;
        }

        try
        {
            var url = $"https://api.escuelajs.co/api/v1/categories/{categoriaId}";
            var resp = await _httpClient.DeleteAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("�xito", "Categor�a eliminada correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar la categor�a", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}
