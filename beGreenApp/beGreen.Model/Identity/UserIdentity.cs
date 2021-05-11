using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Linq;

namespace beGreen.Model.Identity
{
    public class UserIdentity
    {
        /// <summary>
        /// Uniq id of the user
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Email fo the user
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Roles of the user
        /// </summary>
        public IEnumerable<string> Roles { get; private set; }

        public UserIdentity()
        { }

        public UserIdentity(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }

        public UserIdentity(IEnumerable<Claim> claims)
        {
            List<string> roles = new List<string>();

            foreach (Claim claim in claims)
            {
                switch (claim.Type)
                {
                    case ClaimTypes.NameIdentifier:
                        Id = claim.Value;
                        break;
                    case ClaimTypes.Name:
                        Email = claim.Value;
                        break;
                    case ClaimTypes.Role:
                        roles.Add(claim.Value);
                        break;
                }
            }

            Roles = roles;
        }

        public IEnumerable<Claim> ToClaims()
        {
            List<Claim> claims = new List<Claim>
            {
                //TODO: add claims if needed here
                // new Claim(ClaimTypes.NameIdentifier, Id),
                //new Claim(ClaimTypes.Name, Email)
            };

            claims.AddRange(Roles.Select(x => new Claim(ClaimTypes.Role, x.ToUpper())));

            return claims;
        }
    }
}
