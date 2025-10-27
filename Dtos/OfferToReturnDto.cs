namespace akaratak_app.Dtos
{
    public class OfferToReturnDto
    {
        public float Sale { get; set; }

        public float Rent { get; set; }

        public float Invest { get; set; }

        public bool Swap { get; set; }
        
        public CurrencyToReturnDto Currency { get; set; }
    }
}