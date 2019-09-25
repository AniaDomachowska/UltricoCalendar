namespace UltricoGoogleCalendar.Controllers
{
    public class OperationResult
    {
        public static OperationResult OkResult => new OperationResult("OK");

        public OperationResult(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}