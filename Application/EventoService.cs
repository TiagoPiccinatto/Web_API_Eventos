using Application.Interface;
using Domain.Modesl;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;

        private readonly IEventosPersistence _eventopersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventosPersistence eventopersistence)
        {
            _geralPersistence = geralPersistence;
            _eventopersistence = eventopersistence;
        }       

        public async Task<EventoModel> AddEventos(EventoModel model)
        {
            try
            {
                _geralPersistence.Add<EventoModel>(model);
                if (await  _geralPersistence.SaveChangeAsync())
                {
                    return await _eventopersistence.GetEventoByIdAsync(model.Id, false);
                }             
                else
                {
                    return null;
                }                                  
            }
            catch (Exception eroor)
            {

                throw new Exception(eroor.Message);
            }
        }
        public async Task<EventoModel> UpdateEventos(int eventoid, EventoModel model)
        {
            try
            {
                var evento = await _eventopersistence.GetEventoByIdAsync(eventoid, false);
                if (evento == null)
                {
                    return null;

                }
                model.Id = evento.Id;
                
                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangeAsync())
                {
                    return await _eventopersistence.GetEventoByIdAsync(model.Id, false);
                }
                else
                {
                    return null;
                }
                // _geralPersistence.Update<EventoModel>(model);
                //  if (await _geralPersistence.SaveChangeAsync())
                // {
                //      return await _eventopersistence.GetEventoByIdAsync(eventoid);
                //  }
                // else
                //  {
                //  return null;
                // }
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public async Task<bool> DeletarEvento(int eventoid)
        {
            try
            {
                var evento = await _eventopersistence.GetEventoByIdAsync(eventoid, false);
                if (evento == null)
                {
                    throw new Exception("Evento não encontrado");

                }
                _geralPersistence.Delete<EventoModel>(evento);
                return await _geralPersistence.SaveChangeAsync();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public async Task<EventoModel[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventopersistence.GetAllEventosAsync(includePalestrantes);

                if (eventos == null)
                {
                    throw new Exception("Nenhum Evento encontrado");
                }
                return eventos;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        

        public async Task<EventoModel> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventopersistence.GetEventoByIdAsync(EventoId, includePalestrantes);

                if (eventos == null)
                {
                    throw new Exception("Nenhum Evento encontrado");
                }
                return eventos;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public async Task<EventoModel[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventopersistence.GetEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null)
                {
                    throw new Exception("Nenhum Evento encontrado");
                }
                return eventos;

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

    }
}
