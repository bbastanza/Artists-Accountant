using Artist.tests.TestUtilities;
using Core.Entities;
using Core.Services.SqlBuilders;
using NUnit.Framework;

namespace Artist.tests.Core.Services.SqlBuilders
{
    [TestFixture]
    public class UserSqlBuilderTests
    {
        private UserSqlBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UserSqlBuilder();
        }

        [Test]
        public void GenerateUpdateStatement_WhenCalled_ReturnsCorrectSqlStatement()
        {
            var randomUsername = TestData.CreateRandomString();
            var randomPassword = TestData.CreateRandomString();
            var randomProfileImageUrl = TestData.CreateRandomString();
            var user = new User
            {
                Id = 1,
                Username = randomUsername,
                Password = randomPassword,
                ProfileImgUrl = randomProfileImageUrl
            };

            var sqlStatement = _sut.GenerateUpdateStatement(user);

            Assert.That(sqlStatement.StartsWith($"UPDATE user_table SET "));
            Assert.That(sqlStatement.Contains("username"));
            Assert.That(sqlStatement.Contains("password"));
            Assert.That(sqlStatement.Contains("profile_image_url"));
            Assert.That(sqlStatement.Contains($"{randomUsername}"));
            Assert.That(sqlStatement.Contains($"{randomPassword}"));
            Assert.That(sqlStatement.Contains($"{randomProfileImageUrl}"));
            Assert.That(sqlStatement.EndsWith($"WHERE id = {user.Id};"));
        }

        [Test]
        public void GenerateUpdateStatement_WhenCalledWithEmptyUser_ReturnsBlankSqlStatement()
        {
            var user = new User();

            var sqlStatement = _sut.GenerateUpdateStatement(user);

            Assert.That(sqlStatement, Is.EqualTo($"UPDATE user_table SET WHERE id = {user.Id};"));
        }
    }
}