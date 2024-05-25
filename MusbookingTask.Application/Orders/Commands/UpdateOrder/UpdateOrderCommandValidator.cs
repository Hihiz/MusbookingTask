using FluentValidation;

namespace MusbookingTask.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty().WithMessage("Укажите номер заказа");
            RuleFor(e => e.Description)
               .NotEmpty().WithMessage("Введите описание заказа !");
            RuleFor(e => e.EquipmentId)
                .NotEmpty().WithMessage("Оборудование пустое !")
                .GreaterThan(0).WithMessage("Укажите оборудование !");
            RuleFor(e => e.Quantity)
                .NotEmpty().WithMessage("Укажите количество !");
        }
    }
}
