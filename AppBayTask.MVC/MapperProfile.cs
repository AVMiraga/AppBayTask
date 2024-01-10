using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using AutoMapper;

namespace AppBayTask.MVC
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<FeatureCreateVm, Feature>();

			CreateMap<FeatureUpdateVm, Feature>();
		}
	}
}
