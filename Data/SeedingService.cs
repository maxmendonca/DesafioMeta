using System.Linq;
using MinhaWebApi.Models;

namespace MinhaWebApi.Data
{
    public class SeedingService
    {
        private MinhaWebApiContext _context;

        public SeedingService(MinhaWebApiContext context)
        {
            _context = context;
        }

        public void Seed ()
        {
            if (_context.Contato.Any())
            {
                return; //Banco já foi populado
            }

            TipoContato t1 = new TipoContato("Email");
            TipoContato t2 = new TipoContato("Celular");
            TipoContato t3 = new TipoContato("Fixo");

            Contato C1 = new Contato(3, "Mateus", t1, "maxwell.icnv@gmail.com", "Obs teste 7.1");
            Contato C2 = new Contato(4, "Marcos", t2, "999998888", "Obs teste 16.15");
            Contato C3 = new Contato(4, "Lucas", t3, "27885511", "Obs teste 1.37");
            Contato C4 = new Contato(4, "João", t3, "27885511", "Obs teste 3.16");

            _context.TipoContato.AddRange(t1, t2, t3);
            _context.Contato.AddRange(C1, C2, C3, C4);

            _context.SaveChanges();
        }
    }
}
