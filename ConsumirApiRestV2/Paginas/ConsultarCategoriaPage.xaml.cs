using ConsumirApiRestV2.Models;
using System.Text.Json;
using System.Net.Http;


namespace ConsumirApiRestV2.Paginas;

public partial class ConsultarCategoriaPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ConsultarCategoriaPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var idCategoria = EntryCodigoCategoria.Text;

        if (string.IsNullOrEmpty(idCategoria))
        {
            await DisplayAlert("Error", "Por favor ingrese un código de categoría válido", "OK");
            return;
        }

        try
        {
            var url = $"https://api.escuelajs.co/api/v1/categories/{idCategoria}";
            var resp = await _httpClient.GetAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                var responseBody = await resp.Content.ReadAsStringAsync();
                var category = JsonSerializer.Deserialize<CategoryId>(responseBody);

                if (category is not null)
                {
                    EntryTituloProducto.Text = category.Name;
                    Img.Source = category.Image;
                }
            }
            else
            {
                LimpiarCampos();
                await DisplayAlert("Resultado", "No se ha encontrado una categoría con el código proporcionado", "OK");
            }
        }
        catch (Exception ex)
        {
            LimpiarCampos();
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }

    private void LimpiarCampos()
    {
        EntryCodigoCategoria.Text = string.Empty;
        EntryTituloProducto.Text = string.Empty;
        Img.Source = null;
    }
}

