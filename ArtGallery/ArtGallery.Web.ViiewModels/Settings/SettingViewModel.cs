namespace ArtGallery.Web.ViewModels.Settings
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping;
    using AutoMapper;

    public class SettingViewModel : IMapFrom<Setting>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string NameValue { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Setting, SettingViewModel>().ForMember(
                m => m.NameValue,
                opt => opt.MapFrom(x => x.Name + " = " + x.Value));
        }
    }
}
