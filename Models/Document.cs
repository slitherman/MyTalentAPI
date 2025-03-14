namespace MyTalentAPI.Models
{
    public class Document
    {

        //uuid
        public string TalentID { get; set; }
        public string DocumentID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }


        public Document(string documentId, string talentId, string name, string content)
        {
            DocumentID = documentId;
            TalentID = talentId;
            Name = name;
            Content = content;

        }
    }
}
