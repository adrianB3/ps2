using System;
using server.Models;
using server.Resources;

namespace server.Services
{
    public class SaveDataResponse : BaseResponse
    {
        public Data Data { get; private set; }
        public SaveDataResponse(bool success, string message, Data data) : base(success, message)
        {
            Data = data;
        }

        public SaveDataResponse(Data data) : this(true, String.Empty, data){}
        public SaveDataResponse(string message) : this(false, message, null){}
    }
}