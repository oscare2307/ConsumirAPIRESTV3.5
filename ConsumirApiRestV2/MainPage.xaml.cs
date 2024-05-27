using ConsumirApiRestV2.Models;
using ConsumirApiRestV2.Paginas;

namespace ConsumirApiRestV2
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarProductoPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarCategoriaPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarUsuariosPage());
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearProductoPage());
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarProductoPage());
        }

        private async void Button_Clicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarProducto());
        }

        private async void Button_Clicked_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearCategoriaPage());
        }

        private async void Button_Clicked_7(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarCategoriaPage());
        }

        private async void Button_Clicked_8(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarCategoriaPage());
        }

        private async void Button_Clicked_9(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearUsuariosPage());
        }

        private async void Button_Clicked_10(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarUsuarioPage());
        }

        private async void Button_Clicked_11(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarUsuarioPage());
        }
    }

}
