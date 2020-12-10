using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdventOfCodeShared.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTime.ParseExact(reader.GetString() ?? "",
                    "yyyy-MM-dd HH:mm:ss+0000", CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    "yyyy-MM-dd HH:mm:ss+0000", CultureInfo.InvariantCulture));
    }
}