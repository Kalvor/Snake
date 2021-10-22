﻿using System;

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

        public static DisplayText HeaderText_1 => DisplayText.AtCenter("Snake Game", ConsoleColor.DarkGreen, ConsoleColor.Black, 1);
        public static DisplayText HeaderText_2 => DisplayText.AtCenter("By Krzysztof Jadczak", ConsoleColor.DarkGreen, ConsoleColor.Black,2);
        public static DisplayText SelectDifficultyInfo => DisplayText.AtCenter("Please select Difficulty...", ConsoleColor.DarkGreen, ConsoleColor.Black,4);

        public static DisplayText DifficultyEasy => DisplayText.AtCenter("EASY", ConsoleColor.Green, ConsoleColor.DarkGray,6);
        public static DisplayText DifficultyMedium => DisplayText.AtCenter("MEDIUM", ConsoleColor.Yellow, ConsoleColor.DarkGray, 7);
        public static DisplayText DifficultyHard => DisplayText.AtCenter("HARD", ConsoleColor.Red, ConsoleColor.DarkGray, 8);

    }

    public record DisplayText
    {
        public string StringToPrint { get; set; }
        public ConsoleColor Color { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public Point Location { get; set; }

        public static DisplayText New(string stringToPrint, ConsoleColor color, ConsoleColor backgroundColor, Point location)
        {
            return new DisplayText(stringToPrint, color, backgroundColor, location);
        }
        public static DisplayText AtCenter(string stringToPrint, ConsoleColor color, ConsoleColor backgroundColor,int yCord)
        {
            return new DisplayText(stringToPrint, color, backgroundColor, new((Console.WindowWidth - stringToPrint.Length) / 2, yCord));
        }

        private DisplayText(string stringToPrint, ConsoleColor color, ConsoleColor backgroundColor, Point location)
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
