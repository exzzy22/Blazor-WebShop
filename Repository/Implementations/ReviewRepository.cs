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

		PagedList<Review> pagedList = PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);

		ReviewMetaData metaData = new(pagedList.MetaData)
		{
			OneStarCount = reviews.Count(r => r.StarRating == 1),
			TwoStarCount = reviews.Count(r => r.StarRating == 2),
			ThreeStarCount = reviews.Count(r => r.StarRating == 3),
			FourStarCount = reviews.Count(r => r.StarRating == 4),
			FiveStarCount = reviews.Count(r => r.StarRating == 5)
		};

		pagedList.MetaData = metaData;

		return pagedList;
	}
}
