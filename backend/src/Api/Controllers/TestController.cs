using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController
    {
        private readonly IEmailService _emailService;

        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            var message = new EmailMessage
            {
                To = "ivanchavezbrb@gmail.com",
                Body = "This is a test email from Ecommerce Application",
                Subject = "Ecommerce Application - Test Email"
            };

            var result = await _emailService.SendEmailAsync(message, "This_is_my_token");
            return result ? new OkResult() : new BadRequestResult();
        }
    }
}
