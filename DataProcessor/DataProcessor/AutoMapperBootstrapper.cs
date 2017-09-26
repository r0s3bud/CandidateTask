using AutoMapper;
using DataProcessor.DatabaseConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    public static class AutoMapperBootstrapper
    {
        private static IMapper mapper = null;

        public static IMapper GetMapper()
        {            
            if (mapper == null)
            {
                var config = new MapperConfiguration(Configure);
                mapper = new Mapper(config);
            }

            return mapper;
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserDataModel, LogDTO>();
            cfg.CreateMap<LogDTO, LogEntryEntity>();
        }
    }
}
