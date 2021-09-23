using AsignaSalones.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace AsignaSalones.App.Persistencia
{
    public class RepositorioEstudiante : IRepositorioEstudiante
    {
        private readonly AppContext _appContext;
        public RepositorioEstudiante(AppContext appContext)
        {
            _appContext = appContext;
        }

        Estudiante IRepositorioEstudiante.AddEstudiante(Estudiante estudiante)
        {
            var estudianteAdicionado = _appContext.estudiantes.Add(estudiante) ;
            _appContext.SaveChanges();
            return estudianteAdicionado.Entity ;
        }

        Estudiante IRepositorioEstudiante.UpdateEstudiante(Estudiante estudiante)
        {
            var estudianteEncontrado = _appContext.estudiantes.FirstOrDefault(p => p.id == estudiante.id);
            if (estudianteEncontrado != null)
            {
                estudianteEncontrado.nombre = estudiante.nombre;
                estudianteEncontrado.apellidos = estudiante.apellidos;
                estudianteEncontrado.identificacion = estudiante.identificacion;
                estudianteEncontrado.telefono = estudiante.telefono;
                estudianteEncontrado.correo = estudiante.correo;
                _appContext.SaveChanges();
            }
            return estudianteEncontrado;
        }

        void IRepositorioEstudiante.DeleteEstudiante(int idestudiante)
        {
            var estudianteEncontrado = _appContext.estudiantes.FirstOrDefault(p => p.id == idestudiante);
            if (estudianteEncontrado == null)
                return;
            _appContext.estudiantes.Remove(estudianteEncontrado);
            _appContext.SaveChanges();
        }

        Estudiante IRepositorioEstudiante.GetEstudiante(int idestudiante)
        {
            var estudianteEncontrado = _appContext.estudiantes.FirstOrDefault(p => p.id == idestudiante);
            return estudianteEncontrado;
        }

         IEnumerable<estudiante> IRepositorioEstudiante.GetAllEstudiante()
        {
            return _appContext.estudiantes;
        }
    }
}