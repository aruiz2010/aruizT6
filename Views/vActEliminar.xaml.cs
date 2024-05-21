using aruizT6.Models;
using System.Net;
using System.Text;

namespace aruizT6.Views;

public partial class vActEliminar : ContentPage
{
    public vActEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (WebClient cliente = new WebClient())
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nuevoNombre", txtNombre.Text); 

                await cliente.UploadValuesTaskAsync(new Uri("http://192.168.2.89/moviles/wsestudiantes.php"), "PUT", parametros);
            }

            await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "Aceptar");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (WebClient cliente = new WebClient())
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                cliente.UploadValues("http://192.168.2.89/moviles/wsestudiantes.php", "DELETE", parametros);
            }

            await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "Aceptar");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}