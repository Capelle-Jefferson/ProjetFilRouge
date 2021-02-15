using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.CandidatesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetFilRouge.Services
{
    public class CandidatesServices
    {
        private CandidateRepository candidateRepository;
        public CandidatesServices()
        {
            candidateRepository = new CandidateRepository(new QueryBuilder());
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
            Candidate candidat = candidateRepository.Find(id);
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

        internal FindCandidateDto PutCandidate(int id, CreateCandidateDto updatecandidate)
        {
            //Candidate candidateModel = TransformDtoToModel(updatecandidate);
            //Candidate candidateUpdated = this.candidateRepository.Update(id, candidateModel);
            //return TransformModelToDto(candidateUpdated);

            Candidate candidateModel = candidateRepository.Find(id);
            candidateModel = CheckBeforeUpdate(candidateModel, updatecandidate);
            candidateModel = candidateRepository.Update(id, candidateModel);
            return TransformModelToDto(candidateModel);
        }

        private Candidate CheckBeforeUpdate(Candidate candidateModel, CreateCandidateDto updatecandidate)
        {
            if (candidateModel.firstname != updatecandidate.firstname)
            {
                candidateModel.firstname = updatecandidate.firstname;
            }
            if (candidateModel.lastname != updatecandidate.lastname)
            {
                candidateModel.lastname = updatecandidate.lastname;
            }
            if (candidateModel.email != updatecandidate.email)
            {
                candidateModel.email = updatecandidate.email;
            }
            if (updatecandidate.idUser != null && candidateModel.idUser != updatecandidate.idUser)
            {
                candidateModel.idUser = (int)updatecandidate.idUser;
            }
            if (updatecandidate.idLevel != null && candidateModel.idLevel != updatecandidate.idLevel)
            {
                candidateModel.idLevel = (int)updatecandidate.idLevel;
            }
            return candidateModel;
        }

        internal int DeleteCandidate(int id)
        {
            return candidateRepository.Delete(id);
        }


        private Candidate TransformDtoToModel(CreateCandidateDto cand)
        {
            return new Candidate(
                cand.idCandidate,
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
