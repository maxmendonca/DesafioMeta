using System.Collections.Generic;

namespace MinhaWebApi.Models.ViewModels
{
    public class ContatoViewModel
    {
        public Contato Contato { get; set; }
        public ICollection<TipoContato> TipoContato { get; set; }
    }
}
