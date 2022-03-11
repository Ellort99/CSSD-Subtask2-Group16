namespace CSSD_Subtask2_Group16.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class LoginUserModel
    {
        public LoginUserModel()
        {

        }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(30)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30)]
        public string Password { get; set; }
    }

    public class RegisterUserModel
    {
        public RegisterUserModel()
        {

        }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string HomeAddress { get; set; }

        public int BankId { get; set; }
    }

    public class RegisterBankModel
    {
        public RegisterBankModel()
        {

        }
    }

}