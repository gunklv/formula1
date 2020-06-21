using API.Helpers;
using API.ViewModels;
using BLL.Contracts.Services;
using FluentValidation;

namespace API.Validators
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(IUserService userService)
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x).MustAsync(async (x, _) =>
            {
                var dbUser = await userService.GetUser(x.UserName);
                if (dbUser == null) return false;

                var incomingPassword = Hasher.Hash(x.Password, dbUser.Salt);
                return incomingPassword == dbUser.Password;
            }).WithMessage("Wrong user name or password");
        }
    }
}
