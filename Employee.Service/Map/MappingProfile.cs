using AutoMapper;
using Employee.Domain.Entities;
using Employee.Service.Dtos;


namespace Employee.Service.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<EmployeeEntity,EmployeeDto>().ReverseMap();
        }
    }
}
