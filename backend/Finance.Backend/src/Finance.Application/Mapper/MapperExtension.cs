using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace System
{
    public static class MapperExtension
    {
        private static IMapper _mapper;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static TDest MapTo<TDest>(this object source)
        {

            return (TDest)_mapper.Map<TDest>(source);
        }
    }
}
