using DeliverService.Model;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Nancy.Json;
using System;
using System.Collections.Generic;

namespace DeliverService.Helper
{
    public class TokenHelper
    {
        public static string SecretKey = "This is a private key for Server";//这个服务端加密秘钥 属于私钥
        private static JavaScriptSerializer myJson = new JavaScriptSerializer();
        public static string GenToken(TokenInfo M) {
            var payload = new Dictionary<string, dynamic> 
            { {"UserName", M.UserName},//用于存放当前登录人账户信息
                {"UserPwd", M.Url}//用于存放当前登录人登录密码信息
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder(); 
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(payload, SecretKey);
        }

        public static string DecodeToken(string token) {
            //获取request中的token

             
           // string token ="";
            //去掉前面的Bearer
            if (token != null && token.StartsWith("Bearer"))
                token = token.Substring("Bearer ".Length).Trim();
            try { 
                var json = GetTokenJson(token);
                TokenInfo info = myJson.Deserialize<TokenInfo>(json);
                return  "Token is true"; 

            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return "Token has invalid signature";
            }
        }
        /// <summary>
        /// 验证解析token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetTokenJson(string token) {

            try {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
               IJwtAlgorithm alg=new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, alg); 
                var json = decoder.Decode(token, SecretKey, verify: true);
                return json; 
            } catch (Exception) {
                throw; 
            } 
        }

  
   
        
    }
       
}
