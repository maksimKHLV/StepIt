using kargo.Services.Classes;
using System.Collections.Generic;

namespace kargo.Model;

public static class DictionaryUsers
{
    static DictionaryUsers()
    {
        var text = FileService.ReadAs("Data.json");
        User = SerializationService<Dictionary<string, User>>.Deserialization(text) ?? new();
    }
    public static Dictionary<string, User>? User { get; set; } = new();
}