using FluentValidation;

namespace MusbookingTask.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
    {
      
                .GreaterThan(0).WithMessage("Введите количество оборудования в наличие");
        }
    }
}
