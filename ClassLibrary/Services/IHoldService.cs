using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

namespace ClassLibrary.Services
{
    public interface IHoldService
    {
        List<Hold> GetAllHold();
        Hold GetHoldById(int id);
        void AddHold(Hold hold);
        void UpdateHold(Hold hold);
        void DeleteHold(int id);
    }
}

