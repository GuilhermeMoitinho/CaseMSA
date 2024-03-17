using System.Text.Json.Serialization;

namespace CaseMSA.Domain.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderEnum
    {
        Masculino,
        Feminino
    }
}
