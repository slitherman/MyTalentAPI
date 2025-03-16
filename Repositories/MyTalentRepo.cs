using MyTalentAPI.Interfaces;
using MyTalentAPI.Mapper;
using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;

namespace MyTalentAPI.Repositories
{
    public class MyTalentRepo:ITalents
    {
        //Readonly ref lists are still mutable
        private readonly List<Talent> _talents; //= new List<Talent>();
        private readonly List<Document> _documents; //= new List<Document>();
                                                    //Exposed immutable list used for consumption so the contents cant be modified
        public IReadOnlyList<Talent> Talents => _talents;
        public IReadOnlyList<Document> Documents => _documents;

        public MyTalentRepo()
        {
            _talents = new List<Talent>
        {
            new Talent(Guid.NewGuid().ToString(), "Drinking water", "Is able to drink an absurd amount of water",
                "Im so thirsty", "faisalerdum@gmail.com", "45", "31500309",  "Denmark", "https://github.com/slitherman", "https://www.linkedin.com/in/faisal-abdi-2a44891b6/"),
            new Talent(Guid.NewGuid().ToString(), "Eating", "Once ate over 4000 calories worth of food in one sitting", "Feed me" ,"upzkzo+80zbkvultfiu4@sharklasers.com","61", "12345678","Australia" ),
            new Talent(Guid.NewGuid().ToString(), "Rock Paper Scissors", "Has somehow never lost a game of rock paper scissors in their life", "Lets play","upzi6t+a4gfajut0ot4w@sharklasers.com","45","2244668", "Denmark" ),
            new Talent(Guid.NewGuid().ToString(), "Sleeping", "Regularly gets more than 10 hours of rest a day", "ZZZ" ,"ltjovlkx@sharklasers.com","34", "29340001","Spain" ),
            new Talent(Guid.NewGuid().ToString(), "Trivia", "This person is a literal human encyclopedia", "https://www.wikipedia.org/","upzi6t+a4gfajut0ot4w@sharklasers.com","46","1122334455", "Sweden"),

        };
            _documents = new List<Document>
        {
            new Document(Guid.NewGuid().ToString(),  _talents[0].TalentID,"Hydration Report","Analysis of daily water intake patterns and effects on health."),
            new Document(Guid.NewGuid().ToString(),_talents[0].TalentID, "Water-Drinking Records", "Compilation of world records for most water consumed in a day."),

            new Document(Guid.NewGuid().ToString(),  _talents[1].TalentID ,"Competitive Eating Guide", "A breakdown of calorie-dense foods and professional eating strategies"),
            new Document(Guid.NewGuid().ToString(), _talents[1].TalentID,"Metabolism and Overeating", "Research on how extreme food intake affects human metabolism."),

            new Document(Guid.NewGuid().ToString(), _talents[2].TalentID,"Rock Paper Scissors Strategy", "A study on probability, psychology, and optimal game strategy."),
            new Document(Guid.NewGuid().ToString(), _talents[2].TalentID,"Game Theory in RPS", "How Nash Equilibrium applies to Rock Paper Scissors."),

            new Document(Guid.NewGuid().ToString(), _talents[3].TalentID,"The Science of Sleep", "Research on sleep cycles, circadian rhythm, and optimizing rest."),
            new Document(Guid.NewGuid().ToString(), _talents[3].TalentID,"Lucid Dreaming Techniques", "A guide to controlling dreams and maximizing sleep quality."),

            new Document(Guid.NewGuid().ToString(), _talents[4].TalentID,"Trivia Mastery Handbook", "A compilation of general knowledge spanning history, science, and pop culture."),
            new Document(Guid.NewGuid().ToString(), _talents[4].TalentID,"Memory Techniques for Trivia", "A guide to improving recall and memorization skills."),
        };
            // used to link the two lists by appending the _documents list to the _talents list
            ListLinker();
        }
        public IReadOnlyList<TalentDTO> GetTalents()
        {

            if (Talents.Count > 0)
            {
              return ManualMapper.MapTalentsToDTOs(Talents);
            }
            throw new ArgumentNullException("No talents could be found.");
        }
        public TalentDTO GetTalentById(string talentID)
        {
            var talent = Talents.FirstOrDefault(x => x.TalentID == talentID);
            if (talent == null)
            {
                throw new KeyNotFoundException($"No talent with the talentID {talentID} could be found.");
            }
           return ManualMapper.MapTalentToDTO(talent);
        }
        public IReadOnlyList<DocumentDTO> GetDocumentsFromTalent(string talentID)
        {
  
            if (string.IsNullOrEmpty(talentID))
            {
                throw new ArgumentNullException($"No talent document with the talentID {talentID} could be found");
            }
            var filteredDocuments = Documents.Where(x => x.TalentID == talentID && talentID != null).ToList();
            if (!filteredDocuments.Any()) {

                throw new KeyNotFoundException($"No documents found for the talent ID: {talentID}");
            }
            return ManualMapper.MapDocumentsToDTOs(filteredDocuments);
        }

        public DocumentDTO GetDocumentFromTalent(string talentID, string documentID)
        {
            var foundDocument = Documents.FirstOrDefault(x => x.TalentID == talentID && x.DocumentID == documentID);
            if (foundDocument == null)
            {
                throw new KeyNotFoundException($"No document with the documentID {documentID} for talent with the talentID {talentID} could be found");
            }
          
            return ManualMapper.MapDocumentToDTO(foundDocument);
        }
        //helper function
        public int ListLinker()
        {
            int count = 0;
            foreach (var document in _documents)
            {
                var talent = _talents.FirstOrDefault(t => t.TalentID == document.TalentID);
                if (talent != null)
                {
                    talent.Documents.Add(document);
                    count++;
                }
            }
            return count;
        }
    }
}
