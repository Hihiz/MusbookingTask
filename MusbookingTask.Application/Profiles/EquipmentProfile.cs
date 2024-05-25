using AutoMapper;
using MusbookingTask.Application.Dto.Equipments;
using MusbookingTask.Application.Equipments.Commands.CreateEquipment;
using MusbookingTask.Application.Equipments.Commands.UpdateEquipment;
using MusbookingTask.Domain.Entities;

namespace MusbookingTask.Application.Profiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, CreateEquipmentCommand>().ReverseMap();
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<Equipment, UpdateEquipmentCommand>().ReverseMap();     
        }
    }
}
