using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;
using System.Reflection.Metadata;
using Document = MyTalentAPI.Models.Document;

namespace MyTalentAPI.Interfaces
{
    public interface ITalents
    {
        IReadOnlyList<TalentDTO> GetTalents();
        TalentDTO GetTalentById(string id);
        IReadOnlyList<DocumentDTO> GetDocumentsFromTalent(string talentId);
        DocumentDTO GetDocumentFromTalent(string talentId, string DocumentId);

    }
}
