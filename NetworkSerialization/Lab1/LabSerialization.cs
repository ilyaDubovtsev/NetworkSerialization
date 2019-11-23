using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Common;
using Serialization;

namespace Lab1
{
    public class LabSerialization
    {
        public static string Process(string serializationTypeString, string serializedInputString)
        {
            var serializationType = StringToSerializationType(serializationTypeString);
            var serializationProvider = SuperSerializer.GetSerializer(serializationType);

            var input = serializationProvider.Deserialize<Input>(serializedInputString);

            var output = new Output()
            {
                SumResult = input.Sums.Sum(s => s * input.K),
                MulResult = input.Muls.Aggregate(1, (current, mul) => current * mul),
                SortedInputs = input.Sums
                    .Concat(input.Muls.Select(x => (decimal) x))
                    .OrderBy(x => x)
                    .ToArray()
            };

            var serializedOutput = serializationProvider.Serialize(output);

            return serializedOutput;
        }

        private static SerializationType StringToSerializationType(string serializationTypeString)
        {
            switch (serializationTypeString.ToLower())
            {
                case "json":
                    return SerializationType.Json;
                case "xml":
                    return SerializationType.Xml;
                default:
                    throw new ArgumentException($"Неопознанный тип сериализации {serializationTypeString}");
            }
        }
    }
}