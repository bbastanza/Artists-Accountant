using System;
using Artist.tests.TestUtilities;
using Core.Entities;
using Core.Services.JwtAuthentication;
using Core.Services.UserServices;
using Infrastructure.Exceptions;
using Moq;
using NUnit.Framework;

namespace Artist.tests.Core.Services.JwtAuthentication
{
    [TestFixture]
    public class GenerateJwtTokenTests
    {
        private Mock<IGetUserAuth> _getUserAuth;
        private string _key;

        [SetUp]
        public void SetUp()
        {
            _key = TestData.CreateRandomString();
            _getUserAuth = new Mock<IGetUserAuth>();
        }

        [Test]
        public void Authenticate_NonExistingUser_ThrowsNonExistingUserException()
        {
            var randomUsername = TestData.CreateRandomString();
            var randomPassword = TestData.CreateRandomString();
            _getUserAuth.Setup(x => x.Get(randomUsername)).Returns((User) null);

            var sut = new GenerateJwtToken(_key, _getUserAuth.Object);

            Assert.That(() => sut.Authenticate(randomUsername, randomPassword),
                Throws.Exception.TypeOf<NonExistingUserException>());
        }

        [Test]
        public void Authenticate_InvalidPassword_ThrowsUserValidationException()
        {
            var randomUsername = TestData.CreateRandomString();
            var randomPassword = TestData.CreateRandomString();
            var testUser = new User
            {
                Password = BCrypt.Net.BCrypt.HashPassword(TestData.CreateRandomString()),
                Username = randomUsername
            };
            _getUserAuth.Setup(x => x.Get(randomUsername)).Returns(testUser);

            var sut = new GenerateJwtToken(_key, _getUserAuth.Object);

            Assert.That(() => sut.Authenticate(randomUsername, randomPassword),
                Throws.Exception.TypeOf<UserValidationException>());
        }

        [Test]
        public void Authenticate_ValidInput_ReturnsJwtToken()
        {
            var randomUsername = TestData.CreateRandomString();
            var randomPassword = TestData.CreateRandomString();
            var testUser = new User
            {
                Password = BCrypt.Net.BCrypt.HashPassword(randomPassword),
                Username = randomUsername
            };
            _getUserAuth.Setup(x => x.Get(randomUsername)).Returns(testUser);

            var sut = new GenerateJwtToken(_key, _getUserAuth.Object);

            var jwtToken = sut.Authenticate(randomUsername, randomPassword);

            Assert.That(jwtToken, Is.TypeOf<string>());
        }

        [Test]
        public void NewUserToken_WhenCalled_ReturnsJwtToken()
        {
            var sut = new GenerateJwtToken(_key, _getUserAuth.Object);

            var testUser = new User
            {
                Username = TestData.CreateRandomString()
            };

            var jwtToken = sut.NewUserToken(testUser);

            Assert.That(jwtToken, Is.TypeOf<string>());
        }

        [Test]
        public void NewUserToken_InvalidUsername_ThrowsSystemException()
        {
            var sut = new GenerateJwtToken(_key, _getUserAuth.Object);

            var testUser = new User();

            Assert.That(() => sut.NewUserToken(testUser), Throws.Exception);
        }
    }
}