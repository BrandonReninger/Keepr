using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate, views, shares, keeps)
            VALUES
            (@userId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id LIMIT 1";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}