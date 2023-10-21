namespace UploadFilesLibrary;

public interface ISqlDataAccess
{
    Task SaveData(string stroredProc, string connectionName, object parameters);
}