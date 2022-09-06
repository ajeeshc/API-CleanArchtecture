

using SampleAPI.Application.Services.SystemAssociation.Common;

namespace SampleAPI.Application.Services.SystemAssociation.Commands
{
    public interface IDataElementService
    {
        List<DataElement> GetDataElements();
        DataElement GetDataElementsByID(int ID);
    }
}
