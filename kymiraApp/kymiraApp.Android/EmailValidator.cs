namespace kymiraApp.Droid
{
    public class EmailValidator : ValidatableObject
    {
        public string error { get; set; }
        public bool isValid { get; set; }

        public string email;

        public EmailValidator(string email)
        {
            this.email = email;

        }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}