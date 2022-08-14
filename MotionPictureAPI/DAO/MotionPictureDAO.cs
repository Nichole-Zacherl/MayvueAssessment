using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;

namespace MotionPictureAPI.DAO
{

    public class MotionPictureDAO : IMotionPictureDAO
    {
        private readonly string connectionString;
        private readonly ILogger<MotionPictureDAO> logger;

        public MotionPictureDAO(string connectionString, ILogger<MotionPictureDAO> logger)
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = ""
            };

            this.connectionString = connectionString;
            this.logger = logger;
        }

        public async Task<List<MotionPicture>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM MotionPictures";
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var motionPictures = (await connection.QueryAsync<MotionPicture>(sql)).ToList();
                return motionPictures;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unable to complete action");
                return null;
            }
        }

        public async Task<bool> Create(MotionPicture motionPicture)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);

                string sql = @"
                INSERT INTO MotionPictures (Name, Description, ReleaseYear)
                OUTPUT Inserted.ID
                VALUES(@Name, @Description, @ReleaseYear)";
                var newId = await connection.QuerySingleAsync<int>(sql, motionPicture);
                motionPicture.ID = newId;
                return newId != 0;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unable to create motion picture");
            }
            return false;
        }

        public async Task<bool> Copy(int originalId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);

                string sql = @"
                    INSERT INTO MotionPictures (Name, Description, ReleaseYear)
                    SELECT Name, Description, ReleaseYear
                    FROM MotionPictures
                    WHERE id = @originalId";

                var rowsAffected = await connection.ExecuteAsync(sql, new { originalId });
                return rowsAffected != 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unable to copy motion picture {originalId}");
            }
            return false;
        }


        public async Task<bool> Update(MotionPicture motionPicture)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                string sql = @"
                    UPDATE MotionPictures
                    SET Name = @Name, Description = @Description, ReleaseYear = @ReleaseYear
                    WHERE id = @id";

                var rowsAffected = await connection.ExecuteAsync(sql, motionPicture );
                return rowsAffected != 0;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unable to Delete");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM MotionPictures WHERE id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected != 0;
        }

    }
}
