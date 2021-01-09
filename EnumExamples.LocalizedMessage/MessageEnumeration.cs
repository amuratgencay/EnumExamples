using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using static EnumExamples.LocalizedMessage.MessageType;

namespace EnumExamples.LocalizedMessage
{
    public class MessageEnumeration
    {
        private static readonly Dictionary<LanguageCode, Dictionary<MessageType, string>> LocalizedMessageMap;

        public static string ToLocalizedMessage(LanguageCode languageCode, MessageType messageType)
            => LocalizedMessageMap[languageCode][messageType];

        static MessageEnumeration()
        {
            LocalizedMessageMap = JsonSerializer.Deserialize<List<LocalizedMessage>>
                    (Properties.Resources.LocalizedMessages)
                .ToDictionary(
                    localizedMessage => Enum.Parse<LanguageCode>(localizedMessage.LanguageCode),
                    localizedMessage => new Dictionary<MessageType, string>
                    {
                        {Greeting, localizedMessage.Greeting},
                        {Farewell, localizedMessage.Farewell},
                    });

            Console.WriteLine();
        }

        private class LocalizedMessage
        {
            public string LanguageCode { get; }
            public string Greeting { get;  }
            public string Farewell { get; }
        }
    }

    public static class MessageTypeExtensions
    {
        public static string ToLocalizedMessage(this MessageType messageType, LanguageCode languageCode)
            => MessageEnumeration.ToLocalizedMessage(languageCode, messageType);
    }
}