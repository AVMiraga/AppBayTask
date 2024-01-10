using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppBayTask.Business.Services.Interfaces
{
	public interface IAccountService
	{
		Task<RegisterResult> RegisterAsync(RegisterVm registerVm);
		Task<AppUser> ValidateUserCredentialsAsync(LoginVm loginVm);
		Task CreateRoleAsync();
	}

	public class RegisterResult
	{
		public IdentityResult? Result { get; set; }
		public AppUser? User { get; set; }
	}
}
