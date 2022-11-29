using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Models.DTOs.Up;
using ProjetNoelWeb.WebApplication.Services.Interfaces;
using ProjetNoelWeb.WebApplication.ViewModels;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class RegisterController : Controller
    {
        #region privates
        private readonly IUserService _userService;
        #endregion

        #region CTOR
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region methods

        #endregion

        #region Index
        /// <summary>
        /// Return to view Register
        /// </summary>
        /// <returns>View Login</returns>
        public IActionResult Index()
        {
            return this.View();
        }
        #endregion

        #region Register
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns>View Surveys</returns>
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            // If the ModelState isn't valid
            if (!ModelState.IsValid)
            {
                // Return view Register
                return Index();
            }

            // Create an Administrator with DTO
            var user = new UserDTOUp()
            {
                // Get data from ViewModel
                UserName = registerViewModel.Username,
                Password = registerViewModel.Password,
                Avatar = registerViewModel.Avatar,
                Email = registerViewModel.Email                
            };

            await _userService.Register(user, HttpContext.Request.Cookies["Token"]);

            return RedirectToAction("Index", "squads");
        }
        #endregion
    }
}
