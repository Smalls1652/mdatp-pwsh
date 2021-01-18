using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MdatpPwsh.Helpers
{
    public class JsonConverter<T>
    {
        public JsonConverter(string inputData)
        {
            ConvertFrom(inputData);
        }

        public T Value
        {
            get { return value; }
        }
        private T value;

        private void ConvertFrom(string input)
        {
            JsonSerializerOptions serializationOptions = new JsonSerializerOptions
            {
                Converters = {
                    new JsonStringEnumConverter()
                }
            };

            T convertedData = JsonSerializer.Deserialize<T>(input, serializationOptions);

            value = convertedData;
        }
    }
}