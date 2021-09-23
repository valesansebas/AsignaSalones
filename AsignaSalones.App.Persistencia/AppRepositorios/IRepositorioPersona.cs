using System.Collections.Generic;
using AsignaSalones.App.Dominio;

namespaceAsignaSalones.App.Persistencia
{
    public interface IRepositorioPersona
    {
        //GetAllPersonas
        IEnumerable<Persona> GetAllPersonas();
        //AddPersona
        Persona AddPersona(Persona Persona);
        //UpdatePersona
        Persona UpdatePersona(Persona Persona);
        //DeletePersona
        void DeletePersona(int idPersona);
        //GetPersona
        Persona GetPersona(int idPersona);

    }
}