using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            JsonElement root = doc.RootElement;
            string type = root.GetProperty("Type").GetString();
            Goal goal = type switch
            {
                "SimpleGoal" => JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options),
                "EternalGoal" => JsonSerializer.Deserialize<EternalGoal>(root.GetRawText(), options),
                "ChecklistGoal" => JsonSerializer.Deserialize<ChecklistGoal>(root.GetRawText(), options),
                _ => throw new NotSupportedException($"Goal type '{type}' is not supported.")
            };
            return goal;
        }
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Type", value.GetType().Name);
        writer.WriteString("Name", value.Name);
        writer.WriteString("Description", value.Description);
        writer.WriteNumber("Points", value.Points);

        if (value is ChecklistGoal checklistGoal)
        {
            writer.WriteNumber("TimesCompleted", checklistGoal.TimesCompleted);
            writer.WriteNumber("Target", checklistGoal.Target);
            writer.WriteNumber("Bonus", checklistGoal.Bonus);
        }

        writer.WriteEndObject();
    }
}
