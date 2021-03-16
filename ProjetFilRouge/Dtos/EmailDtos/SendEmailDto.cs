using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.EmailDtos
{
    public class SendEmailDto
    {
        public SendEmailDto()
        {
        }

        public SendEmailDto(string email, string message, string subject)
        {
            Email = email;
            Message = message;
            Subject = subject;
        }

        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
