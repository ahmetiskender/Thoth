using System.Text;
using System.Security.Cryptography;

namespace Thoth.Business.MD5
{
    public class Md5Encryption
    {
        public string Encrypt(string password)
        {
            if (password != null)
            {
                // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
                byte[] temp = Encoding.UTF8.GetBytes(password);
                temp = md5.ComputeHash(temp);

                //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
                StringBuilder stringbuilder = new StringBuilder();

                //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
                foreach (byte bt in temp)
                {
                    stringbuilder.Append(bt.ToString("x2").ToLower());
                }
                //hexadecimal(onaltılık) stringi geri döndürelim.
                return stringbuilder.ToString();
            }

            return null;
        }
    }
}
