using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;

namespace ProjetFilRouge.Services
{
    public class AnswerServices
    {
        private AnswerRepository AnswerRepository;
        private ChoiceAnswerRepository ChoiceAnswerRepository;

        public AnswerServices()
        {
            AnswerRepository = new AnswerRepository(new QueryBuilder());
            ChoiceAnswerRepository = new ChoiceAnswerRepository(new QueryBuilder());
        }

        /// <summary>
        ///     Retourne une liste de Levels
        /// </summary>
        /// <returns></returns>
        public List<FindAnswerDto> GetAnswers()
        {
            List<Answer> answers = AnswerRepository.FindAll();
            List<FindAnswerDto> levelsDto = new List<FindAnswerDto>();
            foreach (Answer answer in answers)
            {
                levelsDto.Add(TransformModelToDto(answer));
            }
            return levelsDto;
        }

        /// <summary>
        ///    Permet de transformer un DTO en Model
        /// </summary>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        private Answer TransformDtoToModel(CreateAnswerDto ans)
        {
            return new Answer(null, ConvertStringToTypeAnswer(ans.TypeAnswer), ans.Explication, ans.TextAnswer);
        }

        /// <summary>
        ///     Retourne un Answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal FindAnswerDto GetAnswerById(int id)
        {
            Answer ans = AnswerRepository.Find(id);
            if(ans.IdAnswer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return TransformModelToDto(ans);
        }

        /// <summary>
        ///    Permet de transformer un Model en DTO
        /// </summary>
        /// <param name="Model answer"></param>
        /// <returns></returns>
        private FindAnswerDto TransformModelToDto(Answer ans)
        { 
            if (ans.TypeAnswer!= TypeAnswer.Text)
            {
                return new FindAnswerDto(ans.IdAnswer, ConvertTpeAnserToString(ans.TypeAnswer), ans.Explication, ans.TextAnswer,GetListChoiceAnswer((int)ans.IdAnswer));
            } else
            {
                return new FindAnswerDto(ans.IdAnswer, ConvertTpeAnserToString(ans.TypeAnswer), ans.Explication, ans.TextAnswer);
            }
            
        }

        private string ConvertTpeAnserToString(TypeAnswer typeAnswer)
        {
            switch (typeAnswer)
            {
                case TypeAnswer.QCM:
                    return "QCM";
                case TypeAnswer.QCM_multiple:
                    return "QCM_multiple";
                case TypeAnswer.Text:
                    return "Text";
                default:
                    return "Text";
            }
        }
        private TypeAnswer ConvertStringToTypeAnswer(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "qcm":
                    return TypeAnswer.QCM;
                case "qcm_multiple":
                    return TypeAnswer.QCM_multiple;
                case "text":
                    return TypeAnswer.Text;
                default:
                    throw new Exception("Le type answer n'est pas reconnus");
            }
        }

        private List<FindChoiceAnswerDto>  GetListChoiceAnswer(int id)
        {
            List<ChoiceAnswer> listChoiceAnswer = ChoiceAnswerRepository.FindList(id);
            List<FindChoiceAnswerDto> listChoiceDto = new List<FindChoiceAnswerDto>();
            foreach(ChoiceAnswer choice in listChoiceAnswer)
            {
                listChoiceDto.Add(TransformeModelToChoiceDto(choice));
            }
            return listChoiceDto;
        }

        private FindChoiceAnswerDto TransformeModelToChoiceDto(ChoiceAnswer choice)
        {
            return new FindChoiceAnswerDto(
                choice.IdChoiceAnswer,
                choice.TextAnswer,
                choice.IsAnswer
                );
        }

        /// <summary>
        ///     Crée un answer
        /// </summary>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        internal FindAnswerDto PostAnswer(CreateAnswerDto value)
        {
            // Enregistrement Answer
            Answer answerModel = TransformDtoToModel(value);
            Answer answerCreated = this.AnswerRepository.Create(answerModel);

            // Enregistrement des Choices answers si il s'agit d'un QCM
            if(answerCreated.TypeAnswer != TypeAnswer.Text)
            {
                foreach (CreateChoiceAnswerDto choiceDto in  value.ListChoiceAnswer)
                {
                    this.ChoiceAnswerRepository.Create(TransformChoiceDtoToModel(choiceDto, (int)answerCreated.IdAnswer));
                }
            }

            return TransformModelToDto(answerCreated);
        }

        private ChoiceAnswer TransformChoiceDtoToModel(CreateChoiceAnswerDto choiceDto, int idAnswer)
        {
            return new ChoiceAnswer(
                null,
                choiceDto.TextAnswer,
                choiceDto.IsAnswer,
                idAnswer
            );;
        }

        /// <summary>
        ///     Mets à jour un Answer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        internal FindAnswerDto PutAnswer(int id, CreateAnswerDto ans)
        {
            Answer answerModel = TransformDtoToModel(ans);
            Answer answerUpdated = this.AnswerRepository.Update(id, answerModel);
            return TransformModelToDto(answerUpdated);
        }

        /// <summary>
        ///     Permet de supprimer un Answer
        /// </summary>
        /// <param name="id"></param>
        internal int Delete(int id)
        {
            ChoiceAnswerRepository choiceAnswerRepo = new ChoiceAnswerRepository(new QueryBuilder());
            choiceAnswerRepo.DeleteByIdAnswer(id);
            return this.AnswerRepository.Delete(id);
        }
    }
}