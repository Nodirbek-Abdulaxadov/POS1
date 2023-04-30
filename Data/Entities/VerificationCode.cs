namespace DataLayer.Entities;

public class VerificationCode : BaseEntity
{
    public int Code { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string IPAdress { get; set; } = string.Empty;
    public DateTime ExpireDate { get; set; }
}