using AutoMapper;
using BankingManagementSystem.API.Mapping;
using Xunit;

namespace BankingManagementSystem.API.Test
{
    public class AutoMapperTest
    {
        private static IMapper _mapper;

        public AutoMapperTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ApplicationMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void ValidateAutoMapperConfiguration()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
