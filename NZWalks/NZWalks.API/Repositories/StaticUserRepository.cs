using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        //Creating two user

        List<User> Users = new List<User>()
        {
            new User()
            {
                Id=new Guid(),
                FirstName="ReadOnly",
                LastName="User",
                EmailAddress="readonly@gmail.com",
                Username="readonly@user.com",
                Password="Readonly@user",
                Roles=new List<string>{"reader"}

            },

             new User()
            {
                Id=new Guid(),
                FirstName="ReadWrite",
                LastName="User",
                EmailAddress="readwrite@gmail.com",
                Username="readwrite@user.com",
                Password="Readwrite@user",
                Roles=new List<string>{"reader","writer"}

            }
        };

        public async Task<User> AuthenticationAsync(string username, string password)
        {
            var user= Users.Find(x=>x.Username.Equals(username,StringComparison.InvariantCultureIgnoreCase) && x.Password==password);

            if (user != null)
            {
                return user;

            }
            else
                return null;
        }

       
    }
}
