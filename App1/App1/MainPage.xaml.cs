using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Entity;
using App1.Data;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Paciente paciente = new Paciente();
            paciente.Contrasena = "admin";
            paciente.CorreoElectronico = "admin";

            Paciente paciente1 = new Paciente();
            paciente1.Nombre = "Jason";
            paciente1.PrimerApellido = "Mongrillo";
            paciente1.SegundoApellido = "Diaz";
            paciente1.Contrasena = "Jason";

            ServiciosMedicos sm = new ServiciosMedicos();
            sm.CodigoServicio = 1;
            sm.NombreServicio = "Medicina general";
            
            ServiciosMedicos sm1 = new ServiciosMedicos();
            sm1.CodigoServicio = 2;
            sm1.NombreServicio = "Dentista";

            DataBase.AgregarPaciente(paciente);
            DataBase.AgregarPaciente(paciente1);

            DataBase.AgregarServicio(sm);
            DataBase.AgregarServicio(sm1);

            InitializeComponent();
        }

        async void OnNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.RegistroPage 
            {
                BindingContext = new Paciente()
            });
        }

        async void Login(object sender, EventArgs e)
        {            
            Login login = new Login();
            List<Paciente> listaPacientes = DataBase.ObtenerPacientes();
            bool loginCorrecto = false;

            login.CorreoElectronico = CorreoElectronico.Text;
            login.Contrasena = Contrasena.Text;

            for (int i = 0; i < listaPacientes.Count; i++)
            {
                if (login.CorreoElectronico == listaPacientes[i].CorreoElectronico && login.Contrasena == listaPacientes[i].Contrasena)
                {
                    loginCorrecto = true;
                    await Navigation.PushAsync(new Views.Login
                    {
                        BindingContext = new Login()
                    });
                }
            }

            if (loginCorrecto == false)
            {
                await DisplayAlert("Error", "El correo o la contraseña no existen, registrese primero y vuleva a intentarlo", "Ok");
            }            
        }
    }
}