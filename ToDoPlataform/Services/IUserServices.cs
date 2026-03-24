using Microsoft.AspNetCore.Identity;
using ToDoPlatform.ViewModels;

namespace ToDoPlataform.Services;

    public interface IUserServices
    {
        
        Task<SignInResult> Login(LoginVM login);

        Task Logout();
    }