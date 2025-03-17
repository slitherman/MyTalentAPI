using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTalentAPI.Interfaces;
using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;
using System.Linq;
using System.Xml;

namespace MyTalentAPI.Controllers
{
    [Produces("application/json")]
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
        /// <remarks>
        /// **Sample Request**:
        ///     api/Talents
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
        /// </remarks>
        /// <response code="200"> Displaying available talents. </response>
        /// <response code="204"> No talents are currently available. </response>
        /// <response code="500"> The API could not handle the request or ran into internal issues. </response>
        [HttpGet()]
        [Produces("application/json")]
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
        }


        /// <summary>
        /// Retrieves talent with a given TalentID.
        /// </summary>
        /// <param name="talentID">The unique identifier of the talent (GUID format) </param>
        /// 
        /// <remarks>
        /// **sample Request**:
        ///    api/Talents/f3ed2d1e-36d3-4792-b509-047882d88d9e
        /// 
        ///             {
        ///                 talentID: f3ed2d1e-36d3-4792-b509-047882d88d9e
        ///                 name: Drinking water
        ///                 description: Is able to drink an absurd amount of water
        ///                 profileText: Im so thirsty,
        ///                 email: faisalerdum@gmail.com,
        ///                 formattedPhoneNumber": +4531500309,
        ///                 country: Denmark,
        ///                 github: https://github.com/slitherman,
        ///                 linkedin: https://www.linkedin.com/in/faisal-abdi-2a44891b6/
        ///             }
        /// </remarks>
        /// <response code="200"> Talent found. </response>
        /// <response code="404"> No talent found for the given TalentID. </response>
        /// <response code="500"> The API could not handle the request or ran into internal issues. </response>
        [HttpGet("{talentID}")]
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
        /// <param name="talentID">The unique identifier of the talent (GUID format) </param>
        /// <remarks>
        /// **Sample Request**:
        ///     api/Talents/919c1aa4-0543-4272-85bd-7ade35272c63/documents
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
        /// </remarks>
        /// <response code="200"> Displaying all available documents </response>
        /// <response code="404"> No documents could be found </response>
        /// <response code="500"> The API could not handle the request or ran into internal issues. </response>
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
        /// <param name="talentID">The unique identifier of the talent (GUID format) </param>
        /// <param name="documentID">The unique identifier of the document (GUID format) </param>
        /// <remarks>
        /// **Sample Request**:
        ///     api/Talents/590dc0c3-4f96-48f6-b1c3-d3d1eba076bf/documents/f1366301-7483-4474-83b4-a2df79c6fde8
        ///     
        ///         {
        ///             documentID: f1366301-7483-4474-83b4-a2df79c6fde8
        ///             talentID: 590dc0c3-4f96-48f6-b1c3-d3d1eba076bf
        ///             name: Hydration Report
        ///             content: Analysis of daily water intake patterns and effects on health.
        ///         }
        /// </remarks>
        /// /// <response code="200"> Displaying document. </response>
        /// <response code="404"> Document could not be found. </response>
        /// <response code="500"> The API could not handle the request or ran into internal issues. </response>
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
