using ConcessionnaireAPI.Models;
using ConcessionnaireAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionnaireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcessionnaireController : ControllerBase
    {
        private IConcessionnaireRepository _repository;

        public ConcessionnaireController(IConcessionnaireRepository concessionnaireRepository)
        {
            _repository = concessionnaireRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetConcessionnaires()
        {
            var concessionnaires = await _repository.GetAll();
            return Ok(concessionnaires);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConcessionnaire(int id)
        {
            var resultat =  await _repository.GetById(id);
            return resultat == null? NotFound(): Ok(resultat);
        }

        [HttpPost]
        public async Task<IActionResult> PostConcessionnaire(Concessionnaire concessionnaire)
        {
            var resultat = await _repository.Add(concessionnaire);
            return Ok(resultat);
        }

        [HttpPut]
        public async Task<IActionResult> PutConcessionnaire(int id, Concessionnaire concessionnaire)
        {
            if (id != concessionnaire.Id)
                return BadRequest();

            var resultat = await _repository.Update(id, concessionnaire);
            return Ok(resultat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionnaire(int id)
        {
            var concessionnaire =  await _repository.GetById(id);
             if (concessionnaire == null)
                return NotFound();

            await _repository.DeleteById(id);

            return NoContent();
        }

    }
}
