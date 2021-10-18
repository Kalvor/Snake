namespace Snake.Structures
{
    public static class DisplayTable
    {
        public static char BoardTopBorder => (char)205;
        public static char BoardBottomBorder => (char)205;
        public static char BoardSideBorder => (char)186;
        public static char BoardLeftTopCorner => (char)201;
        public static char BoardLeftBottomCorner => (char)200;
        public static char BoardRightTopCorner => (char)187;
        public static char BoardRightBottomCorner => (char)188;
        public static char Empty => ' ';

        public static char SnakeBody => 'O';
        public static char Fruit => 'X'; 
    }
}
