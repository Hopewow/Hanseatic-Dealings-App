using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hanseatic_Dealings_App.Models;

public class PasswordHashModel
{
    public static string HashPassword(string password)
    {
        SHA512 sha512 = SHA512.Create();
        
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashedPassword = sha512.ComputeHash(passwordBytes);

        return Convert.ToHexString(hashedPassword);
    }
}
   
