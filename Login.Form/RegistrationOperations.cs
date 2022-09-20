using System;
using System.Linq;

namespace Login.Form
{
    public class RegistrationOperations
    {
        public RegistrationOperations()
        {
        }
        //Kullanıcı adı alma
        public void GetUsername(User user)
        {
            //Kullanıcı adı default
            string username = "";
            bool exists = false;
            do
            {
                //Kullanıcı adı sor
                Console.Write("Kullanıcı adı: ");
                username = Console.ReadLine();
                //Doğrulamalar
                if (username == null || username.Trim(' ') == "")
                {
                    Console.WriteLine("Kullanıcı adı boş olamaz!!! Lütfen tekrar deneyin!");
                }
                else
                {
                    //Kullanıcı adının unique olması
                    var matchUser = Database.users.Find(x => x.Username == username);
                    if(matchUser != null)
                    {
                        Console.WriteLine("Kullanıcı adı artık kullanılıyor!!! Lütfen başka bir kullanıcı adı seçin");
                        exists = true;
                    }
                    else
                        user.Username = username.Trim(' ').ToLower();
                }
            } while (username == null || username.Trim(' ') == "" || exists);
        }
        //Parola alma
        public void GetPassword(User user)
        {
            //Parola default
            string password = "";
            bool passwordMatch = true;
            do
            {
                //Parola sor
                Console.Write("Parola: ");
                password = Console.ReadLine();
                //Doörulamalar
                if(password == null || password.Trim(' ') == "")
                {
                    Console.WriteLine("Parola boş olamaz!!! Lütfen tekrar deneyin");
                }
                else if(password.Contains(' '))
                {
                    Console.WriteLine("Parola boşluk içeremez!!!");
                }
                else if(password.Length < 8)
                {
                    Console.WriteLine("Parola 8 karakterden uzun olmalı");
                }
                else
                {
                    Console.Write("Parolyı doğrula: ");
                    string confirmPassword = Console.ReadLine();
                    passwordMatch = confirmPassword.Equals(password);
                    if (!passwordMatch)
                    {
                        Console.WriteLine("Inputs don't match!!! Please try again!");
                    }
                    else
                    {
                        user.Password = password;
                        Console.WriteLine("Parola ayarlandı");
                    }
                }
            } while (password == null || password.Trim(' ') == "" || password.Length < 8 || password.Contains(' ') || !passwordMatch);
        }
        
    }
}

