using System.Collections.Generic;

namespace Snake.Structures
{
    public sealed class Board
    {
        private int _Width { get; init; }
        private int _Height { get; init; }
        public Dictionary<Point, BoardField> Fields { get; init; }
        public Board(int width, int height)
        {
            _Width = width;
            _Height = height;
            Fields = new Dictionary<Point, BoardField>();
            for(int i = 0;i< height; i++)
            {
                for(int j=0;j<width;j++)
                { 
                    Fields.Add(new(j,i), new BoardField(getFieldToPrint(j, i)));
                }
            }
        }

        private DisplayField getFieldToPrint(int currentWidth,int currentHeight)
        {
            if (currentHeight == 0 && currentWidth == 0)                    return DisplayTable.Fields.BoardLeftTopCorner;
            if (currentHeight == _Height - 1 && currentWidth == 0)          return DisplayTable.Fields.BoardLeftBottomCorner;
            if (currentHeight == 0 && currentWidth == _Width - 1)           return DisplayTable.Fields.BoardRightTopCorner;
            if (currentHeight == _Height - 1 && currentWidth == _Width - 1) return DisplayTable.Fields.BoardRightBottomCorner;
            if (currentHeight == 0)                                         return DisplayTable.Fields.BoardTopBorder;
            if (currentHeight == _Height -1)                                return DisplayTable.Fields.BoardTopBorder;
            if (currentWidth == 0 || currentWidth == _Width-1)              return DisplayTable.Fields.BoardSideBorder;
            return DisplayTable.Fields.Empty;
        }
    }

    public sealed class BoardField
    {
        public DisplayField Field { get; private set; }
        public bool NeedsRefreshing { get; set; }
        public BoardField(DisplayField field)
        {
            this.SetField(field);
        }

        public void SetField(DisplayField field)
        {
            Field = field;
            NeedsRefreshing = true;
        }
    }
}
