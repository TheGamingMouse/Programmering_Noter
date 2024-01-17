namespace CLassLib
{
    public class TestClass
    {
        //Adds properties to the class

        public int Id {  get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double InStock { get; set; }

        public TestClass()          //What is a Default Constructor?
        {
            Id = 0;                 //A Default Constructor is a constructor that defines the default.
            Title = "Test";         //That means that if a property is left blank, the default will be used instead
            Year = 1990;
            InStock = 1500;
        }
        
        public void Validate()
        {
            ValidateId();           //Must be a number aboce 0
            ValidateTitle();        //Must be between 3 and 10 characters, and cannot be null
            ValidateYear();         //Must be between 1990 and 2020
            ValidateInStock();      //Can't be negative
        }
        public void ValidateNoId()
        {
            //Bliver brugt til at undgå valideringsfejl ved TestClassRepository.Update

            ValidateTitle();
            ValidateYear();
            ValidateInStock();
        }

        public void ValidateId()
        {
            //Must be a number aboce 0
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("ValidateId-Error: Id must be above 0");
            }
        }
        public void ValidateTitle()
        {
            //Must be between 3 and 10 characters, and cannot be null
            if (Title == null)
            {
                throw new ArgumentNullException("ValidateTitle-Error: Title can't be null");
            }

            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("ValidateTitle-Error: Title must be at least 3 characters long");
            }
        }
        public void ValidateYear()
        {
            //Must be between 1990 and 2020
            if (Year < 1990)
            {
                throw new ArgumentOutOfRangeException("ValidateYear-Error: Year cannot be less than 1990");
            }
            if (Year > 2020)
            {
                throw new ArgumentOutOfRangeException("ValidateYear-Error: Year cannot be more than 2020");
            }
        }
        public void ValidateInStock()
        {
            //Can't be negative
            if (InStock < 0)
            {
                throw new ArgumentOutOfRangeException("ValidateInStock-Error: InStock cannot be negative");
            }
        }

        public override string ToString()
        {
            //TooString override.

            return $"{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Year)}={Year.ToString()}, {nameof(InStock)}={InStock.ToString()}";
        }
    }
}