using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Models
{
    public class TipoContato
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoContato()
        {

        }

        public TipoContato(string descricao)
        {
            Descricao = descricao;
        }

        public TipoContato(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
