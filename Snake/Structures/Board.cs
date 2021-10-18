using System.Collections.Generic;

namespace Snake.Structures
{
    public sealed class Board
    {
        private int _Width { get; init; }
        private int _Height { get; init; }
        private Dictionary<(int,int),BoardField> Data { get; set; }
        public Board(int width, int height)
        {
            _Width = width;
            _Height = height;
            Data = new Dictionary<(int,int),BoardField>();
            for(int i = 0;i< height; i++)
            {
                for(int j=0;j<width;j++)
                { 
                    Data.Add((j,i), new BoardField(GetCharToPrint(j, i), true));
                }
            }
        }

        private char GetCharToPrint(int currentWidth,int currentHeight)
        {
            if (currentHeight == 0 && currentWidth == 0)                    return DisplayTable.BoardLeftTopCorner;
            if (currentHeight == _Height - 1 && currentWidth == 0)          return DisplayTable.BoardLeftBottomCorner;
            if (currentHeight == 0 && currentWidth == _Width - 1)           return DisplayTable.BoardLeftBottomCorner;
            if (currentHeight == _Height - 1 && currentWidth == _Width - 1) return DisplayTable.BoardRightBottomCorner;

            return DisplayTable.Empty;
        }
    }
}
