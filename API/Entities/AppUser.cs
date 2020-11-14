namespace API.Entities
{
    public class AppUser
    {
        
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        //Salting is the act of adding a series of random 
        //characters to a password before going through the hashing function
        //Example:
        // Salt value: E1F53135E559C253
        //String to be hashed: password123E1F53135E559C253
        // Hashed value = SHA256(Password + Salt value)
    }
}