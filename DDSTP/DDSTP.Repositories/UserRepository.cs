using System.Collections.Generic;
using System.Linq;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class UserRepository: BaseWithDeleteRepository<User>
    {
        public static int CurrentUserId { get; set; }

        public UserRepository(dbDDSTPContext context)
            : base(context)
        {
        }

        public List<User> GetAll()
        {
            var result = context.Users.ToList();

            return result;
        }

        public User GetFirstAdminUser()
        {
            var result = context.Users.FirstOrDefault(x => x.UserType == UserType.Administrator);
            return result;
        }

        public User GetCurrentUser()
        {
            var result = GetById(UserRepository.CurrentUserId);
            return result;
        }
    }
}
