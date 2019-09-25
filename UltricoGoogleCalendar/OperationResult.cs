namespace UltricoGoogleCalendar
{
    public class OperationResult
    {
        public static OperationResult OkResult => new OperationResult("OK");

        public OperationResult(string code)
        {
            this.Code = code;
        }

        public string Code { get; }
    }
}