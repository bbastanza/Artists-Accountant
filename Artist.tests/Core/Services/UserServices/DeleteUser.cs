using Core.Entities;
using Core.Services.DbServices;
using Core.Services.UserServices;
using Infrastructure.Exceptions;
using Moq;
using NUnit.Framework;

namespace Artist.tests.Core.Services.UserServices
{
    [TestFixture]
    public class DeleteUserTests
    {
        private Mock<ISqlQuery> _sqlQuery;

        [SetUp]
        public void SetUp()
        {
            _sqlQuery = new Mock<ISqlQuery>();
        }

        [Test]
        public void Delete_NonExistingUser_ThrowsNonExistingUserException()
        {
            int? userId = 1;
            var getUserData = new Mock<IGetUserData>();
            getUserData.Setup(x => x.GetDataWithoutArtworks(userId)).Returns((User) null);

            var sut = new DeleteUser(getUserData.Object, _sqlQuery.Object);

            Assert.That(() => sut.Delete(userId), Throws.Exception.TypeOf<NonExistingUserException>());
        }
    }
}