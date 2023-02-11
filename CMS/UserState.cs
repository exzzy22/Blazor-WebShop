using Blazored.LocalStorage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CMS;

public class UserState : INotifyPropertyChanged
{
    private AdminVM? _user;
    private readonly IApiService _apiService;
    private readonly ILocalStorageService _localStorageService;

    public UserState(IApiService apiService, ILocalStorageService localStorageService)
    {
        _apiService = apiService;
        _localStorageService = localStorageService;
    }

    public AdminVM? User
    {
        get
        {
            return _user;
        }

        set
        {
            if (value != _user)
            {
                _user = value;
                NotifyPropertyChanged();
            }
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
