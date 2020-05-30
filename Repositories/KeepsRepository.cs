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

        internal IEnumerable<Keep> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM keeps WHERE userId = @UserId";
            return _db.Query<Keep>(sql, new { userId });
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

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            //NOTE don't forget SELECT next time, ugh!!!
            string sql = @"
            SELECT
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)
            ";
            return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
        }

        internal Keep Edit(Keep keepToUpdate)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate,
            views =@Views,
            shares =@Shares,
            keeps =@Keeps
            WHERE id = @Id LIMIT 1";
            _db.Execute(sql, keepToUpdate);
            return keepToUpdate;
        }
    }
}