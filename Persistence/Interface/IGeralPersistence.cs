using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Modesl;

namespace Repositorio.Interface
{
    public interface IGeralPersistence
    {
        void Add<T>(T entiy) where T : class;

        void Update<T>(T entiy) where T : class;

        void Delete<T>(T entiy) where T : class;

        void DeleteRange<T>(T[] entiy) where T : class;

        Task<bool> SaveChangeAsync();

    }
}
