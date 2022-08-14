using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotionPictureAPI.DAO
{
    public interface IMotionPictureDAO
    {
        Task<bool> Create(MotionPicture motionPicture);
        Task<bool> Copy(int originalId);
        Task<bool> Delete(int id);
        Task<List<MotionPicture>> GetAll();
        Task<bool> Update(MotionPicture motionPicture);
    }
}