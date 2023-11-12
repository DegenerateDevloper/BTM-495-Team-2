public class TactGearzClerk : User
{
	public string tact_gearz_clerk_email { get; set; }
	public string tact_gearz_clerk_password { get; set; }

	public TactGearzClerk(string email, string pw)
    {
		this.tact_gearz_clerk_email = email;
		this.tact_gearz_clerk_password = pw;
    }
}