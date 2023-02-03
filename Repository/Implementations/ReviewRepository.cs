using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository.Implementations;

internal sealed class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    private readonly RepositoryContext _repositoryContext;

    public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public PagedList<Review> GetReviews(ReviewParameters reviewParameters)
	{
		var reviews = _repositoryContext.Products.Include(p => p.Reviews)
			.Where(p => p.Id == reviewParameters.ProductId)
			.SelectMany(p => p.Reviews);

		return PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);
	}
}
