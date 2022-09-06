using SampleAPI.Application.Services.SystemAssociation.Common;

namespace SampleAPI.Application.Services.SystemAssociation.Commands
{
    public interface IDataElementCommandService
    {
        bool DeleteDataElementById(string Name);
        DataElement AddDataElements(DataElement dataElement);
        DataElement UpdateDataElements(DataElement dataElement);
    }
}
