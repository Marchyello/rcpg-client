namespace RcpgMicroserviceClient.Models
{
    public enum PaymentStatus
    {
        None,
        Initiated,
        Canceled,
        Authorized,
        Captured
    }

    public enum ErrorType
    {
        None,
        EmptyReturnParam,
        EmptyTransactionId,
        InvalidIntent,
        NotCancelable,
        PaymentNotFound
    }
}