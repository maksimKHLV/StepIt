using kargo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace kargo.Services.Classes;

public static class SerializationService<T> where T : class
{
    public static string Serialization(T obj)
    {
        var json = JsonSerializer.Serialize<T>(obj);
        return json;

    }

    public static T? Deserialization(string? text)
    {
        if(text != null)
        {
            var json = JsonSerializer.Deserialize<T>(text);
                return json;
        }
        return null;

    }
}