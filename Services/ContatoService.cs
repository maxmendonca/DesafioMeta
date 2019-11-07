using Microsoft.EntityFrameworkCore;
using MinhaWebApi.Models;
using MinhaWebApi.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Services
{
    public class ContatoService
    {
        private readonly MinhaWebApiContext _context;

        public ContatoService(MinhaWebApiContext context)
        {
            _context = context;
        }

        public List<Contato> FindAll()
        {
            return _context.Contato.ToList();
        }
        public void Insert(Contato obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task<List<Contato>> FindAllAsync()
        {
            return await _context.Contato.ToListAsync();
        }

        public async Task<Contato> FindByIdAsync(int id)
        {
            return await _context.Contato.Include(obj => obj.TipoContato).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Contato.Find(id);
            _context.Contato.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Contato obj)
        {
            if(!_context.Contato.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
