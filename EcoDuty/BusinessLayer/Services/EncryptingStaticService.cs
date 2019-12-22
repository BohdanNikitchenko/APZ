using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Services
{
    internal static class EncryptingStaticService
    {
        //генератор повторений пароля
        private static string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }

        //метод шифрования/дешифровки
        private static string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        //шифрование текста
        internal static string Encrypt(string plainText, string password)
            => Cipher(plainText, password);

        //расшифровка текста
        internal static string Decrypt(string encryptedText, string password)
            => Cipher(encryptedText, password);

        internal static User Decrypt(User user, string password)
        {
            User user1 = new User
            {
                City = user.City,
                CityId = user.CityId,
                Sensors = user.Sensors,
                Id = user.Id,
                Passport = user.Passport,
                Password = user.Password,
                Places = user.Places,
                Technics = user.Technics,
                Role = user.Role,
                Email = Encrypt(user.Email, password),
                Name = Encrypt(user.Name, password),
                Surname = Encrypt(user.Surname, password),
                //Patronymic = Encrypt(user.Patronymic, password),
                TaxIdentity = Encrypt(user.TaxIdentity, password),
            };
            return user1;
        }
    }
}
