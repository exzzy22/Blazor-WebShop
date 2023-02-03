namespace Repository.Contracts;

public interface IReviewRepository
{
    void Create(Review review);
	PagedList<Review> GetReviews(ReviewParameters reviewParameters);
}
