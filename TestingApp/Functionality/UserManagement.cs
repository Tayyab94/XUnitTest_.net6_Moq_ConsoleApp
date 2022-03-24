using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Functionality
{
    public record User(string firstName, string lastName)
    {
        public int Id { get; set; }
        public DateTime CreatedData { get; set; } = DateTime.UtcNow;

        public string Phone { get; set; }

        public bool VerifiedEmail { get; set; } = false;
    }
    public class UserManagement
    {

        private readonly List<User> _users = new();

        private int IdCounter = 1;

        public IEnumerable<User> Users=> _users;

        public void AddUser(User user)
        {
            _users.Add(user with { Id = IdCounter++ });

        }

        public void UpdateUser(User user)
        {
            var dbuser = _users.First(s => s.Id == user.Id);
            dbuser.Phone= user.Phone;
        }

        public void VerifiedEmail(User user)
        {
            var dbuser = _users.First(s => s.Id == user.Id);
            dbuser.VerifiedEmail = true;
        }
    }
}
