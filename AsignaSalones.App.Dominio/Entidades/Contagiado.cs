using System;

namespace AsignaSalones.App.Dominio
{
    public class Contagiado
    {
        public int id {get;set;}
        public Persona persona {get;set;}
        public DateTime fechaContagio {get;set;}
        //public System.Collections.Generic.List<Sintomas> sintomas {get;set;}
        public String sintomas {get;set;}
        public DateTime periodoAislamiento {get;set;}
        
    }
}
