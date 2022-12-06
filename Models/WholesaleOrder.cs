using System.ComponentModel.DataAnnotations;

namespace Kundur_Meghna_HW2.Models
{
    public class WholesaleOrder : Order
    {
        //WholeSale Order Properties
        [Display(Name = "Customer Code:")]
        public string CustomerCode { get; set; }


        [Display(Name = "Delivery Fee:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0, 250, ErrorMessage = "Processing Error. Delivery Fee must be between $0 and $250.")]
        public Decimal DeliveryFee { get; set; }

        [Display(Name = "Preferred Customer:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public bool PreferredCustomer { get; set; }

        //WholeSale Order Methods
        public void CalcTotals()
        {
            
            CalcSubtotals();

            //Set the Delivery fee Property
            if (PreferredCustomer)
            {
                DeliveryFee = 0;
            }
            else if (Subtotal > 1200)
            {
                DeliveryFee = 0;
            }
            Total = Subtotal + DeliveryFee;
        }
    }
}
