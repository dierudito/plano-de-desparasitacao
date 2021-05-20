using AutoMapper;

namespace DM.Desparasitacao.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModel>();
                i.AddProfile<ViewModelToDomain>();
            });
        }
    }
}