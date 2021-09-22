using System;
using System.Collections.Generic;
namespace AsignaSalones.App.Dominio
{
    public class HorarioClase
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public Profesor profesor { get; set; }
        public List<Estudiante> estudiantes { get; set; }
        public int cantPersonas { get; set; }
        public Salon salonAsignado { get; set; }
        public DateTime hora { get; set; }
    }
}