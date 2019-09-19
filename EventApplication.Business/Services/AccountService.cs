using EventApplication.Business.EncryptionAndDecryption;
using EventApplication.Business.Models;
using EventApplication.Shared.Interceptor;
using EventsApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Business.Services
{
   public class AccountService
    {

        public UserDataModel CreateUser(UserDataModel userData)
        {
            
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                User user = new User();
                user.FullName = userData.FullName;
                user.Role = userData.Role;
                user.Email = userData.Email;
                user.Password = userData.Password;
              // string Password = userData.Password;

                // string Encrypted = EncriptionAndDecription.Encrypt(Password);
                //  user.Password = Encrypted;

                bool isExist = context.Users.Any(u => u.Email == user.Email);

                if (!isExist)
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    return userData;
                }

                return null;
            }
        }

        public UserDataModel LoginUser(UserDataModel userData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                User user = context.Users.SingleOrDefault(u => u.Email == userData.Email);
               // string Password = userData.Password;
               // string Decrypted = EncriptionAndDecription.Decrypt(Password);
                var IsValid = context.Users.SingleOrDefault(u => u.Email == userData.Email && u.Password == userData.Password);
                if (IsValid != null)
                {
                    userData.FullName = IsValid.FullName;
                    userData.Role = IsValid.Role;
                    userData.Email = IsValid.Email;
                    userData.Id = IsValid.Id;
                    return userData;
                }

                return null;
            }

        }

    
    }
}
