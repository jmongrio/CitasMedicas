using App1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async public void AgregarServicio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.RegistroServiciosMedicos()
            {
                BindingContext = new ServiciosMedicos()
            });
        }

        async public void AgregarCita(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CrearCita() 
            {
                BindingContext = new Citas()
            });
        }

        async public void Exit(object sender, EventArgs e) => await Navigation.PopAsync();

    }
}