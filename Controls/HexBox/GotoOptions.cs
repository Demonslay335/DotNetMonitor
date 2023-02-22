namespace DotNetMonitor.Controls.HexBox
{
    public enum GotoOffsetRelative
    {
        Begin,
        Current,
        End
    }

    public struct GotoOptions
    {
        public GotoOffsetRelative Relative;
        public long ByteIndex;
    }
}
