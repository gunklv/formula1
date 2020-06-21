using BLL.Contracts.Repository;
using BLL.Contracts.Services;
using BLL.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Formula1Service : IFormula1Service
    {
        private readonly IRepository<Formula1Team> _formula1Repository;

        public Formula1Service(IRepository<Formula1Team> formula1Repository)
        {
            _formula1Repository = formula1Repository;
        }

        public async Task<List<Formula1Team>> GetFormula1s()
            => await _formula1Repository.GetAll();

        public async Task CreateFormula1Team(Formula1Team formula1Team)
        {
            await _formula1Repository.Create(formula1Team);
            await _formula1Repository.SaveChangesAsync();
        }

        public async Task DeleteFormula1Team(Guid id)
        {
            await _formula1Repository.Delete(id);
            await _formula1Repository.SaveChangesAsync();
        }

        public async Task UpdateFormula1Team(Formula1Team formula1Team)
        {
            await _formula1Repository.Update(formula1Team);
            await _formula1Repository.SaveChangesAsync();
        }
    }
}
