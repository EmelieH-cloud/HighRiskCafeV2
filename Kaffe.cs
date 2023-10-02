namespace HighRiskCafeV2
{
    internal class Kaffe
    {
        public string CoffeeType { get; set; }
        public bool IsDone { get; set; }
        public List<string> FailedStep { get; set; }

        public Kaffe(string c, bool status, List<string> fails)
        {
            CoffeeType = c;
            IsDone = status;
            FailedStep = fails;
        }



    }
}
