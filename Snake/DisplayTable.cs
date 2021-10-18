namespace Snake.Structures
{
    public static class DisplayTable
    {
        public static char BoardTopBorder => '═';
        public static char BoardBottomBorder => '═';
        public static char BoardSideBorder => '║';
        public static char BoardLeftTopCorner => '╔';
        public static char BoardLeftBottomCorner => '╚';
        public static char BoardRightTopCorner => '╗';
        public static char BoardRightBottomCorner => '╝';
        public static char Empty => ' ';

        public static char SnakeBody => 'O';
        public static char SnakeHeadUp => '^';
        public static char SnakeHeadDown => 'v';
        public static char SnakeHeadRight => '>';
        public static char SnakeHeadLeft => '<';
        public static char Fruit => 'X'; 
    }
}
