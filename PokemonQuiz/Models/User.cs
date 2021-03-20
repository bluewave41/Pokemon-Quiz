using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PokemonQuiz.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public int IncorrectAnswers { get; set; } = 0;

        public int CorrectAnswers { get; set; } = 0;

        [StringLength(20)]
        public string ExpectedAnswer { get; set; }

        public bool Admin { get; set; } = false;

        public void HashPassword()
        {
            Password = Crypto.Hash(Password);
        }

        public virtual string Percentage
        {
            get
            {
                if(CorrectAnswers == 0 || IncorrectAnswers == 0)
                {
                    return "0";
                }
                return ((float)CorrectAnswers / (CorrectAnswers + IncorrectAnswers) * 100).ToString("0.00");
            }
        }
    }

    public static class Crypto
    {
        public static string Hash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
