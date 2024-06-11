namespace Neovortex.KavehNegar.Model.Enums;

public enum MessageStatus
{
    PENDING = 1,
    SCHECHULED = 2,
    SENT_TO_TELECOMMUNICATION = 4,
    SENT_TO_TELECOMMUNICATION_ALTERNATIVE = 5,
    FAILED_TO_SEND = 6,
    DELIVERED = 10,
    FAILED_TO_DELIVER = 11,
    CANCELED = 13,
    BLOCKED = 14,
    INVALID = 100
}