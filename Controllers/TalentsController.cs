using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTalentAPI.Interfaces;
using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;
using System.Linq;
using System.Xml;

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

        /// <summary>
        /// Retrieves all available talents.
        /// </summary>
        /// <returns>
        /// An immutable list of <see cref="IReadOnlyList{TalentDTO}"/> if talents exist;
        /// otherwise, returns a 204 No Content status.
        /// </returns>
        /// <remarks>
        /// Sample output:
        ///     api/Talents
        ///     
        /// 
        ///         {
        ///             talentID: f3ed2d1e-36d3-4792-b509-047882d88d9e
        ///             name: Drinking water
        ///             description: Is able to drink an absurd amount of water
        ///             profileText: Im so thirsty,
        ///             email: faisalerdum@gmail.com,
        ///             formattedPhoneNumber": +4531500309,
        ///             country: Denmark",
        ///             github: https://github.com/slitherman,
        ///             linkedin: https://www.linkedin.com/in/faisal-abdi-2a44891b6/
        ///         }
        ///         
        /// 
        /// </remarks>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TalentDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IReadOnlyList<TalentDTO>> GetTalents()
        {
            try {
                var result = _talents.GetTalents();
                return Ok(result);
            }
            catch (ArgumentNullException) {
            
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An unknown error {new { message = ex.Message}} has occurred");
            }
       
    
            {
                return NoContent();
            }
   
        }


        /// <summary>
        /// Retrieves talent with a given TalentID.
        /// </summary>
        /// <returns>
        /// A TalentDTO object <see cref="TalentDTO"/> if talents exist;
        /// otherwise, returns a 404 Not Found Status.
        /// </returns>
        /// <remarks>
        /// Sample output:
        ///     api/Talent/{talentID}"
        ///     
        ///
        ///         {
        ///             talentID: f3ed2d1e-36d3-4792-b509-047882d88d9e
        ///             name: Drinking water
        ///             description: Is able to drink an absurd amount of water
        ///             profileText: Im so thirsty,
        ///             email: faisalerdum@gmail.com,
        ///             formattedPhoneNumber": +4531500309,
        ///             country: Denmark,
        ///             github: https://github.com/slitherman,
        ///             linkedin: https://www.linkedin.com/in/faisal-abdi-2a44891b6/
        ///         }
        ///         
        /// 
        /// </remarks>
        [HttpGet("Talent/{talentID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TalentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TalentDTO> GetTalentById(string talentID) {
            try {
                var result = _talents.GetTalentById(talentID);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{new { message = ex.Message }}");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"An unknown error error {new { message = ex.Message}} has occurred");
            }

            
           
        }

        /// <summary>
        /// Retrieves a list of documents for a given TalentID.
        /// </summary>
        /// <returns>
        /// An immutable list of DocumentDTO's <see cref="IReadOnlyList{T}"/> if talentID exist;
        /// otherwise, returns a 404 Not Found Status.
        /// </returns>
        /// <remarks>
        /// Sample output:
        ///     api/{talentID}/documents"
        ///     
        ///
        ///      [
        ///         {
        ///             documentID: 255aceac-cc97-49cd-89cd-5a34e051a052,
        ///             talentID: 919c1aa4-0543-4272-85bd-7ade35272c63
        ///             name": Hydration Report
        ///             content": Analysis of daily water intake patterns and effects on health.
        ///      },
        ///         {
        ///             documentID: 9e8a6b48-15f4-40bd-9131-ba60fa56934e
        ///             talentID": 919c1aa4-0543-4272-85bd-7ade35272c63
        ///             name: Water-Drinking Records
        ///             content": Compilation of world records for most water consumed in a day
        ///         }
        ///      ]
        ///         
        /// 
        /// </remarks>
        [HttpGet("{talentID}/documents")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<DocumentDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IReadOnlyList<DocumentDTO>> GetDocumentsFromTalent(string talentID)
        {
            try {

                var result = _talents.GetDocumentsFromTalent(talentID);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{new { message = ex.Message }}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{new { message = ex.Message }}");
            }
        }

        /// <summary>
        /// Retrieves document with a given TalentID and DocumentID.
        /// </summary>
        /// <returns>
        /// A DocumentDTO object <see cref="DocumentDTO"/> if TalentID and DocumentID exist;
        /// otherwise, returns a 404 Not Found Status.
        /// </returns>
        /// <remarks>
        /// Sample output:
        ///     api/Talent/{talentId}/documents/{documentId}"
        ///     
        ///
        ///         {
        ///             documentID: f1366301-7483-4474-83b4-a2df79c6fde8
        ///             talentID: 590dc0c3-4f96-48f6-b1c3-d3d1eba076bf
        ///             name: Hydration Report
        ///             content: Analysis of daily water intake patterns and effects on health.
        ///         }
        ///         
        /// 
        /// </remarks>
        [HttpGet("{talentID}/documents/{documentID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DocumentDTO> GetDocumentFromTalent(string talentID, string documentID)
        {
            try
            {
                var result = _talents.GetDocumentFromTalent(talentID, documentID);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{new { message = ex.Message }}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{new { message = ex.Message }}");
            }
        
         
            
        }
    }
}
