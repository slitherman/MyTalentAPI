using Microsoft.AspNetCore.Mvc.Formatters;
using MyTalentAPI.Models;
using MyTalentAPI.Models.Data_Transfer_Objects;
using System.Collections.Generic;

namespace MyTalentAPI.Mapper
{
    public static class ManualMapper
    {
        public static TalentDTO MapTalentToDTO(Talent talent)
        {
            if (talent == null)
            {
               throw new ArgumentNullException("No talent object found");
            }
            var talentDTO = new TalentDTO
            {
                TalentID = talent.TalentID,
                Name = talent.Name,
                Description = talent.Description,
                ProfileText = talent.ProfileText,
                Email = talent.Email,
                CountryCode = talent.CountryCode,
                Phone = talent.Phone,
                Country = talent.Country,
                Github = talent.Github,
                Linkedin = talent.Linkedin,

            };
            return talentDTO;
        }
        public static DocumentDTO MapDocumentToDTO(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("No document object found");
            }
   
            var documentDTO = new DocumentDTO
            {
                DocumentID = document.DocumentID,
                TalentID  = document.TalentID,
                Content = document.Content,
                Name = document.Name,
            };
            return documentDTO;
        }
        public static IReadOnlyList<TalentDTO> MapTalentsToDTOs(IReadOnlyList<Talent> talents)
        {
            var talentDTOs = new List<TalentDTO>(); 
            if (talents == null)
            {
                throw new ArgumentNullException("TalentDTO collection has no members");
            }
            foreach( var talent in talents)
            {
                talentDTOs.Add(MapTalentToDTO(talent));
            }
            return talentDTOs;
        }
        public static IReadOnlyList<DocumentDTO> MapDocumentsToDTOs(IReadOnlyList<Document> documents)
        {
            var documentDTOs = new List<DocumentDTO>();
            if (documents == null)
            {
                throw new ArgumentNullException("DocumentDTO collection has no members");
            }
            foreach (var document in documents)
            {
                documentDTOs.Add(MapDocumentToDTO(document));
            }
       
            return documentDTOs;
        }
        
    }
}

