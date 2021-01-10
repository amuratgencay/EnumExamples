using System;
using System.Collections.Generic;
using System.Linq;
using static System.Text.Json.JsonSerializer;
using static EnumExamples.LocalizedMessage.MessageType;
using static EnumExamples.LocalizedMessage.Properties.Resources;
using LocalizedMessageMap = System.Collections.Generic.Dictionary<EnumExamples.LocalizedMessage.LanguageCode, System.Collections.Generic.Dictionary<EnumExamples.LocalizedMessage.MessageType, string>>;
namespace EnumExamples.LocalizedMessage
{
    public class MessageEnumeration
    {
        private static readonly LocalizedMessageMap LocalizedMessageMap;

        public static string ToLocalizedMessage(LanguageCode languageCode, MessageType messageType)
            => LocalizedMessageMap[languageCode][messageType];

        static MessageEnumeration()
        {
            LocalizedMessageMap = Deserialize<List<LocalizedMessage>>(LocalizedMessages)
                .ToDictionary(
                    localizedMessage => Enum.Parse<LanguageCode>(localizedMessage.LanguageCode),
                    localizedMessage => new Dictionary<MessageType, string>
                    {
                        {Greeting, localizedMessage.Greeting},
                        {Farewell, localizedMessage.Farewell},
                    });
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