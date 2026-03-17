using FluentValidation;
using OrderProject.WebUI.Dtos.BookingDto;


public class CreateBookingValidator : AbstractValidator<Create2BookingDto>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
        RuleFor(x => x.UserMail)
            .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");

        RuleFor(x => x.PhoneNumber)
       .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
       .Matches(@"^\d+$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.")
       .MaximumLength(11).WithMessage("Telefon numarası 11 karakter olmalıdır.");

        RuleFor(x => x.Message)
                .NotEmpty().WithMessage("İstek alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");




    }
}
