namespace UnifiedMedicalLanguageSystem
{
    public interface IQueryResponse
    {
        int PageCount { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}