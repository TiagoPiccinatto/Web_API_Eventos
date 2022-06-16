using Domain;
using Domain.Modesl;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly BancoEventosContext context;

        public PalestrantePersistence(BancoEventosContext _context)
        {
            context = _context;
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(e => e.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.AsNoTracking()
            .OrderBy(e => e.Id).Where(e => e.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();


        }

        // ============================================================ //
        // ============================================================ //        

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByNome(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(e => e.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.AsNoTracking()
            .OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        // ============================================================ //
        // ============================================================ //

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(e => e.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.AsNoTracking()
            .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        
    }
}
