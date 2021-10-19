namespace Snake.Structures
{
    public static class DisplayTable
    {
        public static DisplayField BoardTopBorder => new('═',System.ConsoleColor.White);
        public static DisplayField BoardBottomBorder => new('═',System.ConsoleColor.White);
        public static DisplayField BoardSideBorder => new('║',System.ConsoleColor.White);
        public static DisplayField BoardLeftTopCorner => new('╔',System.ConsoleColor.White);
        public static DisplayField BoardLeftBottomCorner => new('╚',System.ConsoleColor.White);
        public static DisplayField BoardRightTopCorner => new('╗',System.ConsoleColor.White);
        public static DisplayField BoardRightBottomCorner => new('╝',System.ConsoleColor.White);
        public static DisplayField Empty => new(' ',System.ConsoleColor.White);

        public static DisplayField SnakeBody => new('o',System.ConsoleColor.Green);
        public static DisplayField SnakeHeadUp => new('^',System.ConsoleColor.Green);
        public static DisplayField SnakeHeadDown => new('v',System.ConsoleColor.Green);
        public static DisplayField SnakeHeadRight => new('>',System.ConsoleColor.Green);
        public static DisplayField SnakeHeadLeft => new('<',System.ConsoleColor.Green);
        public static DisplayField Fruit => new('x',System.ConsoleColor.Red); 
    }
    public class DisplayField
    {
        public char CharToPrint { get; set; }
        public System.ConsoleColor Color { get; set; }
        public DisplayField(char charToPrint, System.ConsoleColor color)
        {
            CharToPrint = charToPrint;
            Color = color;
        }
    }
}
