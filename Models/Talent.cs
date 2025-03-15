namespace MyTalentAPI.Models
{
   
    public class Talent
    {   //uuid
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
        public List<Document> Documents { get; set; }

        public Talent(string talentId, string name, string description, string profileText, string email, string countryCode, string phone, string country, string? github = null, string? linkedin = null)
        {
            TalentID = talentId;
            Name = name;
            Description = description;
            ProfileText = profileText;
            Email = email;
            CountryCode = countryCode;
            Phone = phone;
            Country = country;
            Github = github;
            Linkedin = linkedin;
            Documents = new List<Document>();
        }

        public string GetFormattedPhoneNumber()
        {
            return $"+{CountryCode}{Phone}";
        }
    }
}
