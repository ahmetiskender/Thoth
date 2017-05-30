using System;
using System.Collections.Generic;
using System.Linq;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;
using Thoth.Business.MD5;
using Thoth.Business.Tokens;

namespace Thoth.Business.ValidationRules
{
    public class Verification
    {
        IUsersService users = new UsersManager();
        IUserTokensService userTokens = new UserTokensManager();
        Md5Encryption md5 = new Md5Encryption();
        Token currentToken = new Token();

        public string GetToken(string username, string password)
        {
            string hash = md5.Encrypt(password);

            if (username != null && password != null)
            {
                var user = users.GetAll(x => x.Username.Equals(username) && x.Hash.Equals(hash)).FirstOrDefault();

                if (user != null)
                {
                    Token.hash = hash;
                    Token.username = username;

                    var usertoken = userTokens.GetAll(x => x.Id == user.Id).FirstOrDefault();

                    if (usertoken.TokenValidTime < DateTime.Now)
                    {
                        Token.token = currentToken.RefreshToken();
                        currentToken.SaveToken(Token.token, usertoken.Id);
                    }

                    else
                    {
                        Token.token = currentToken.GenerateToken();
                        currentToken.SaveToken(Token.token, usertoken.Id);
                    }

                    return Token.token;
                }

                else
                {//hatali giris
                    return null;
                }
            }
            // bos giris
            return null;
        }

        public string DeleteIsToken()
        {
            var user = users.GetAll(x => x.Username.Equals(Token.username) && x.Hash.Equals(Token.hash)).FirstOrDefault();

            if (user != null)
            {
                currentToken.SaveToken("", user.Id);
                Token.hash = null;
                Token.username = null;
            }
            return null;
        }
    }
}
