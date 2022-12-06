using System.ComponentModel.DataAnnotations;

namespace Kundur_Meghna_HW2.Models
{
    //Enum Property
    public enum CustomerType { Direct, Wholesale }
    public class Order
    {
        //Establishing Constants for Book Prices (Separated by Hard and Paper Back)
        public const Decimal HARDBACK_PRICE = 17.95m;
        public const Decimal PAPERBACK_PRICE = 9.50m;

        //Order Properties
        [Display(Name = "Customer Type:")]
        [Required(ErrorMessage = "Please Select A Customer Type")]
        public CustomerType CustomerType { get; set; }

        [Display(Name = "Number of Hardbacks:")]
        public Int32 NumberOfHardbacks { get; set; }


        [Display(Name = "Number of Paperbacks:")]
        public Int32 NumberOfPaperbacks { get; set; }


        [Display(Name = "Hardback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal HardbackSubtotal { get; set; }


        [Display(Name = "Paperback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal PaperbackSubtotal { get; set; }


        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get; set; }


        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get; set; }


        [Display(Name = "Total Items:")]
        public Int32 TotalItems { get; set; }


        //Order Methods
        public void CalcSubtotals()
        {
            //Calculating Order Subtotals
            TotalItems = NumberOfHardbacks + NumberOfPaperbacks;

            //If the number of total items is zero, throw user an exception
            if (TotalItems == 0)
            {
                throw new Exception("Processing Error. Customer must order at least one item.");
            }
            HardbackSubtotal = NumberOfHardbacks * HARDBACK_PRICE;
            PaperbackSubtotal = NumberOfPaperbacks * PAPERBACK_PRICE;
            Subtotal = HardbackSubtotal + PaperbackSubtotal;
        }
    }
}
