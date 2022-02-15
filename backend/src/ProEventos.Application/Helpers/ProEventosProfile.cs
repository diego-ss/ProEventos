using AutoMapper;
using ProEventos.Application.DTOs;
using ProEventos.Domain;

namespace ProEventos.Application.Helpers
{

    //essa classe serve de referência para o automapper localizar os parâmetros para mapeamento
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();
            CreateMap<Lote, LoteDTO>().ReverseMap();
            CreateMap<Palestrante, PalestranteDTO>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDTO>().ReverseMap();
        }
    }
}
 