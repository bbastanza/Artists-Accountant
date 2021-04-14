using Artist.tests.TestUtilities;
using Core.Entities;
using Core.Services.DbServices;
using Core.Services.UserServices;
using Infrastructure.Exceptions;
using Moq;
using NUnit.Framework;

namespace Artist.tests.Core.Services.UserServices
{
    [TestFixture]
    public class AddUserTests
    {
        private Mock<ISqlQuery> _sqlQuery;

        [SetUp]
        public void SetUp()
        {
            _sqlQuery = new Mock<ISqlQuery>();
        }

        [Test]
        public void CreateUser_ExistingUser_ThrowsExistingUserException()
        {
            var randomUsername = TestData.CreateRandomString();
            var randomPassword = TestData.CreateRandomString();
            var existingUser = new User();

            var getUserData = new Mock<IGetUserAuth>();
            getUserData.Setup(x => x.Get(randomUsername)).Returns(existingUser);
            var sut = new AddUser(getUserData.Object, _sqlQuery.Object);

            Assert.That(() => sut.CreateUser(randomUsername, randomPassword),
                Throws.Exception.TypeOf<ExistingUserException>());
        }
    }
}