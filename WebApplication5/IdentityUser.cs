using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }

    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; } 
    public string City { get; set; }
    public string PostalCode { get; set; }
}
