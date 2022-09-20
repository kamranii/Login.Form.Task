using System;
namespace Login.Form
{
    public class VerificationOperations
    {
        //Doğrulama parametreleri
        public bool UsernameIsValidated { get; set; }
        public bool PasswordValidated { get; set; }
        public byte AttemptsLeft { get; set; }
        //Verify the username
        public void VerifyUsername(string username)
        {
            //Kullanıcı adı mevcut mu diye kontrol et
            User user = Database.users.Find(x => x.Username == username);
            if (user == null)
            {
                Console.WriteLine("Kullanıcı adı mevcut değil!!! Lütfen tekrar deneyin!");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                UsernameIsValidated = false;
            }
            else
                UsernameIsValidated = true;
        }
        //Parola doğrulama
        public void VerifyPassword(string username, string password)
        {
            //Kullanıcıyı bul
            User user = Database.users.Find(x => x.Username == username);
            //Parolayı doğrula
            if(user != null)
            {
                if (user.Password == password)
                    PasswordValidated = true;
                else
                    PasswordValidated = false;
            }
        }
        public void VerifyLogin()
        {
            //Kalan hakk
            this.AttemptsLeft = 5;
            do
            {
                if (this.AttemptsLeft == 0)
                {
                    Console.WriteLine("Kullanıcıya giriş sağlanamadı!!!");
                    return;
                }
                //Kalan hakkı göster
                Console.Write("Kalan hakkınız: ");
                for (int i = 0; i < this.AttemptsLeft; i++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine(" ");
                //Kullanıcı adı ve parola isteme
                Console.Write("Kulanıcı adınızı giriniz: ");
                string loginUsername = Console.ReadLine();
                Console.Write("Parolanızı giriniz: ");
                string loginPassword = Console.ReadLine();
                //Kullanıcı adını ve parolayı doğrula
                this.VerifyUsername(loginUsername);
                this.VerifyPassword(loginUsername, loginPassword);
                if (this.UsernameIsValidated)
                {
                    if (this.PasswordValidated)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Hoşgeldiniz");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Parola yanlış. Lütfen tekrar deneyin!");
                    }
                }
                this.AttemptsLeft--;
            } while (true);
        }
    }
}

