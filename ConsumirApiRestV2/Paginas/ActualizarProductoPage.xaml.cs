using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class ActualizarProductoPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ActualizarProductoPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var productId = EntryProductId.Text;
            var updatedProduct = new ActualizarProducts
            {
                Title = EntryTitulo.Text,
                Price = decimal.Parse(EntryPrecio.Text)
            };

            var url = $"https://api.escuelajs.co/api/v1/products/{productId}";
            var json = JsonSerializer.Serialize(updatedProduct);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PutAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Producto actualizado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el producto", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}
