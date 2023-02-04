using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository.Implementations;

internal sealed class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    private readonly RepositoryContext _repositoryContext;

    public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext) => _repositoryContext = repositoryContext;

	public int GetProductAvgRating(int productId)
	{
		var reviews = _repositoryContext.Reviews.Where(r => r.ProductId == productId);

		if(reviews.Count() == 0)
			return 0;

		double averageRating = reviews.Sum(r => r.StarRating) / reviews.Count();

		return (int)Math.Round(averageRating);
	}

	public PagedList<Review> GetReviews(ReviewParameters reviewParameters)
	{
		var reviews = _repositoryContext.Reviews
			.Where(r => r.ProductId == reviewParameters.ProductId)
			.OrderByDescending(r => r.CreatedDate);

		PagedList<Review> pagedList = PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);

		ReviewMetaData metaData = new(pagedList.MetaData)
		{
			OneStarCount = reviews.Count(r => r.StarRating == 1),
			TwoStarCount = reviews.Count(r => r.StarRating == 2),
			ThreeStarCount = reviews.Count(r => r.StarRating == 3),
			FourStarCount = reviews.Count(r => r.StarRating == 4),
			FiveStarCount = reviews.Count(r => r.StarRating == 5),
			TotalRating = reviews.Sum(r => r.StarRating)
		};

		pagedList.MetaData = metaData;

		return pagedList;
	}
}
