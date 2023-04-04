using Biblioteca_API.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Biblioteca_API.Authentication
{
    public class AuthenticationResponse
    {
        public Guid IDMembru { get; set; }
        public string NumeMembru { get; set; }
      //  public string Title { get; set; }
        public string Token { get; set; }
        public AuthenticationResponse(Member user, string token)
        {
            IDMembru = user.IDMembru;
            NumeMembru = user.NumeMembru;
            Token = token;
        }
    }
}
