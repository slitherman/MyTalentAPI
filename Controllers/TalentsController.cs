using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTalentAPI.Interfaces;
using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;

namespace MyTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentsController : ControllerBase
    {

        private readonly ITalents _talents;

        public TalentsController(ITalents talents)
        {
            _talents = talents;
        }

        [HttpGet("Talents")]
        public ActionResult<IReadOnlyList<TalentDTO>> GetTalents()
        {
            var result = _talents.GetTalents();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<TalentDTO> GetTalentById(string id) {

            var result = _talents.GetTalentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}documents")] 
        public ActionResult<IReadOnlyList<DocumentDTO>> GetDocumentsFromTalent(string id)
        {
            var result = _talents.GetDocumentsFromTalent(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{talentId}documents/{documentId}")] 
        public ActionResult<DocumentDTO> GetDocumentFromTalent(string talentId, string documentId)
        {
            var result = _talents.GetDocumentFromTalent(talentId, documentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
