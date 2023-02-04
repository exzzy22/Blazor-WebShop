using Shared.DataTransferObjects;
using System.Text.Json.Serialization;

namespace Shared.RequestFeatures;

public class ReviewMetaData : MetaData
{
	public ReviewMetaData(){}
	public ReviewMetaData(MetaData metaData)
	{
		CurrentPage = metaData.CurrentPage;
		TotalPages = metaData.TotalPages;
		PageSize = metaData.PageSize;
		TotalCount = metaData.TotalCount;
	}

	public int OneStarCount { get; set; }
	public int TwoStarCount { get; set; }
	public int ThreeStarCount { get; set; }
	public int FourStarCount { get; set; }
	public int FiveStarCount { get; set; }
	public double TotalRating { get; set; }

	public double AverageStarRating()
	{
		double averageRating = TotalRating / TotalCount;
		return Math.Round(averageRating, 1);
	}

	public int StarRatingPercentage(int specificStarCount)
	{
		double percentage = (specificStarCount * 100.0) / TotalCount;
		return (int)Math.Round(percentage);
	}

}
