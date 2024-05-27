using ConsumirApiRestV2.Models;
using System.Text.Json;

namespace ConsumirApiRestV2.Paginas;

public partial class ConsultarUsuariosPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    public ConsultarUsuariosPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var idUsuario = EntryCodigoUsuario.Text;

        if (string.IsNullOrEmpty(idUsuario))
        {
            await DisplayAlert("Error", "Por favor ingrese un código de usuario válido", "OK");
            return;
        }

        try
        {
            var url = $"https://api.escuelajs.co/api/v1/users/{idUsuario}";
            var resp = await _httpClient.GetAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                var responseBody = await resp.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<IdUsers>(responseBody);

                if (user != null)
                {
                    EntryNombreUsuario.Text = user.Name;
                    EntryEmailUsuario.Text = user.Email;
                    EntryRolUsuario.Text = user.Role;
                    ImgAvatar.Source = user.Avatar;
                }
                else
                {
                    LimpiarCampos();
                    await DisplayAlert("Resultado", "No se ha encontrado un usuario con ese ID", "OK");
                }
            }
            else
            {
                LimpiarCampos();
                await DisplayAlert("Error", "Error al consultar el usuario", "OK");
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
        EntryNombreUsuario.Text = string.Empty;
        EntryEmailUsuario.Text = string.Empty;
        EntryRolUsuario.Text = string.Empty;
        ImgAvatar.Source = null;
    }
}
