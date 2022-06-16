using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Modesl;

namespace Repositorio.Interface
{
    public interface IPalestrantePersistence
    {

        Task<Palestrante[]> GetAllPalestrantesAsyncByNome(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);

    }
}
