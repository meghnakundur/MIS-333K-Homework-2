using System.ComponentModel.DataAnnotations;

namespace Kundur_Meghna_HW2.Models
{
    public class DirectOrder : Order
    {
        //Establishing Named Tax Rate Constant
        public const Decimal SALES_TAX_RATE = .0825m;

        //Direct Order Properties
        [Display(Name = "Customer Name:")]
        public string? CustomerName { get; set; }


        [Display(Name = "Sales Tax:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; set; }

        //Direct Order Methods
        public void CalcTotals()
        {

            CalcSubtotals();

            //Calculating the Sales Tax using the constant set previously and the Direct Order Total
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = Subtotal + SalesTax;
        }
    }
}
