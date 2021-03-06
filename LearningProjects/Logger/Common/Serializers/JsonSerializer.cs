﻿using Logger.Contracts;
using Newtonsoft.Json;


namespace Logger.Common.Serializers
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
