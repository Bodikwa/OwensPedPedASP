using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndServices.Interfaces
{
   public interface IProvenceRepository
    {

        IEnumerable<Provence> GetAllProvences();
        Provence GetProvenceById(int Provenceid);
        void InsertProvence(Provence provence);
        void UpdateProvence(Provence provence);
        void DeleteProvence(int ProvenceId);
        void SaveProvence();
    }
}
