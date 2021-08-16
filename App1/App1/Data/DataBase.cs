using System;
using System.Collections.Generic;
using System.Text;
using App1.Entity;

namespace App1.Data
{
    class DataBase
    {
        static List<Paciente> listaPacientes = new List<Paciente>();
        static List<ServiciosMedicos> listaServiciosMedicos = new List<ServiciosMedicos>();
        static List<Citas> listaCitas = new List<Citas>();

        #region Pacientes
        public static void AgregarPaciente(Paciente nuevoPaciente)
        {
            listaPacientes.Add(nuevoPaciente);
        }

        public static List<Paciente> ObtenerPacientes()
        {
            return listaPacientes;
        }
        #endregion

        #region Servicios Medicos
        public static void AgregarServicio(ServiciosMedicos nuevoServicio)
        {
            listaServiciosMedicos.Add(nuevoServicio);
        }

        public static List<ServiciosMedicos> ObtenerServicios()
        {
            return listaServiciosMedicos;
        }
        #endregion

        #region Citas
        public static void AgregarCita(Citas lista)
        {
            listaCitas.Add(lista);
        }

        public static List<Citas> ObtenerCitas()
        {
            return listaCitas;
        }
        #endregion
    }
}
