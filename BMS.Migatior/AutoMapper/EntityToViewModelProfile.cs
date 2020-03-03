using AutoMapper;
using BMS.Models.Entities;
using BMS.Models.Enums;
using BMS.Models.ViewModels.CRUD;

namespace BMS.Migatior.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {
        /// <summary>
        /// 创建关系映射 Entity->ViewModel
        /// </summary>
        public EntityToViewModelProfile()
        {
            //创建将User对象映射成UserViewModel对象的规则
            CreateMap<User, UserViewModel>()
                .ForMember(d=>d.Gender,
                    m=> 
                        m.MapFrom(x=> x.Gender==EnumGender.Man
                            ?"男"
                            :x.Gender==EnumGender.Woman
                                ?"女"
                                :"未知"));

            //如有其他 Entity->ViewModel 的映射,依次在EntityToViewModelProfile的构造函数中添加
        }

    }
}