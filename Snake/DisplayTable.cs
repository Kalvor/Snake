using System;

namespace Snake.Structures
{
    public static class DisplayTable
    {
        public static DisplayField BoardTopBorder => new('═',ConsoleColor.White);
        public static DisplayField BoardBottomBorder => new('═',ConsoleColor.White);
        public static DisplayField BoardSideBorder => new('║',ConsoleColor.White);
        public static DisplayField BoardLeftTopCorner => new('╔',ConsoleColor.White);
        public static DisplayField BoardLeftBottomCorner => new('╚',ConsoleColor.White);
        public static DisplayField BoardRightTopCorner => new('╗',ConsoleColor.White);
        public static DisplayField BoardRightBottomCorner => new('╝',ConsoleColor.White);
        public static DisplayField Empty => new(' ',ConsoleColor.White);

        public static DisplayField SnakeBody => new('o',ConsoleColor.Green);
        public static DisplayField SnakeHeadUp => new('^',ConsoleColor.Green);
        public static DisplayField SnakeHeadDown => new('v',ConsoleColor.Green);
        public static DisplayField SnakeHeadRight => new('>',ConsoleColor.Green);
        public static DisplayField SnakeHeadLeft => new('<',ConsoleColor.Green);
        public static DisplayField Fruit => new('x',ConsoleColor.Red);

        public static DisplayText HeaderText_1 => new("Snake Game", ConsoleColor.DarkRed, ConsoleColor.Black, new(0,1));
        public static DisplayText HeaderText_2 => new("By KrzysztofJadczak", ConsoleColor.DarkRed, ConsoleColor.Black,new(0,2));
        public static DisplayText SelectDifficultyInfo => new("Please select Difficulty...", ConsoleColor.DarkRed, ConsoleColor.Black,new(0,4));
    }

    public record DisplayText
    {
        public string StringToPrint { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public Point Location { get; set; }
        public DisplayText(string stringToPrint, ConsoleColor color, ConsoleColor backgroundColor, Point location)
        {
            StringToPrint = stringToPrint;
            Color = color;
            BackgroundColor = backgroundColor;
            Location = location;
        }
    }

    public record DisplayField
    {
        public char CharToPrint { get; set; }
        public ConsoleColor Color { get; set; }
        public DisplayField(char charToPrint, ConsoleColor color)
        {
            CharToPrint = charToPrint;
            Color = color;
        }
    }
}
