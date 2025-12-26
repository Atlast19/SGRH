

using System.Net.NetworkInformation;

namespace SGRH.Domein.Base
{
    public class OperationResult<TModel>
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; } = string.Empty;
        public TModel Data { get; set; }

        public OperationResult()
        {
            
        }

        public OperationResult(bool IsSucces, string Message, dynamic? Data = null)
        {
            this.IsSucces = IsSucces;
            this.Message = Message;
            this.Data = Data;
        }

        public static OperationResult<TModel> Succes(string Message, dynamic? data = null) 
        {
            return new OperationResult<TModel>(true, Message, data);
        }

        public static OperationResult<TModel> Failure(string Message)
        {
            return new OperationResult<TModel>(false, Message);
        }
    }
}
