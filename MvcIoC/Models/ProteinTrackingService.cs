namespace MvcIoC.Models
{
    public class ProteinTrackingService
    {
        public int Total { get; set; }

        public int Goal { get; set; }

        public void AddProtein(int amount)
        {
            Total += amount;
        }
    }
}