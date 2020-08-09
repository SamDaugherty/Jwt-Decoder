using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml;

namespace JWT_decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
            Console.WriteLine("Enter a JWT: ");
            var jwtInput = Console.ReadLine();

            // Assume the input is in a control called txtJwtIn,
            //and the output will be placed in a control called txtJwtOut
            var jwtHandler = new JwtSecurityTokenHandler(); 

            //Check if readable token (string is in a JWT format)
            var readableToken = jwtHandler.CanReadToken(jwtInput);
            var token = jwtHandler.ReadJwtToken(jwtInput);

            //Extract the headers of the JWT
            var headers = token.Header;
            var jwtHeader = "{";
            foreach (var h in headers)
            {
                jwtHeader += "\n" + h.Key + "\":\"" + h.Value + "\",";
            }
            jwtHeader += "\n}";
    

            //Extract the payload of the JWT
            var claims = token.Claims;
            var jwtPayload = "{";
            foreach (Claim c in claims)
            {
                jwtPayload += "\n" + c.Type + "\":\"" + c.Value + "\",";
            }
            jwtPayload += "\n }";
            Console.WriteLine("JWT Token Is:...");
            Console.WriteLine("Header: ");
            Console.WriteLine(jwtHeader);
            Console.WriteLine("Payload: ");
            Console.WriteLine(jwtPayload);
            }
        }
    }
}
