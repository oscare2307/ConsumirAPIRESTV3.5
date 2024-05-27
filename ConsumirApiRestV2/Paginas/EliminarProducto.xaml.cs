using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class EliminarProducto : ContentPage
{
    private readonly HttpClient _httpClient;
    public EliminarProducto()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var productId = EntryProductId.Text;
            var url = $"https://api.escuelajs.co/api/v1/products/{productId}";
            var resp = await _httpClient.DeleteAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Producto eliminado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar el producto", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}
