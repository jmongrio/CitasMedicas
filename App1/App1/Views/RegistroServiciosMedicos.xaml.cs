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
    public partial class RegistroServiciosMedicos : ContentPage
    {
        public RegistroServiciosMedicos()
        {
            InitializeComponent();
        }

        async public void GuardarServicio(object sender, EventArgs e)
        {
            ServiciosMedicos nuevoServicioMedico = (ServiciosMedicos)BindingContext;
            bool comprobacion = ComprobarCodigo(nuevoServicioMedico);

            if (comprobacion == true)
            {
                DataBase.AgregarServicio(nuevoServicioMedico);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "El código que has introducido ya existe.", "Ok");
            }
        }

        public bool ComprobarCodigo(ServiciosMedicos servicio)
        {
            List<ServiciosMedicos> listaServicios = DataBase.ObtenerServicios();
            bool comprobacion = false;

            if (listaServicios.Count == 0)
            {
                comprobacion = true;
            }
            else
            {
                for (int i = 0; i < listaServicios.Count; i++)
                {
                    if (servicio.CodigoServicio != listaServicios[i].CodigoServicio)
                    {
                        comprobacion = true;
                    }
                }
            }

            return comprobacion;
        }

        async public void Back(object sender, EventArgs e) => await Navigation.PopAsync();
    }
}