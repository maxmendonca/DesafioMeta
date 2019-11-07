using Microsoft.EntityFrameworkCore;
using MinhaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Services
{
    public class TipoContatoService
    {
        private readonly MinhaWebApiContext _context;

        public TipoContatoService(MinhaWebApiContext context)
        {
            _context = context;
        }

        public async Task<List<TipoContato>> FindAllAsync()
        {
            return await _context.TipoContato.OrderBy(x => x.Descricao).ToListAsync();
        }
    }
}
