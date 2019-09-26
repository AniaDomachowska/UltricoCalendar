namespace UltricoGoogleCalendar
{
    public class OperationResult
    {
        public static OperationResult OkResult => new OperationResult("OK");

        public static OperationResult CreateOkResult(object result)
        {
            return new OperationResult("OK", result);
        }

        public OperationResult(string code, object result = null)
        {
            this.Code = code;
            Result = result;
        }

        public string Code { get; }
        public object Result { get; }
    }
}