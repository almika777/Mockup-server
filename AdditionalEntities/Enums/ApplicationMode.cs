using System.Runtime.Serialization;

namespace AdditionalEntities.Enums
{
    public enum ApplicationMode
    {
        [EnumMember(Value = "File")]
        File,
        [EnumMember(Value = "Files")]
        Files,
        [EnumMember(Value = "Dirrectory")]
        Dirrectory
    }
}
