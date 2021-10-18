using System;
using System.Collections.Generic;

namespace Snake.Structures
{
    public sealed class Board
    {
        private int _Width { get; init; }
        private int _Height { get; init; }
        public Dictionary<Point, BoardField> Data { get; set; }
        public Board(int width, int height)
        {
            _Width = width;
            _Height = height;
            Data = new Dictionary<Point, BoardField>();
            for(int i = 0;i< height; i++)
            {
                for(int j=0;j<width;j++)
                { 
                    Data.Add(new(j,i), new BoardField(GetCharToPrint(j, i), true));
                }
            }
        }
        private char GetCharToPrint(int currentWidth,int currentHeight)
        {
            if (currentHeight == 0 && currentWidth == 0)                    return DisplayTable.BoardLeftTopCorner;
            if (currentHeight == _Height - 1 && currentWidth == 0)          return DisplayTable.BoardLeftBottomCorner;
            if (currentHeight == 0 && currentWidth == _Width - 1)           return DisplayTable.BoardRightTopCorner;
            if (currentHeight == _Height - 1 && currentWidth == _Width - 1) return DisplayTable.BoardRightBottomCorner;
            if (currentHeight == 0) return DisplayTable.BoardTopBorder;
            if (currentHeight == _Height -1) return DisplayTable.BoardTopBorder;
            if (currentWidth == 0 || currentWidth == _Width-1) return DisplayTable.BoardSideBorder;
            return DisplayTable.Empty;
        }
    }

    public sealed class BoardField
    {
        public char CharToPrint { 
            get
            {
                return _charToPrint;
            }
        }
        private char _charToPrint { get; set; }
        public bool NeedsRefreshing { get; set; }
        private bool _IsLocked;
        public BoardField(char charToPrint, bool isLocked)
        {
            this.SetCharFunc(charToPrint);
            _IsLocked = isLocked;
        }
        public void SetCharFunc(char charToPrint)
        {
            if (!_IsLocked)
            {
                _charToPrint = charToPrint;
                NeedsRefreshing = true;
            }
        }
    }
}
