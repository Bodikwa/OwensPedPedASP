using BackEndServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using OwensPedPed.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class ProvenceRepository : IProvenceRepository
    {
        private readonly OwensPedPedDBContext _context;

        public ProvenceRepository(OwensPedPedDBContext context)
        {
            _context = context;
        }

        public void DeleteProvence(int ProvenceId)
        {
            Provence provence = _context.Provences.Find(ProvenceId);
            _context.Provences.Remove(provence);
        }

        public IEnumerable<Provence> GetAllProvences()
        {
            return _context.Provences.ToList();
        }

        public Provence GetProvenceById(int Provenceid)
        {
            return _context.Provences.Find(Provenceid);
        }

        public void InsertProvence(Provence provence)
        {
            _context.Provences.Add(provence);
        }

        public void SaveProvence()
        {
            _context.SaveChanges();
        }

        public void UpdateProvence(Provence provence)
        {
            _context.Entry(provence).State = EntityState.Modified;
        }
    }
}
