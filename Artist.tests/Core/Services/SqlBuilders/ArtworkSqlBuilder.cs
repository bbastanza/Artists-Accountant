using Artist.tests.TestUtilities;
using Core.Entities;
using Core.Services.SqlBuilders;
using NUnit.Framework;

namespace Artist.tests.Core.Services.SqlBuilders
{
    [TestFixture]
    public class ArtworkSqlBuilderTests
    {
        private ArtworkSqlBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ArtworkSqlBuilder();
        }

        [Test]
        public void GenerateUpdateStatement_WhenCalled_GeneratesCorrectSqlStatement()
        {
            var randomCustomerName = TestData.CreateRandomString();
            var randomCustomerContact = TestData.CreateRandomString();
            var artwork = new ArtWork
                {
                    Id = 1,
                    UserId = 10, 
                    CustomerName = randomCustomerName, 
                    CustomerContact = randomCustomerContact
                };
                
            var sqlStatement = _sut.GenerateUpdateStatement(artwork);

            Assert.That(sqlStatement.StartsWith($"UPDATE artwork_table SET "));
            Assert.That(sqlStatement.Contains("user_id"));
            Assert.That(sqlStatement.Contains("customer_name"));
            Assert.That(sqlStatement.Contains("customer_contact"));
            Assert.That(sqlStatement.Contains($"{artwork.UserId}"));
            Assert.That(sqlStatement.Contains($"{randomCustomerName}"));
            Assert.That(sqlStatement.Contains($"{randomCustomerContact}"));
            Assert.That(sqlStatement.EndsWith($"WHERE id = {artwork.Id};"));
            
            Assert.That(!sqlStatement.Contains("date_finished"));
            Assert.That(!sqlStatement.Contains("sale_price"));
        }

        [Test]
        public void GenerateInsertStatement_WhenCalledWithValidArtwork_GeneratesEmptySqlStatement()
        {
            var randomCustomerName = TestData.CreateRandomString();
            var randomCustomerContact = TestData.CreateRandomString();
        
            var artwork = new ArtWork
                {
                    Id = 1,
                    UserId = 10, 
                    CustomerName = randomCustomerName, 
                    CustomerContact = randomCustomerContact
                };
                
            var sqlStatement = _sut.GenerateInsertStatement(artwork);
                
            Assert.That(sqlStatement.StartsWith($"INSERT INTO artwork_table ("));
            Assert.That(sqlStatement.Contains(") VALUES ("));
            Assert.That(sqlStatement.Contains("user_id"));
            Assert.That(sqlStatement.Contains("customer_name"));
            Assert.That(sqlStatement.Contains("customer_contact"));
            Assert.That(sqlStatement.Contains($"{artwork.UserId}"));
            Assert.That(sqlStatement.Contains($"{randomCustomerName}"));
            Assert.That(sqlStatement.Contains($"{randomCustomerContact}"));
            Assert.That(sqlStatement.EndsWith(");"));
            
            Assert.That(!sqlStatement.Contains("date_finished"));
            Assert.That(!sqlStatement.Contains("sale_price"));

        }
        
        [Test]
        public void GenerateInsertStatement_WhenCalledWithEmptyArtwork_GeneratesEmptySqlStatement()
        {
            var artwork = new ArtWork();
                
            var sqlStatement = _sut.GenerateInsertStatement(artwork);

            Assert.That(sqlStatement, Is.EqualTo($"INSERT INTO artwork_table () VALUES ();"));
        }
    }
}