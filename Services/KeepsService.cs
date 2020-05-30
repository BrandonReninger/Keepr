using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("invalid id");
            }
            return foundKeep;
        }

        internal IEnumerable<Keep> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetById(id);
            if (foundKeep.UserId != userId)
            {
                throw new Exception("That's not yours mang!");
            }
            if (_repo.Delete(id, userId))
            {
                return "successfully disposed of!";
            }
            throw new Exception("I don't even know man!");
        }

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }

        internal Keep Edit(int id, Keep updatedKeep)
        {
            Keep foundKeep = GetById(id);
            foundKeep.Name = updatedKeep.Name;
            foundKeep.Description = updatedKeep.Description;
            foundKeep.Img = updatedKeep.Img;
            foundKeep.IsPrivate = updatedKeep.IsPrivate;
            foundKeep.Views = updatedKeep.Views;
            foundKeep.Shares = updatedKeep.Shares;
            foundKeep.Keeps = updatedKeep.Keeps;
            return _repo.Edit(foundKeep);
        }

    }
}