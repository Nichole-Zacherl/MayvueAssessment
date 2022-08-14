using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Extensions.Logging.Abstractions;
using MotionPictureAPI;
using MotionPictureAPI.DAO;
using NUnit.Framework;

namespace MotionPictureTests
{
    public class MotionPitureDAOTests
    {
        MotionPictureDAO sut = new MotionPictureDAO(@"Server=P137G001\SQLEXPRESS; Database=Movies; Trusted_Connection=Yes;", NullLogger<MotionPictureDAO>.Instance);

        [SetUp]
        public void Setup()
        {

        }



        [Test]
        public async Task Copy_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };
            var created = await sut.Create(motionPicture);
            var copy = await sut.Copy(motionPicture.ID);
            Assert.True(copy);

        }

        [Test]
        public async Task Create_ShouldSucceed()
        {
            // Arrange
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };

            // Act
            var created = await sut.Create(motionPicture);

            //Assert
            Assert.True(created);
        }

        [Test]
        public async Task Delete_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };
            var created = await sut.Create(motionPicture);
            var deleted = await sut.Delete(motionPicture.ID);
            Assert.True(deleted);
        }

        [Test]
        public async Task GetAll_ShouldSucceed()
        {
            var motionPictures = await sut.GetAll();
            Assert.IsNotEmpty(motionPictures);
        }


        [Test]
        public async Task Update_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };
            var created = await sut.Create(motionPicture);
            motionPicture.Name = "foo";
            Assert.True(await sut.Update(motionPicture));
        }



    }
}