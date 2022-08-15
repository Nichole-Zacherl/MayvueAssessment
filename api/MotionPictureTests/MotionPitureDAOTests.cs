using System.Threading.Tasks;
using System.Transactions;
using MotionPictureAPI;
using MotionPictureAPI.DAO;
using NUnit.Framework;

namespace MotionPictureTests
{
    public class MotionPitureDAOTests
    {
        private readonly MotionPictureDAO _sut = new MotionPictureDAO(@"Server=P137G001\SQLEXPRESS; Database=Movies; Trusted_Connection=Yes;");

        [Test]
        public async Task Create_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };

            await _sut.Create(motionPicture);

            Assert.NotZero(motionPicture.ID);
        }

        [Test]
        public async Task Delete_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };
            await _sut.Create(motionPicture);
            var deleted = await _sut.Delete(motionPicture.ID);
            Assert.True(deleted);
        }

        [Test]
        public async Task GetAll_ShouldSucceed()
        {
            var motionPictures = await _sut.GetAll();
            Assert.IsNotEmpty(motionPictures);
        }

        [Test]
        public async Task Update_ShouldSucceed()
        {
            using var trasactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var motionPicture = new MotionPicture { Name = "test", Description = "test film", ReleaseYear = 2022 };
            await _sut.Create(motionPicture);
            motionPicture.Name = "foo";
            Assert.True(await _sut.Update(motionPicture));
        }
    }
}