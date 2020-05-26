using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> GetAll()
        {
            string sql = "SELECT * FROM vaults";
            return _db.Query<Vault>(sql);
        }

        internal Vault GetById(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId)
        {
            string sql = @"
            k.*,
            vk.id AS vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)
            ";
            return _db.Query<VaultKeepViewModel>(sql, new { vaultId });
        }

        internal IEnumerable<Vault> GetVaultsByUserId(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @UserId";
            return _db.Query<Vault>(sql, new { userId });
        }

        internal Vault Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return newVault;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}