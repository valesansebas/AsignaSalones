using AsignaSalones.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace AsignaSalones.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly AppContext _appContext;
        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }

        Persona IRepositorioPersona.AddPersona(Persona persona)
        {
            var personaAdicionado = _appContext.personas.Add(persona) ;
            _appContext.SaveChanges();
            return personaAdicionado.Entity ;
        }

        Persona IRepositorioPersona.UpdatePersona(Persona persona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(p => p.id == persona.id);
            if (personaEncontrado != null)
            {
                personaEncontrado.nombre = persona.nombre;
                personaEncontrado.apellidos = persona.apellidos;
                personaEncontrado.identificacion = persona.identificacion;
                personaEncontrado.telefono = persona.telefono;
                personaEncontrado.correo = persona.correo;
                _appContext.SaveChanges();
            }
            return personaEncontrado;
        }

        void IRepositorioPersona.DeletePersona(int idpersona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(p => p.id == idpersona);
            if (personaEncontrado == null)
                return;
            _appContext.personas.Remove(personaEncontrado);
            _appContext.SaveChanges();
        }

        Persona IRepositorioPersona.GetPersona(int idpersona)
        {
            var personaEncontrado = _appContext.personas.FirstOrDefault(p => p.id == idpersona);
            return personaEncontrado;
        }

         IEnumerable<persona> IRepositorioPersona.GetAllPersona()
        {
            return _appContext.personas;
        }
    }
}