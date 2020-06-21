using BLL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Contracts.Services
{
    public interface IFormula1Service
    {
        Task<List<Formula1Team>> GetFormula1s();

        Task CreateFormula1Team(Formula1Team formula1Team);

        Task DeleteFormula1Team(Guid id);

        Task UpdateFormula1Team(Formula1Team formula1Team);
    }
}
