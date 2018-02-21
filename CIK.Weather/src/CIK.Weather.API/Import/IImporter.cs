namespace CIK.Weather.API.Import
{
    public interface IImporter
    {
        string GetResponse(string path);
        void SaveResponse(string response);
    }
}
