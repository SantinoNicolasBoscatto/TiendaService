using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicis.Api.Libro.Aplicacion;
using TiendaServicis.Api.Libro.Modelo;

namespace TiendaServucuis.Api.Libro.Tests
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<LibreriaMaterial, LibreriaMaterialDTO>();
        }
    }
}
