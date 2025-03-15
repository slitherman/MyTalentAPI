namespace MyTalentAPI.Models.Data_Transfer_Objects
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a Talent entity in the API response.
    /// This class is used to expose only necessary talent-related information 
    /// while ensuring that documents or other sensitive data are not included.
    /// </summary>
    public class TalentDTO
    {
        /// <summary>
        /// Unique identifier for the talent.
        /// </summary>
        public string TalentID { get; set; }
        /// <summary>
        /// The name of the talent.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A brief description of the talent’s skills or abilities.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// A short introduction or profile text associated with the talent.
        /// </summary>
        public string ProfileText { get; set; }
        /// <summary>
        /// The email address associated with the talent.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The phone number of the talent, including the country code.
        /// </summary>
        public string FormattedPhoneNumber { get; set; }
        /// <summary>
        /// The country code for the talent’s phone number (e.g., "45" for Denmark).
        /// </summary>

        /// <summary>
        /// The country where the talent is located.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The GitHub profile URL of the talent. This property is optional.
        /// </summary>
        public string? Github { get; set; }
        /// <summary>
        /// The LinkedIn profile URL of the talent. This property is optional.
        /// </summary>
        public string? Linkedin { get; set; }
       
    }
}
