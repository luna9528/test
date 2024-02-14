using AutoMapper;
using test.Models.DTO;

namespace test.Models.Profiles
{
    public class CompraProfile : Profile
    {
        protected CompraProfile()
        {
            CreateMap<Compras, CompraDTO>();
            CreateMap<CompraDTO, Compras>();
        }

        protected internal CompraProfile(string profileName) : base(profileName)
        {
        }

        protected internal CompraProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
        }
    }
}
