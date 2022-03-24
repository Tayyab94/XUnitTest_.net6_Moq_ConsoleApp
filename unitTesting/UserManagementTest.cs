using System.Linq;
using TestingApp.Functionality;
using Xunit;

namespace unitTesting
{
    public class UserManagementTest
    {
        [Fact]
        public void Add_CreateUser()
        {
            //Arrange
            var userManagement = new UserManagement();

            //Act
            userManagement.AddUser(new User("Muhammad", "Tayyab"));

            //Assert
            var saveUser = Assert.Single(userManagement.Users);
            Assert.NotNull(saveUser); // checking that the userManagement list is not empty
            Assert.Equal("Muhammad", saveUser.firstName);
            Assert.Equal("Tayyab", saveUser.lastName);
            Assert.False(saveUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UserMobileNo()
        {
            //Arrange
            var userManagement = new UserManagement();

            //Act

            userManagement.AddUser(new User("Ali", "Ahmad"));
            //userManagement.AddUser(new User("Hammad", "Ahmad"));
            //userManagement.AddUser(new User("Talha", "Abas"));

            var singleUser = userManagement.Users.First(s => s.firstName.ToLower().Equals("ali"));

            singleUser.Phone = "1234560";

            userManagement.UpdateUser(singleUser);

            //Assert
           
            var saveUser = Assert.Single(userManagement.Users);
            Assert.NotNull(saveUser);
            Assert.Equal("1234560", saveUser.Phone);
        }
    }
}