using System;
using System.Threading.Channels;
using static System.Console;
using static EnumExamples.LocalizedMessage.LanguageCode;
using static EnumExamples.LocalizedMessage.MessageType;

namespace EnumExamples.LocalizedMessage
{
    public class MessageService
    {
        private const string GreetingMessageEn = "Hello {0}.";
        private const string FarewellMessageEn = "Good bye {0}.";
        private const string GreetingMessageTr = "Merhaba {0}.";
        private const string FarewellMessageTr = "Güle güle {0}.";
        private const string GreetingMessageFr = "Bonjour {0}.";
        private const string FarewellMessageFr = "Au revoir {0}.";

        public static string GetLocalizedMessage(MessageType messageType, LanguageCode languageCode) =>
            messageType switch
            {
                Greeting => languageCode switch
                {
                    En => GreetingMessageEn,
                    Tr => GreetingMessageTr,
                    Fr => GreetingMessageFr,
                    _ => throw new ArgumentOutOfRangeException(nameof(languageCode), languageCode, null)
                },
                Farewell => languageCode switch
                {
                    En => FarewellMessageEn,
                    Tr => FarewellMessageTr,
                    Fr => FarewellMessageFr,
                    _ => throw new ArgumentOutOfRangeException(nameof(languageCode), languageCode, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null)
            };
    }
}