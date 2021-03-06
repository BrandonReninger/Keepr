using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);
        }

        // internal VaultKeep Delete(int id, string userId)
        // {
        //     VaultKeep foundKeep = _repo.Delete(id, userId);
        //     if(foundKeep.UserId != userId)
        //     {
        //         throw new Exception("This isn't yours!");
        //     }
        //     if(_repo.Delete)
        // }
    }
}