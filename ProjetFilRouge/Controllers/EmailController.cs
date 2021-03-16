using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.EmailDtos;
using ProjetFilRouge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {

        private EmailService emailServices;
        public EmailController(EmailService emailService)
        {
            this.emailServices = emailService;
        }


        [HttpPost("/api/SendEmail")]
        public bool SendEmail([FromBody] SendEmailDto sendEmail)
        {
            return this.emailServices.SendEmail(sendEmail);
        }
    }
}
