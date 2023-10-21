namespace UploadFilesLibrary;

public interface ISqlDataAccess
{
    Task<List<T>> LoadData<T>(string stroredProc, string connectionName, object? parameters);
    Task SaveData(string stroredProc, string connectionName, object parameters);
}