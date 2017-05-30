using System;
using System.Linq;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;


namespace Thoth.Business.Tokens
{
    public class Token
    {
        IUserTokensService userTokens = new UserTokensManager();
        DateTime validTime = DateTime.Now.AddHours(5);//5 saat sure tanimlandi

        public static string token;
        public static string hash;
        public static string username;

        public string GenerateToken()
        {
            string token = null;

            Random rand = new Random();

            string values = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuopasdfghjklizxcvbnm1234567890";

            for (int i = 0; i < 16; i++) // kac haneli token olusturmak istiyorsak siniri burda degistiriyoruz
            {
                token += values[rand.Next(values.Length)];
            }

            return token;
        }

        public string RefreshToken()
        {
            return GenerateToken() ;
        }

        public void SaveToken(string token, int id)
        {
            var usertoken = userTokens.GetAll(x => x.Id == id).FirstOrDefault();

            if (token != null)
            {
                usertoken.TokenValidTime = validTime;
            }

            else
            {
                usertoken.TokenValidTime = DateTime.Now;
            }

            usertoken.Token = token;
            userTokens.Update(1, usertoken);
        }
    }

    

}
