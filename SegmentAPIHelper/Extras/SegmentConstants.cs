namespace SegmentAPIHelper.Extras
{
    public static class SegmentConstants
    {
        public const string IDENTIFY_TYPE = "identify";
        public const string TRACK_TYPE = "track";
        public const string PAGE_TYPE = "page";
        public const string SCREEN_TYPE = "screen";
        public const string GROUP_TYPE = "group";
        public const string ALIAS_TYPE = "alias";
        public const string BATCH_TYPE = "batch";
        public const int MAX_SEND_SIZE_IN_BYTES = 32000;
        public const int MAX_BATCH_SEND_SIZE_IN_BYTES = 500000;
    }
}