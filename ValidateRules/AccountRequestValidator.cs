using DTO;
using FluentValidation;
using BUS;
using System.Reflection.Metadata.Ecma335;

namespace ValidateRules
{
    public class AccountRequestValidator : AbstractValidator<AccountRequest>
    {
        public AccountRequestValidator()
        {
            RuleFor(acc => acc.Username)
                .NotEmpty()
                .WithMessage("Tên đăng nhập không được để trống")
                .MinimumLength(8)
                .WithMessage("Tên đăng nhập phải ít nhất 8 kí tự")
                .Matches(@"^[a-zA-Z0-9_\-.]*$")
                .WithMessage("Tên đăng nhập chứa ký tự không hợp lệ")
                .MustAsync((x, cancellation) => checkAlreadyUsername(x))
                .WithMessage("Tên đăng nhập đã có người sử dụng");

            RuleFor(acc => acc.Email)
                .NotEmpty()
                .WithMessage("Email không được để trống")
                .EmailAddress()
                .WithMessage("Email không hợp lệ")
                .MustAsync((x, cancellation) => checkAlreadyEmail(x))
                .WithMessage("Email đã có người sử dụng");


            RuleFor(acc => acc.Password)
                .NotEmpty()
                .WithMessage("Mật khẩu không được để trống")
                .MinimumLength(8)
                .WithMessage("Mật khẩu phải ít nhất 8 kí tự")
                .MaximumLength(30)
                .WithMessage("Mật khẩu không được quá 30 kí tự")
                .Matches(@"[A-Z]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự hoa")
                .Matches(@"[a-z]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự thường")
                .Matches(@"[0-9]+")
                .WithMessage("Mật khẩu phaỉ chứa ít nhất 1 chữ số")
                .Matches(@"[\!\?\*\.\@\#\%\^\&\*\(\)\-\+\=\>\<\/\~\`\:]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự đặc biệt")
                .Equal(acc => acc.PasswordConfirm)
                .WithMessage("Mật khẩu không trùng với mật khẩu xác nhận");

            RuleFor(acc => acc.PasswordConfirm)
                .Equal(acc => acc.Password)
                .WithMessage("Mật khẩu không trùng với mật khẩu đã nhập")
                .NotEmpty()
                .WithMessage("Mật khẩu không được để trống")
                .MinimumLength(8)
                .WithMessage("Mật khẩu phải ít nhất 8 kí tự")
                .MaximumLength(30)
                .WithMessage("Mật khẩu không được quá 30 kí tự")
                .Matches(@"[A-Z]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự hoa")
                .Matches(@"[a-z]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự thường")
                .Matches(@"[0-9]+")
                .WithMessage("Mật khẩu phaỉ chứa ít nhất 1 chữ số")
                .Matches(@"[\!\?\*\.\@\#\%\^\&\*\(\)\-\+\=\>\<\/\~\`\:]+")
                .WithMessage("Mật khẩu phải chứa ít nhất 1 kí tự đặc biệt");

            RuleFor(acc => acc.RoleName)
                .NotEqual("--Role--")
                .WithMessage("Role không được\n để trống");

            RuleFor(acc => acc.IsMale)
                .NotEqual("--Gender--")
                .WithMessage("Giới tính không được\n để trống");

            RuleFor(acc => acc.ImagePath)
                .NotEmpty()
                .WithMessage("Ảnh thẻ không được\n để trống");

            RuleFor(acc => acc.Grade)
                .NotEqual("--Class--")
                .WithMessage("Lớp không được\n để trống");

            RuleFor(acc => acc.Dateofbirth)
                .Must(acc => DateTime.Now.Year -  acc.Year >= 12 && DateTime.Now.Year - acc.Year <= 150)
                .WithMessage("Số tuổi phải\n lớn hơn 12");

            RuleFor(acc => acc.Fullname)
                .NotEmpty()
                .WithMessage("Họ tên không được để trống");

        }

        private static async Task<bool> checkAlreadyUsername(string username)
        {
            if (username == null)
                username = "a";
            var result = await LoginBus.Instance.getUsername(username) == 0;
            return result;
        }

        private static async Task<bool> checkAlreadyEmail(string email)
        {
            if (email == null)
                email = "a";
            var result = await LoginBus.Instance.getEmail(email) == 0;
            return result;
        }
    }
}