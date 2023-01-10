using FlightManagement.Authentication;
using FlightManagement.Base.Authentication;
using FlightManagement.Base.ViewModels.Authorization;

namespace FlightManagement.ViewModelsFactories.Crew
{
    public class AuthWindowViewModelFactory
    {
        public static AuthWindowViewModel Create(AccountDataProvider accountDataProvider)
        {
            return new AuthWindowViewModel
            {
                LoginCommand = new LoginCommand(accountDataProvider)
            };
        }
    }
}
