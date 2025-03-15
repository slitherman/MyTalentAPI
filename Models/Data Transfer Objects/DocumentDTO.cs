namespace MyTalentAPI.Models.Data_Transfer_Objects
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a document associated with a talent.
    /// This class is used to expose document-related information.
    /// 
    /// </summary>
    public class DocumentDTO
    {

        /// <summary>
        /// Unique identifier for the document.
        /// </summary>
        public string DocumentID { get; set; }
        /// <summary>
        /// The unique identifier of the talent to whom this document belongs.
        /// </summary>
        public string TalentID { get; set; }
        /// <summary>
        /// The name or title of the document.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The content or description of the document.
        /// </summary>
        public string Content { get; set; }

     
    }
}
