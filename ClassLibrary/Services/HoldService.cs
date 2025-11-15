using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;
using ClassLibrary.Repository;

namespace ClassLibrary.Services
{
    public class HoldService : IHoldService
    {
        private readonly HoldRepo _holdRepo;

        public HoldService(HoldRepo holdRepo)
        {
            _holdRepo = holdRepo;
        }

        public List<Hold> GetAllHold()
        {
            return _holdRepo.GetAll();
        }

        public Hold GetHoldById(int id)
        {
            var holdList = _holdRepo.GetAll();
            return holdList.FirstOrDefault(h => h.Id == id);
        }

        public void AddHold(Hold hold)
        {
            if (string.IsNullOrWhiteSpace(hold.HoldId))
            {
                throw new ArgumentException("HoldId cannot be empty");
            }
            _holdRepo.Add(hold);
        }

        public void UpdateHold(Hold hold)
        {
            if (string.IsNullOrWhiteSpace(hold.HoldId))
            {
                throw new ArgumentException("HoldId cannot be empty");
            }
            _holdRepo.Update(hold);
        }

        public void DeleteHold(int id)
        {
            var hold = GetHoldById(id);
            if (hold != null)
            {
                _holdRepo.Delete(hold);
            }
        }
    }
}

