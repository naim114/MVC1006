using System.ComponentModel.DataAnnotations;

namespace MVC1006.Models
{
    public class PosLajuParcel
    {
        // Sender
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string SenderAddress { get; set; }
        [Required]
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }

        // Receiver
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }
        [Required]
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }

        // Parcel
        [Required]
        public int IndexWeight { get; set; }
        [Required]
        public int IndexZone { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Amount
        {
            get
            {
                return rates[IndexWeight, IndexZone];
            }
        }

        public IDictionary<int, string> DictWeight
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "< 0.50 kg" },
                    {1,"< 0.75kg" },
                    {2,"< 1.00kg" },
                    {3,"< 1.25kg" },
                    {4,"< 1.50kg" },
                    {5,"< 1.75kg" },
                    {6,"< 2.00kg" },
                    {7,"< 2.50kg" },
                    {8,"< 3.50kg" }
                };
            }
        }

        public IDictionary<int, string> DictZone
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    { 0, "West Malaysia" },
                    { 1, "Sabah" },
                    { 2, "Sarawak" },
                };
            }
        }

        static double[,] rates =
        {
            { 6, 8.5, 9},
            { 7, 10.5, 12},
            { 8.5, 12.5, 14.5},
            { 10, 14.5, 17.0},
            { 11, 16.5, 20.0},
            { 12, 18.5, 22.5},
            { 14, 20.5, 25.0},
            { 21, 34.5, 41.0},
            { 24, 39.0, 46.0},
        };
    }
}
