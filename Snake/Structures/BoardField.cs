using System;

namespace Snake.Structures
{
    public sealed class BoardField
    {
        public Func<char> GetChar { get; set; }
        public bool NeedsRefreshing { get; set; }
        private bool _IsLocked;
        public BoardField(char charToPrint, bool isLocked)
        {
            this.SetCharFunc(charToPrint);
            _IsLocked = isLocked;
        }
        public void SetCharFunc(char charToPrint)
        {
            if(!_IsLocked)
            {
                GetChar = () => charToPrint;
                NeedsRefreshing = true;
            }
        }
    }
}
