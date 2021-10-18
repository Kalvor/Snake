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
        public static char Fruit => 'X'; 
    }
}
