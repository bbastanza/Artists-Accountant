using Core.Entities;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
using Core.Services.UserServices;
using Infrastructure.Exceptions;
using Moq;
using NUnit.Framework;

namespace Artist.tests.Core.Services.UserServices
{
    [TestFixture]
    public class PatchUserTests
    {
        private Mock<IUserSqlBuilder> _sqlBuilder;
        private Mock<ISqlQuery> _sqlQuery;

        [SetUp]
        public void SetUp()
        {
            _sqlBuilder = new Mock<IUserSqlBuilder>();
            _sqlQuery = new Mock<ISqlQuery>();
        }

        [Test]
        public void Edit_NoChangesToUser_ReturnsSameUser()
        {
            var user = new User {Id = 1};
            var getUserData = new Mock<IGetUserData>();
            getUserData.Setup(x => x.GetDataWithoutArtworks(user.Id)).Returns(user);

            var sut = new PatchUser(getUserData.Object, _sqlBuilder.Object, _sqlQuery.Object);

            var result = sut.Edit(user);

            Assert.That(result, Is.EqualTo(user));
        }

        [Test]
        public void Edit_NonExistingUser_ThrowsNonExistingUserException()
        {
            var user = new User {Id = 1};
            var getUserData = new Mock<IGetUserData>();
            getUserData.Setup(x => x.GetDataWithoutArtworks(user.Id)).Returns((User) null);

            var sut = new PatchUser(getUserData.Object, _sqlBuilder.Object, _sqlQuery.Object);

            Assert.That(() => sut.Edit(user), Throws.Exception.TypeOf<NonExistingUserException>());
        }
    }
}