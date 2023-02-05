namespace Repository.Contracts;

public interface INewsletterRepository
{
	Task<Newsletter?> Get(string email);
	void Create(Newsletter newsletter);
}
