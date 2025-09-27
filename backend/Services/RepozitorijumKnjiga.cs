using backend.Models;
using backend.Data;
namespace backend.Services
{
    public class RepozitorijumKnjiga : IRepozitorijumKnjiga
    {
        private readonly KlijentiKontekst _context;
        public RepozitorijumKnjiga(KlijentiKontekst context)
        {
            _context = context;
        }
        public IEnumerable<Knjiga> GetAllKnjige()
        {
            return _context.Knjige.ToList();
        }
        public Knjiga GetKnjigaById(int id)
        {
            var knjiga = _context.Knjige.Find(id);
            if (knjiga == null)
            {
                throw new InvalidOperationException($"Knjiga with id {id} not found.");
            }
            return knjiga;
        }
        public void AddKnjiga(Knjiga knjiga)
        {
            _context.Knjige.Add(knjiga);
            _context.SaveChanges();
        }
        public void UpdateKnjiga(Knjiga knjiga)
        {
            _context.Knjige.Update(knjiga);
            _context.SaveChanges();
        }
        public void DeleteKnjiga(int id)
        {
            var knjiga = _context.Knjige.Find(id);
            if (knjiga != null)
            {
                _context.Knjige.Remove(knjiga);
                _context.SaveChanges();
            }
        }

        public void KupiKnjigu(int id)
        {
            var knjiga = _context.Knjige.Find(id);
            if (knjiga != null && knjiga.KolicinaNaStanju > 0)
            {
                knjiga.KolicinaNaStanju--;
                _context.Knjige.Update(knjiga);
                _context.SaveChanges();
            }
        }
        public Knjiga GetKnjigaByNaziv(string naziv)
        {
            return _context.Knjige.FirstOrDefault(k => k.Naslov == naziv);
        }
    }
}