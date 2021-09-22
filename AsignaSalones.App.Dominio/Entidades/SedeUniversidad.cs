using System;

namespace AsignaSalones.App.Dominio
{
    public class SedeUniversidad
    {
        public int id {get;set;}
        public string nombre  {get;set;}
        public System.Collections.Generic.List<HorarioClase> materias {get;set;}
        public int numeroSalonesDispHora {get;set;}
        
        
    }
}