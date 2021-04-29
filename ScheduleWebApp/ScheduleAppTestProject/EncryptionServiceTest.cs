using NUnit.Framework;
using ScheduleWebApp.BLL;

namespace ScheduleAppTestProject
{
    public class EncryptionServiceTests
    {
        [Test]
        public void RandomSaltIsCreatedIfMethodIsCorrect()
        {
            //act
            var salt = EncryptionService.CreateRandomSalt();

            //assert
            Assert.IsNotNull(salt);
        }

        [Test]
        public void RandomSaltCreateDifferentValues()
        {
            //act
            var salt1 = EncryptionService.CreateRandomSalt();
            var salt2 = EncryptionService.CreateRandomSalt();

            //assert
            Assert.AreNotEqual(salt1, salt2);
        }

        [Test]
        public void SaltedHashIsCreatedIfMethodIsCorrect()
        {
            //arrange
            string saltedHash;

            //act
            saltedHash = EncryptionService.ComputeSaltedHash("abcdek", 304255195);

            //assert
            Assert.IsNotNull(saltedHash);
        }

        [Test]
        public void SaltedHashCreateSameValues()
        {
            //act
            var saltedHash1 = EncryptionService.ComputeSaltedHash("abcdek", 304255195);
            var saltedHash2 = EncryptionService.ComputeSaltedHash("abcdek", 304255195);

            //assert
            Assert.AreEqual(saltedHash1, saltedHash2);
        }
    }
}