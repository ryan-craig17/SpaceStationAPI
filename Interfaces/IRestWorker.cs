using SpaceStationAPI.DataLayer;
using SpaceStationAPI.Models;
using System.Collections.Specialized;

namespace SpaceStationAPI.Interfaces
{
    public interface IRestWorker
    {
        public Task<T> CallService<T>(Uri wsURL, HttpVerb httpVerb = HttpVerb.Get, object data = null, NameValueCollection headerData = null) where T : BaseResponse;
    }
}
