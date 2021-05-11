namespace beGreen.Model.Request
{
    public class RecyclingBankRequest
    {
        public string Coordinate { get; set; }
        public int Radius { get; set; }

        public RecyclingBankRequest() { }

        public RecyclingBankRequest(string coordinate, int radius)
        {
            Coordinate = coordinate;
            Radius = radius;
        }
    }
}
