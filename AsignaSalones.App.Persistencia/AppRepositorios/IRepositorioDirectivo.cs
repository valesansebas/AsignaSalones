using System.Collections.Generic;
using AsignaSalones.App.Dominio;

namespaceAsignaSalones.App.Persistencia
{
    public interface IRepositorioDirectivo 
    {
        //GetAllDirectivos
        IEnumerable<Directivo> GetAllDirectivos();
        //AddDirectivo
        Directivo AddDirectivo(Directivo Directivo);
        //UpdateDirectivo
        Directivo UpdateDirectivo(Directivo Directivo);
        //DeleteDirectivo
        void DeleteDirectivo(int idDirectivo);
        //GetDirectivo
        Directivo GetDirectivo(int idDirectivo);

    }
}