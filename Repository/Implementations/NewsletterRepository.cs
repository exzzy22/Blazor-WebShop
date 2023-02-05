namespace Repository.Implementations;

public class NewsletterRepository : RepositoryBase<Newsletter>, INewsletterRepository
{
	private readonly RepositoryContext _repositoryContext;

	public NewsletterRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public Task<Newsletter?> Get(string email) => _repositoryContext.Newsletters.FirstOrDefaultAsync(x => x.Email == email);
}
