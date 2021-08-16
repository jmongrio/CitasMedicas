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
    public partial class CrearCita : ContentPage
    {
        public CrearCita()
        {
            List<Paciente> listaPaciente = DataBase.ObtenerPacientes();
            List<ServiciosMedicos> listaServicios = DataBase.ObtenerServicios();


            InitializeComponent();

            FillPickerPaciente(listaPaciente);
            FillPickerServicios(listaServicios);
        }

        public void FillPickerPaciente(List<Paciente> lista)
        {
            if (lista.Count != 1)
            {
                for (int i = 1; i < lista.Count; i++)
                {
                    pacientePicker.Items.Add(lista[i].Nombre + " " + lista[i].PrimerApellido + " " + lista[i].SegundoApellido);
                }
            }
        }

        public void FillPickerServicios(List<ServiciosMedicos> lista)
        {
            if (lista.Count != 1)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    serviciosPicker.Items.Add(lista[i].CodigoServicio + " | " + lista[i].NombreServicio);
                }
            }
        }

        async void Registrar(object sender, EventArgs e)
        {
            Citas citas = new Citas();            

            citas.NombrePaciente = pacientePicker.SelectedItem.ToString();
            citas.ServicioMedico = serviciosPicker.SelectedItem.ToString();
            citas.Fecha = fecha.Date.ToString("MM/dd/yyyy");
            citas.Hora = timerCita.Time.Hours + ":" + timerCita.Time.Minutes;

            bool comprobacion = ComprobarNombre(citas);

            if (comprobacion == true)
            {
                DataBase.AgregarCita(citas);

                await DisplayAlert("Exito", "Se han registrado los siguientes datos.\n" +
                    "Nombre del paciente: " + citas.NombrePaciente + "\n" +
                    "Servicio: " + citas.ServicioMedico + "\n" +
                    "Fecha: " + citas.Fecha + "\n" +
                    "Hora: " + citas.Hora, "Ok");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Proceso bloqueado", "La persona ya tiene un registro a su nombre en la misma hora o fecha", "Ok");
            }
        }

        public bool ComprobarNombre(Citas nuevaCita)
        {
            List<Citas> listaCitas = DataBase.ObtenerCitas();
            bool comprobar = false;

            if (listaCitas.Count != 0)
            {
                for (int i = 0; i < listaCitas.Count; i++)
                {
                    if (listaCitas[i].NombrePaciente != nuevaCita.NombrePaciente)
                    {
                        return comprobar = true;
                    }
                    else
                    {
                        if (listaCitas[i].Fecha != nuevaCita.Fecha)
                        {
                            return comprobar = true;
                        }
                        else
                        {
                            return comprobar = false;
                        }
                    }
                }
            }
            else
            {
                return comprobar = true;
            }

            return comprobar;
        }
    }
}