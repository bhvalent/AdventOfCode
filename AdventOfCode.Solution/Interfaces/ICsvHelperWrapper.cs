public interface ICsvHelperWrapper
{
    List<T> GetRecords<T>(StreamReader reader);
}