using FluentValidation;

namespace MusbookingTask.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
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
