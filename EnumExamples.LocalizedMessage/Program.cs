using System.Linq;
using static System.Console;
using static EnumExamples.LocalizedMessage.LanguageCode;
using static EnumExamples.LocalizedMessage.MessageType;
using MessageFunction =
    System.Func<EnumExamples.LocalizedMessage.MessageType, EnumExamples.LocalizedMessage.LanguageCode, string>;
using Messages =
    System.Collections.Generic.IEnumerable<(string user, EnumExamples.LocalizedMessage.LanguageCode languageCode)>;

namespace EnumExamples.LocalizedMessage
{
    internal class Program
    {
        private static void Main()
        {
            (string user, LanguageCode languageCode)[] messages
                = {("Adam", En), ("Murat", Tr), ("Jean", Fr)};

            ShowMessages(messages, MessageService.GetLocalizedMessage);
            ShowMessages(messages, MessageTypeExtensions.ToLocalizedMessage);
        }

        private static void ShowMessages(Messages messages, MessageFunction messageFunc)
        {
            messages.ToList().ForEach((message) =>
            {
                var (user, languageCode) = message;

                WriteLine(messageFunc(Greeting, languageCode), user);
                WriteLine(messageFunc(Farewell, languageCode), user);
                WriteLine();
            });
        }
    }
}