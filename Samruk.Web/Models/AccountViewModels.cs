﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Samruk.Web.Models {
    public class ExternalLoginConfirmationViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        public string Provider { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]

        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]

        [Display(Name = "Имя пользователя")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [Display(Name = "Имя пользователя")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [StringLength(100, ErrorMessage = "{0} должен быть по крайней мере {2} символов.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel {
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
