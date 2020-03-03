using AutoMapper;
using BMS.Models.Entities;
using BMS.Models.Enums;
using BMS.Models.ViewModels.CRUD;

namespace BMS.Migatior.AutoMapper
{
    public class ViewModelToEntityProfile:Profile
    {
        /// <summary>
        /// 创建关系映射 ViewModel->Entity
        /// </summary>
        public ViewModelToEntityProfile()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(d => d.Gender,
                    m =>
                        m.MapFrom(
                            x => x.Gender == "男" 
                                ? EnumGender.Man 
                                : x.Gender == "女" 
                                    ? EnumGender.Woman 
                                    : EnumGender.UKnown));
        }
    }
}