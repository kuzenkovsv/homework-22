using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Console;

namespace WebApp.Controllers
{
    public class RolesController : Controller
    {
        #region Admin
        private string AdminRole = "Administrators";
        private string UserEmail = "Admin1@gmail.com";
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public RolesController(RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!(await roleManager.RoleExistsAsync(AdminRole)))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }
            IdentityUser user = await userManager.FindByEmailAsync(UserEmail);
            if (user == null)
            {
                user = new();
                user.UserName = UserEmail;
                user.Email = UserEmail;
                IdentityResult result = await userManager.CreateAsync(
                user, "Admin1@gmail");
                if (result.Succeeded)
                {
                    WriteLine($"Пользователь {user.UserName} создан успешно.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            if (!user.EmailConfirmed)
            {
                string token = await userManager
                    .GenerateEmailConfirmationTokenAsync(user);
                IdentityResult result = await userManager
                .ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    WriteLine($"Почта пользователя {user.UserName} успешно подтверждёна.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            if (!(await userManager.IsInRoleAsync(user, AdminRole)))
            {
                IdentityResult result = await userManager
                .AddToRoleAsync(user, AdminRole);
                if (result.Succeeded)
                {
                    WriteLine($"Пользователь {user.UserName} успешно добавлен к {AdminRole}.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }
            return Redirect("/");
        }
        #endregion

        #region User
        //private string AdminRole = "RegisteredUser";
        //private string UserEmail = "User1@gmail.com";
        //private readonly RoleManager<IdentityRole> roleManager;
        //private readonly UserManager<IdentityUser> userManager;
        //public RolesController(RoleManager<IdentityRole> roleManager,
        //UserManager<IdentityUser> userManager)
        //{
        //    this.roleManager = roleManager;
        //    this.userManager = userManager;
        //}
        //public async Task<IActionResult> Index()
        //{
        //    if (!(await roleManager.RoleExistsAsync(AdminRole)))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(AdminRole));
        //    }
        //    IdentityUser user = await userManager.FindByEmailAsync(UserEmail);
        //    if (user == null)
        //    {
        //        user = new();
        //        user.UserName = UserEmail;
        //        user.Email = UserEmail;
        //        IdentityResult result = await userManager.CreateAsync(
        //        user, "User1@gmail");
        //        if (result.Succeeded)
        //        {
        //            WriteLine($"Пользователь {user.UserName} создан успешно.");
        //        }
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //            {
        //                WriteLine(error.Description);
        //            }
        //        }
        //    }
        //    if (!user.EmailConfirmed)
        //    {
        //        string token = await userManager
        //            .GenerateEmailConfirmationTokenAsync(user);
        //        IdentityResult result = await userManager
        //        .ConfirmEmailAsync(user, token);
        //        if (result.Succeeded)
        //        {
        //            WriteLine($"Почта пользователя {user.UserName} успешно подтверждёна.");
        //        }
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //            {
        //                WriteLine(error.Description);
        //            }
        //        }
        //    }
        //    if (!(await userManager.IsInRoleAsync(user, AdminRole)))
        //    {
        //        IdentityResult result = await userManager
        //        .AddToRoleAsync(user, AdminRole);
        //        if (result.Succeeded)
        //        {
        //            WriteLine($"Пользователь {user.UserName} успешно добавлен к {AdminRole}.");
        //        }
        //        else
        //        {
        //            foreach (IdentityError error in result.Errors)
        //            {
        //                WriteLine(error.Description);
        //            }
        //        }
        //    }
        //    return Redirect("/");
        //}
        #endregion

    }
}

