using chat_bot_demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace chat_bot_demo.Controllers
{
    public class BotController(IChatBotService _chatBotService) : Controller
    {
        //private readonly IChatBotService _chatBotService;
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInputModel userInput)
        {
            try
            {
                // Get user input text
                var userText = userInput.UserPrompt;

                // Call OpenAI API to process the user input
                var openAiResponse = await _chatBotService.GetOpenAiResponseAsync(userText);

                // Create a response containing OpenAI's response and the tutorial video URL
                var responseMessage = new
                {
                    TextResponse = openAiResponse,
                    TutorialVideoUrl = ""
                };

                // Return the response back to the user
                return Ok(responseMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling OpenAI: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                return BadRequest(ex.Message);
            }
        }

        public class UserInputModel
        {
            public string UserPrompt { get; set; }
        }
    }
}
