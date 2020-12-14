namespace NeiroNetTest
{
    public struct Connection
    {
        public int MatrixX => _matrixX;

        public int MatrixY => _matrixY;

        private int _matrixX;
        private int _matrixY;

        public Connection(int matrixX, int matrixY)
        {
            _matrixX = matrixX;
            _matrixY = matrixY;
        }
    }
}