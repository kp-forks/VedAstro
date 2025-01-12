﻿using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;

namespace VedAstro.Library
{

    /// <summary>
    /// Splits a nature of a prediction into sub categories, Body, Mind, etc.
    /// </summary>
    public class SpecializedNature
    {
        /// <summary>
        /// default, with all neutral which equates to 0
        /// </summary>
        public static SpecializedNature Empty = new()
        {
            Body = EventNature.Neutral,
            Family = EventNature.Neutral,
            Finance = EventNature.Neutral,
            Mind = EventNature.Neutral
        };


        public EventNature Body { get; init; }
        public EventNature Mind { get; init; }
        public EventNature Finance { get; init; }
        public EventNature Family { get; init; }


        /// <summary>
        /// if not filled in autos to neutral,
        /// this allows to add only what is needed into code
        /// </summary>
        public static SpecializedNature FromXml(XElement xmlElement)
        {
            //if null then return default, with all neutral which equates to 0
            if (xmlElement == null) { return SpecializedNature.Empty; }

            //if not filled in XML, value autos to neutral
            var body = xmlElement.Element("Body")?.Value ?? "Neutral";
            var mind = xmlElement.Element("Mind")?.Value ?? "Neutral";
            var finance = xmlElement.Element("Finance")?.Value ?? "Neutral";
            var family = xmlElement.Element("Family")?.Value ?? "Neutral";

            //package data together
            var returnVal = new SpecializedNature()
            {
                Body = (EventNature)Enum.Parse(typeof(EventNature), body),
                Family = (EventNature)Enum.Parse(typeof(EventNature), family),
                Finance = (EventNature)Enum.Parse(typeof(EventNature), finance),
                Mind = (EventNature)Enum.Parse(typeof(EventNature), mind)
            };

            return returnVal;
        }


        public static SpecializedNature FromJson(JObject jsonObject)
        {
            //if null then return default, with all neutral which equates to 0
            if (jsonObject == null) { return SpecializedNature.Empty; }
            //if not filled in JSON, value autos to neutral
            var body = jsonObject["Body"]?.Value<string>() ?? "Neutral";
            var mind = jsonObject["Mind"]?.Value<string>() ?? "Neutral";
            var finance = jsonObject["Finance"]?.Value<string>() ?? "Neutral";
            var family = jsonObject["Family"]?.Value<string>() ?? "Neutral";
            //package data together
            var returnVal = new SpecializedNature()
            {
                Body = (EventNature)Enum.Parse(typeof(EventNature), body),
                Family = (EventNature)Enum.Parse(typeof(EventNature), family),
                Finance = (EventNature)Enum.Parse(typeof(EventNature), finance),
                Mind = (EventNature)Enum.Parse(typeof(EventNature), mind)
            };
            return returnVal;
        }


        public static JObject ToJson(SpecializedNature specializedNature)
        {
            if (specializedNature == null) { return null; }
            var jsonObject = new JObject
            {
                ["Body"] = specializedNature.Body.ToString(),
                ["Mind"] = specializedNature.Mind.ToString(),
                ["Finance"] = specializedNature.Finance.ToString(),
                ["Family"] = specializedNature.Family.ToString()
            };
            return jsonObject;
        }


    }
}
