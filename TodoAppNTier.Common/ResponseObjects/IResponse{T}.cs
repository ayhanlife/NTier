namespace TodoAppNTier.Common.ResponseObjects
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidatinoError> ValidationErrors { get; set; }
    }
}
