using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vault> GetAll()
        {
            return _repo.GetAll();
        }

        internal IEnumerable<Vault> GetVaultsByUserId(string userId)
        {
            return _repo.GetVaultsByUserId(userId);
        }

        internal Vault GetById(int id)
        {
            Vault foundVault = _repo.GetById(id);
            if (foundVault == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundVault;
        }

        internal Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal string Delete(int id, string userId)
        {
            Vault foundVault = GetById(id);
            if (foundVault.UserId != userId)
            {
                throw new Exception("Not your vault or profile for that matter");
            }
            if (_repo.Delete(id, userId))
            {
                return "Successfully deleted!";
            }
            throw new Exception("We have no idea how you frigged up this bad");
        }

    }
}