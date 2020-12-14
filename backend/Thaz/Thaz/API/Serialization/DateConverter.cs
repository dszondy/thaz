using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Thaz.API.Serialization
{
        public class DateTimeConverter : JsonConverter<DateTime?>
        {
            public override DateTime? Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                try
                {
                    return DateTime.ParseExact(reader.GetString(),
                        "yyyy.MM.dd.", CultureInfo.InvariantCulture);
                }
                catch (Exception e)    
                {
                    return null;
                }
            }

            public override void Write(
                Utf8JsonWriter writer,
                DateTime? dateTimeValue,
                JsonSerializerOptions options)
            {
                if (dateTimeValue != null)
                {
                    writer.WriteStringValue(((DateTime) dateTimeValue).ToString(
                        "yyyy.MM.dd.", CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
        }
    }