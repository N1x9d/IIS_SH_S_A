namespace NeiroNetTest
{
    class NeironInputs
    {
        private Connection _connection;

        public Connection Connection
        {
            get => _connection;
        }

        public decimal Weight
        {
            get => _weight;
            set => _weight = value;
        }

        private decimal _weight;

        public NeironInputs(Connection connection)
        {
            _connection = connection;
            _weight = 0.1m;
        }
    }
}