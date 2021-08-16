using App1.Data;
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
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        async void Registrar(Object sender, EventArgs e)
        {
            Paciente nuevoPaciente = (Paciente)BindingContext;
            DateTime date = fecha.Date;
            bool comprobacion = ComprobarContraseña(nuevoPaciente);

            //nuevoPaciente.FechaNacimiento = date.Day + "/" + date.Month + "/" + date.Year;
            nuevoPaciente.FechaNacimiento = date.ToString("dd/MM/yyyy");

            if (comprobacion == true)
            {
                DataBase.AgregarPaciente(nuevoPaciente);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Las contraseñas no son iguales, vuleve a intentarlo", "Ok");
            }
        }

        public bool ComprobarContraseña(Paciente paciente)
        {
            bool comprobacion = false;

            if (paciente.Contrasena == paciente.ConfirmarContrasena)
            {
                comprobacion = true;
            }

            return comprobacion;
        }
    }
}