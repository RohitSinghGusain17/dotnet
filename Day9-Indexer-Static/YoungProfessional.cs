    public class YoungProfessional
    {
        public YoungProfessional()
        {
            
        }
        public YoungProfessional(string dob)
        {
            DateOfBirth = dob;
        }
        public int PersonalId { get; private set; }
        public int RNo { get; set; }
        public string? DateOfBirth { get; private set; }

        public string? Name { get; set; }
        

        public void SetDateOfBirth(string dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
}