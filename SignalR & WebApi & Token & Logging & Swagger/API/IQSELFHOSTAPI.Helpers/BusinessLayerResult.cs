using IQSELFHOSTAPI.Helpers.Messages;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Helpers
{
    public class BusinessLayerResult<T>
    {
        public bool Result { get; set; }
        public List<ErrorMessageObj> Errors { get; set; }
        public T Object { get; set; }

        public List<T> Objects { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj { Code = code, Message = message });
        }
    }
}