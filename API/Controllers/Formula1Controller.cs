using BLL.Contracts.Services;
using BLL.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/formula1s")]
    public class Formula1Controller : Controller
    {
        private readonly IFormula1Service _formula1Service;

        public Formula1Controller(IFormula1Service formula1Service)
        {
            _formula1Service = formula1Service;
        }

        [Route("")]
        public async Task<IActionResult> GetFormula1s()
        {
            var formula1s = await _formula1Service.GetFormula1s();
            return Ok(formula1s);
        }

        [HttpPost]
        [Authorize]
        [Route("create")]
        public async Task<IActionResult> CreateFormula1([FromBody] Formula1Team formula1team)
        {
            await _formula1Service.CreateFormula1Team(formula1team);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("update")]
        public async Task<IActionResult> UpdateFormula1([FromBody] Formula1Team formula1team)
        {
            await _formula1Service.UpdateFormula1Team(formula1team);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> DeleteFormula1(Guid id)
        {
            await _formula1Service.DeleteFormula1Team(id);
            return Ok();
        }
    }
}
