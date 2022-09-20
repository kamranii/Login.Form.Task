using System;
using System.Threading;

namespace Login.Form
{
    class Program
    {
        static void Main(string[] args)
        {
            //İntro
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Üye formuna hoşgeldiniz!");
            //Sınıf initalization
            RegistrationOperations operations = new RegistrationOperations();
            Database database = new Database();
            User user = new User();
            //Üyelik bilgilerini alma
            //Kullanıcı adı ve parola alma
            operations.GetUsername(user);
            operations.GetPassword(user);
            //Kullanıcıyı listeye ekle
            Database.users.Add(user);
            Console.WriteLine("Tebrikler! Başarıyla üye oldunuz");
            //Üye girişi 
            Console.WriteLine("Giriş için yönlendiriliyorsunuz");
            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.Black;
            //6. Giriş doğrulama
            VerificationOperations verification = new VerificationOperations();
            verification.VerifyLogin();
        }
    }
}

