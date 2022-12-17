namespace Repository.Contracts;

public interface IImageRepository
{
    Task<List<Image>> GetAllImages(bool trackchanges);
}
