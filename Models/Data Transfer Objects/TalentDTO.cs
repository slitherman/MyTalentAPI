namespace MyTalentAPI.Models.Data_Transfer_Objects
{
    public class TalentDTO
    {
        public string TalentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfileText { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string? Github { get; set; }
        public string? Linkedin { get; set; }
       
    }
}
