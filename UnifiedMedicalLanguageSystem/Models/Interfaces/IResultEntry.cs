namespace UnifiedMedicalLanguageSystem.Models
{
    public interface IResultEntry
    {
        string Name { get; set; }
        string RootSource { get; set; }
        string UI { get; set; }
    }
}