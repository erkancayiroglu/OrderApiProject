using FluentValidation;
using OrderProject.WebUI.Dtos.RegisterDto;

public class CreateRegisterValidator : AbstractValidator<CreateUserDto>
{
    public CreateRegisterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.");

        RuleFor(x => x.Password)
      .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
      .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
      .Matches(@"^(?=.*[a-zA-Z])(?=.*\d).+$")
      .WithMessage("Şifre en az 1 harf ve 1 rakam içermelidir.");
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Şifreler uyuşmuyor.");
    }
}
