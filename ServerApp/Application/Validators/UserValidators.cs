using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UserValidators
    {
        public void emailValidator(string email)
        {
            if (email == null) { 
                throw new ArgumentNullException("Email cannot be empty.");
            }
            Regex regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(email)) {
                throw new ArgumentException("Incorrect email address format.");
            }
        }

        public void passwordValidator(string password) {
            if (password == null) {
                throw new ArgumentNullException("Password cannot be empty.");
            }
            Regex regex = new Regex("^(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\/-]).{12,}$");
            if (!regex.IsMatch(password)) {
                throw new ArgumentException("Password must be at least 12 characters long, contain at least one uppercase letter, one digit, and one special character.");
            }
        }
    }
}
