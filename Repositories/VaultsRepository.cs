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

        //ANCHOR rename vaultkeep, keepvault and move to keep model tomorrow
        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int keepId)
        {
            string sql = @"
            SELECT v.*,
            n.name as Keep
            vk.id AS VaultKeepId
            FROM vaultkeeps vk
            INNER JOIN vaults ON v.id = kv.vaultId
            INNER JOIN keeps ON k.id = kv.keepId
            WHERE keepId = @KeepId";
            return _db.Query<VaultKeepViewModel>(sql, new { keepId });
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