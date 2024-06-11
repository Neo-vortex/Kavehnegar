namespace Neovortex.KavehNegar.Utilities;

public static class Consts
{
    public const string BASE_URL = "https://api.kavenegar.com/v1/";

    public const string UTILS_SCOPE_NAME = "utils";
    public const string SEND_SMS_SCOPE_NAME = "sms";
    public const string VERIFY_SCOPE_NAME = "verify";
    public const string CALL_SCOPE_NAME = "call";
    public const string ACCOUNT_SCOPE_NAME = "account";


    public const string GET_DATE_METHOD_NAME = "getdate";
    public const string SEND_SMS_METHOD_NAME = "send";
    public const string SEND_ARRAY_SMS_METHOD_NAME = "sendarray";
    public const string MESSAGE_STATUS_METHOD_NAME = "status";
    public const string MESSAGE_STATUS_LOCAL_MESSAGE_ID_METHOD_NAME = "statuslocalmessageid";
    public const string MESSAGE_SELECT_METHOD_NAME = "select";
    public const string MESSAGE_SELECT_OUTBOX_METHOD_NAME = "selectoutbox";
    public const string MESSAGE_LATEST_OUTBOX_METHOD_NAME = "latestoutbox";
    public const string MESSAGE_COUNT_OUTBOX_METHOD_NAME = "countoutbox";
    public const string MESSAGE_CANCEL_METHOD_NAME = "cancel";
    public const string MESSAGE_RECEIVE_METHOD_NAME = "receive";
    public const string MESSAGE_COUNT_INBOX_METHOD_NAME = "countinbox";
    public const string LOOKUP_METHOD_NAME = "lookup";
    public const string MAKETTS_METHOD_NAME = "maketts";
    public const string INFO_METHOD_NAME = "info";


    public const int MESSAGE_MAX_LEN = 900;
    public const int RECEPTORS_MAX_COUNT = 200;
    public const int MAX_PAGE_SIZE = 500;
}