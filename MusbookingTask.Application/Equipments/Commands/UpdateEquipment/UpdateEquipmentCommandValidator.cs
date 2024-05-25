using FluentValidation;

namespace MusbookingTask.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
    {
        public UpdateEquipmentCommandValidator()
        {
            RuleFor(e => e.Id)
              .NotEmpty().WithMessage("Укажите номер оборудования");
            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("Введите название оборудования !")
               .MinimumLength(3).WithMessage("Название слишком короткое !");
            RuleFor(e => e.Amount)
                .GreaterThan(0).WithMessage("Введите количество оборудования в наличие");
        }
    }
}
