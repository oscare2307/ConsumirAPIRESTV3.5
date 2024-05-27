using ConsumirApiRestV2.Models;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class ConsultarProductoPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ConsultarProductoPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var idProducto = EntryCodigoProducto.Text;

        try
        {
            var url = $"https://api.escuelajs.co/api/v1/products/{idProducto}";
            var resp = await _httpClient.GetAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                var responseBody = await resp.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Products>(responseBody);

                if (product != null)
                {
                    EntryTituloProducto.Text = product.Title;
                    EntryPrecioProducto.Text = product.Price.ToString();
                    EntryCategoriaProducto.Text = product.Category?.Name;
                    EntryDescripcionProducto.Text = product.Description;

                    if (product.Images != null && product.Images.Count > 0)
                    {
                        CarouselViewImages.ItemsSource = product.Images;
                    }
                    else
                    {
                        CarouselViewImages.ItemsSource = null;
                    }
                }
                else
                {
                    LimpiarCampos();
                    await DisplayAlert("Resultado", "No se ha encontrado un producto con ese ID", "OK");
                }
            }
            else
            {
                LimpiarCampos();
                await DisplayAlert("Resultado", "No se ha encontrado un producto con ese ID", "OK");
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
        EntryTituloProducto.Text = string.Empty;
        EntryPrecioProducto.Text = string.Empty;
        EntryCategoriaProducto.Text = string.Empty;
        EntryDescripcionProducto.Text = string.Empty;
        CarouselViewImages.ItemsSource = null;
    }
}


