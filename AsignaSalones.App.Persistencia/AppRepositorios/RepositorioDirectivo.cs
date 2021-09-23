using AsignaSalones.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace AsignaSalones.App.Persistencia 
{
    public class RepositorioDirectivo : IRepositorioDirectivo
    {
        private readonly AppContext _appContext;
        public RepositorioDirectivo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Directivo IRepositorioDirectivo.AddDirectivo(Directivo directivo)
        {
            var directivoAdicionado = _appContext.directivos.Add(directivo) ;
            _appContext.SaveChanges();
            return directivoAdicionado.Entity ;
        }

        Directivo IRepositorioDirectivo.Updatedirectivo(directivo directivo)
        {
            var directivoEncontrado = _appContext.directivos.FirstOrDefault(p => p.id == directivo.id);
            if (directivoEncontrado != null)
            {
                directivoEncontrado.nombre = directivo.nombre;
                directivoEncontrado.apellidos = directivo.apellidos;
                directivoEncontrado.identificacion = directivo.identificacion;
                directivoEncontrado.telefono = directivo.telefono;
                directivoEncontrado.correo = directivo.correo;
                _appContext.SaveChanges();
            }
            return directivoEncontrado;
        }

        void IRepositorioDirectivo.Deletedirectivo(int iddirectivo)
        {
            var directivoEncontrado = _appContext.directivos.FirstOrDefault(p => p.id == iddirectivo);
            if (directivoEncontrado == null)
                return;
            _appContext.directivos.Remove(directivoEncontrado);
            _appContext.SaveChanges();
        }

        Directivo IRepositorioDirectivo.Getdirectivo(int iddirectivo)
        {
            var directivoEncontrado = _appContext.directivos.FirstOrDefault(p => p.id == iddirectivo);
            return directivoEncontrado;
        }

         IEnumerable<directivo> IRepositorioDirectivo.GetAlldirectivo()
        {
            return _appContext.directivos;
        }
    }
}