using System.Text.Json.Serialization;

namespace Paychecks.Api.Database.Models;

[JsonConverter(typeof(JsonStringEnumConverter<Relationship>))]
public enum Relationship
{
    None,
    Spouse,
    DomesticPartner,
    Child
}
