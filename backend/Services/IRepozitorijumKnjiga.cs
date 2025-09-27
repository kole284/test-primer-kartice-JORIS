using backend.Models;
namespace backend.Services
{

    public interface IRepozitorijumKnjiga
    {
        IEnumerable<Knjiga> GetAllKnjige();
        Knjiga GetKnjigaById(int id);
        void AddKnjiga(Knjiga knjiga);
        void UpdateKnjiga(Knjiga knjiga);
        void DeleteKnjiga(int id);
        void KupiKnjigu(int id);
        Knjiga GetKnjigaByNaziv(string naziv);
    }
}