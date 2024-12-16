using OpenAI.Net;

namespace chat_bot_demo.Services
{
    public class ChatBotService(IOpenAIService openAIService) : IChatBotService
    {
        public async Task<string> GetOpenAiResponseAsync(string prompt)
        {
            var messages = new List<Message>
        {
            Message.Create(ChatRoleType.Assistant, prompt),
            Message.Create(ChatRoleType.User, prompt)
        };

            var response = await openAIService.Chat.Get(messages, o => {
                o.Model = "gpt-3.5-turbo";
                o.MaxTokens = 1000;
            });

            if (response.IsSuccess)
            {
                return response.Result.Choices[0].Message.Content;
            }
            else
            {
                throw new InvalidOperationException($"Error calling OpenAI: {response.ErrorMessage}");
            }
        }
    }

    public interface IChatBotService
    {
        Task<string> GetOpenAiResponseAsync(string prompt);
    }
}
