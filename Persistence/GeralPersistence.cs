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
    public class GeralPersistence : IGeralPersistence
    {
        private readonly BancoEventosContext context;

        public GeralPersistence(BancoEventosContext _context)
        {
            context = _context;
        }

        public void Add<T>(T entiy) where T : class
        {
            context.Add(entiy);

        }
        public void Update<T>(T entiy) where T : class
        {
            context.Update(entiy);
        }

        public void Delete<T>(T entiy) where T : class
        {
            context.Remove(entiy);
        }

        public void DeleteRange<T>(T[] entiyarray) where T : class
        {
            context.RemoveRange(entiyarray);
        }
        public async Task<bool> SaveChangeAsync()
        {

            // se hover retorno true maior que 0 ele retorna true
            return await context.SaveChangesAsync() > 0;
        }






    }
}
