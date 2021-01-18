using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class ResponseCollection<T>
    {
        public ResponseCollection() { }

        [JsonPropertyName("value")]
        public List<T> Value { get; set; }
    }
}