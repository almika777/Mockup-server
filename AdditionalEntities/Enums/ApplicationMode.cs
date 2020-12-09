using System.Runtime.Serialization;

namespace Common.Enums
{
    public enum ApplicationMode
    {
        [EnumMember(Value = "File")]
        File,
        [EnumMember(Value = "Files")]
        Files,
        [EnumMember(Value = "Directory")]
        Directory
    }
}
