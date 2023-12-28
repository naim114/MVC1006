using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC1006.Models
{
    public class PosLajuParcel
    {
        // Sender
        [Required]
        [Display(Name = "Sender Name")]
        public string SenderName { get; set; }
        [Required]
        [Display(Name = "Sender Address")]
        public string SenderAddress { get; set; }
        [Required]
        [Display(Name = "Sender Phone")]
        public string SenderPhone { get; set; }
        [Display(Name = "Sender Email")]
        public string SenderEmail { get; set; }

        // Receiver
        [Required]
        [Display(Name = "Receiver Name")]
        public string ReceiverName { get; set; }
        [Required]
        [Display(Name = "Receiver Address")]
        public string ReceiverAddress { get; set; }
        [Required]
        [Display(Name = "Receiver Phone")]
        public string ReceiverPhone { get; set; }
        [Display(Name = "Receiver Email")]
        public string ReceiverEmail { get; set; }

        // Parcel
        [Required]
        [Display(Name = "Weight")]
        public int IndexWeight { get; set; }
        [Required]
        [Display(Name = "Zone")]
        public int IndexZone { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        [Display(Name = "Amount")]
        public double Amount
        {
            get
            {
                return rates[IndexWeight, IndexZone];
            }

            set { }
        }

        [Display(Name = "Weight")]
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

        [Display(Name = "Zone")]
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

        [Display(Name = "Date & Time")]
        public DateTime ParcelDateTime
        {
            get
            {
                return DateTime.Now;
            }

            set { }
        }

        [Display(Name = "View Date & Time")]
        public DateTime ViewDateTime { get; set; }


        [Display(Name = "Parcel Id")]
        public string ParcelId
        {
            get
            {
                string hexTicks = DateTime.Now.Ticks.ToString("X");

                return hexTicks.Substring(hexTicks.Length - 15, 9);
            }

            set { }
        }

        [Display(Name = "View Id")]
        public string ViewId { get; set; }
    }
}
