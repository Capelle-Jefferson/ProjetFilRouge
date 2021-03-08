using ProjetFilRouge.Dtos.CandidatesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetFilRouge.Services
{
    public class CandidatesServices
    {
        private CandidateRepository candidateRepository;
        public CandidatesServices(CandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public List<FindCandidateDto> GetCandidates()
        {
            List<Candidate> candidate = candidateRepository.FindAll();
            List<FindCandidateDto> candidatesDtos = new List<FindCandidateDto>();
            foreach (Candidate cat in candidate)
            {
                candidatesDtos.Add(TransformModelToDto(cat));
            }
            return candidatesDtos;
        }

        public FindCandidateDto GetCandidateById(int id)
        {
            Candidate candidat = this.candidateRepository.Find(id);
            return TransformModelToDto(candidat);
        }

        public List<FindCandidateDto> GetCandidateByIdUser(int id)
        {
            List<Candidate> candidate = candidateRepository.FindByIdUser(id);
            List<FindCandidateDto> candidatesDtos = new List<FindCandidateDto>();
            foreach (Candidate cat in candidate)
            {
                candidatesDtos.Add(TransformModelToDto(cat));
            }
            return candidatesDtos;
        }

        public FindCandidateDto PostCandidate(CreateCandidateDto cand)
        {
            Candidate candidatModel = TransformDtoToModel(cand);
            Candidate candidatCreated = candidateRepository.Create(candidatModel);
            return TransformModelToDto(candidatCreated);
        }

        internal int DeleteCandidate(int id)
        {
            return candidateRepository.Delete(id);
        }


        private Candidate TransformDtoToModel(CreateCandidateDto cand)
        {
            return new Candidate(
                cand.idCandidat,
                cand.firstname,
                cand.lastname,
                cand.email,
                cand.idUser,
                cand.idLevel
                );
        }

        private FindCandidateDto TransformModelToDto(Candidate candidat)
        {
            LevelRepository repo = new LevelRepository(new QueryBuilder());
            return new FindCandidateDto(
                    candidat.idCandidate,
                    candidat.firstname,
                    candidat.lastname,
                    candidat.email,
                    (repo.Find((int)candidat.idLevel)).NameLevel,
                    (int)candidat.idUser);
        }

    }
}
