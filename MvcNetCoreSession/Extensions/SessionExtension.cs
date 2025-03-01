﻿using MvcNetCoreSession.Helpers;
using Newtonsoft.Json;

namespace MvcNetCoreSession.Extensions
{
    public static class SessionExtension
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            if(json == null)
            {
                return default(T);
            }
            else
            {
                T data = HelperJsonSession.DeserializableObject<T>(json);
                return data;
            }
        }

        public static void SetObject<T>(this ISession session, string key, object value)
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);

        }

       
    }
}
