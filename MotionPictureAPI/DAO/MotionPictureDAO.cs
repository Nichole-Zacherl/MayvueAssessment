using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MotionPictureAPI.DAO
{
    public class MotionPictureDAO : IMotionPictureDAO
    {
        private readonly string _connectionString;

        public MotionPictureDAO(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public async Task<List<MotionPicture>> GetAll()
        {
            const string sql = "SELECT * FROM MotionPictures";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return (await connection.QueryAsync<MotionPicture>(sql)).ToList();
        }

        public async Task Create(MotionPicture motionPicture)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = @"
                INSERT INTO MotionPictures (Name, Description, ReleaseYear)
                OUTPUT Inserted.ID
                VALUES(@Name, @Description, @ReleaseYear)";

            motionPicture.ID = await connection.QuerySingleAsync<int>(sql, motionPicture);
        }

        public async Task<bool> Update(MotionPicture motionPicture)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = @"
                    UPDATE MotionPictures
                    SET Name = @Name, Description = @Description, ReleaseYear = @ReleaseYear
                    WHERE id = @id";

            var rowsAffected = await connection.ExecuteAsync(sql, motionPicture);
            return rowsAffected != 0;
        }

        public async Task<bool> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "DELETE FROM MotionPictures WHERE id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected != 0;
        }
    }
}
