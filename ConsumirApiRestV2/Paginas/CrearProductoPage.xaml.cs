using ConsumirApiRestV2.Models;
using System.Text;
using System.Text.Json;
using System.Net.Http;


namespace ConsumirApiRestV2.Paginas;

public partial class CrearProductoPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public CrearProductoPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nuevoProducto = new CrearProducts
            {
                Title = EntryTitulo.Text,
                Price = decimal.Parse(EntryPrecio.Text),
                Description = EntryDescripcion.Text,
                CategoryId = 1, // Asignar la categoría correspondiente
                Images = new List<string> { EntryImagen.Text }
            };

            var url = "https://api.escuelajs.co/api/v1/products/";
            var json = JsonSerializer.Serialize(nuevoProducto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _httpClient.PostAsync(url, content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Producto creado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el producto", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Se ha producido un error: {ex.Message}", "OK");
        }
    }
}


