using System.IO;
namespace CIK.Weather.API.Import
{
    public interface IImporter
    {
        Stream GetStream(string path);
        SmhiResponseObject DeserializeStream(Stream response);
        void SaveObject(SmhiResponseObject root);
    }
}
