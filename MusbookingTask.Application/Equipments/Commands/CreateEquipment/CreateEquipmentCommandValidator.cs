using FluentValidation;

namespace MusbookingTask.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
    {
        public CreateEquipmentCommandValidator()
        {
            RuleFor(e => e.Name)
             .NotEmpty().WithMessage("Введите название оборудования !")
             .MinimumLength(3).WithMessage("Название слишком короткое !");
            RuleFor(e => e.Amount)
                .GreaterThan(0).WithMessage("Введите количество оборудования в наличие");
        }
    }
}
