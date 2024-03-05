namespace BeerLibary
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public override string ToString() =>
            $"{Id} {Name} {Abv}";

        public void ValidateName()
        {
            if (Name == null) 
            { 
                throw new ArgumentNullException("Navn må ikke være null");
            }
            if (Name.Count() < 3)
            {
                throw new ArgumentOutOfRangeException("Navn skal være over 3 bogstaver");
            }
        }

        public void ValidateAbv()
        {
            if (Abv <= 0) 
            {
                throw new ArgumentOutOfRangeException("Abv værdi skal være over 0");
            }
            if (Abv > 67)
            {
                throw new ArgumentOutOfRangeException("Abv værdi skal være under 67");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAbv();
        }
    }
}