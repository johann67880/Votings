using Votings.UI.Interfaces;
using Votings.UI.Resources;
using Xamarin.Forms;

namespace Votings.UI.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept => Resource.Accept;
        public static string Error => Resource.Error;
        public static string EmailError => Resource.EmailError;
        public static string PasswordError => Resource.PasswordError;
        public static string LoginError => Resource.LoginError;
        public static string Login => Resource.Login;
        public static string Email => Resource.Email;
        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;
        public static string Password => Resource.Password;
        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;
        public static string Remember => Resource.Remember;
        public static string RegisterNewUser => Resource.RegisterNewUser;
        public static string Forgot => Resource.Forgot;
        public static string EventNotStarted => Resource.EventNotStarted;
        public static string EventFinished => Resource.EventFinished;
        public static string Confirmation => Resource.Confirmation;
        public static object EventConfirmation => Resource.EventConfirmation;
        public static string Cancel => Resource.Cancel;
        public static string VoteRegistered => Resource.VoteRegistered;
        public static string Logout => Resource.Logout;
        public static string Setup => Resource.Setup;
        public static string ModifyUser => Resource.ModifyUser;
        public static string About => Resource.About;
        public static string CurrentPasswordError => Resource.CurrentPasswordError;
        public static string IncorrectPassword => Resource.IncorrectPassword;
        public static string NewPasswordError => Resource.NewPasswordError;
        public static string PasswordLengthError => Resource.PasswordLengthError;
        public static string ConfirmPasswordError => Resource.ConfirmPasswordError;
        public static string PasswordNotMatch => Resource.PasswordNotMatch;
        public static string Ok => Resource.Ok;
        public static string FirstNameError => Resource.FirstNameError;
        public static string LastNameError => Resource.LastNameError;
        public static string CountryError => Resource.CountryError;
        public static string CityError => Resource.CityError;
        public static string OccupationError => Resource.OccupationError;
        public static string PhoneNumberError => Resource.PhoneNumberError;
        public static string UpdatedUser => Resource.UpdatedUser;
        public static string ValidEmailError => Resource.ValidEmailError;
        public static string ChangePassword => Resource.ChangePassword;
        public static string CurrentPasswordLabel => Resource.CurrentPasswordLabel;
        public static string CurrentPasswordPlaceHolder => Resource.CurrentPasswordPlaceHolder;
        public static string NewPasswordLabel => Resource.NewPasswordLabel;
        public static string NewPasswordPlaceHolder => Resource.NewPasswordPlaceHolder;
        public static string ConfirmPasswordLabel => Resource.ConfirmPasswordLabel;
        public static string ConfirmPasswordPlaceHolder => Resource.ConfirmPasswordPlaceHolder;
        public static string MenuTitle => Resource.MenuTitle;
        public static string Welcome => Resource.Welcome;
        public static string ProfileTitle => Resource.ProfileTitle;
        public static string FirstNameLabel => Resource.FirstNameLabel;
        public static string FirstNamePlaceHolder => Resource.FirstNamePlaceHolder;
        public static string LastNameLabel => Resource.LastNameLabel;
        public static string LastNamePlaceHolder => Resource.LastNamePlaceHolder;
        public static string CountryLabel => Resource.CountryLabel;
        public static string CountryPlaceHolder => Resource.CountryPlaceHolder;
        public static string CityLabel => Resource.CityLabel;
        public static string CityPlaceHolder => Resource.CityPlaceHolder;
        public static string AddressLabel => Resource.AddressLabel;
        public static string AddressPlaceHolder => Resource.AddressPlaceHolder;
        public static string PhoneNumberLabel => Resource.PhoneNumberLabel;
        public static string PhoneNumberPlaceHolder => Resource.PhoneNumberPlaceHolder;
        public static string Save => Resource.Save;
        public static string ModifyPassword => Resource.ModifyPassword;
        public static string RegisterUser => Resource.RegisterUser;
        public static string OccupationLabel => Resource.OccupationLabel;
        public static string OccupationPlaceHolder => Resource.OccupationPlaceHolder;
        public static string Stratum => Resource.Stratum;
        public static string Gender => Resource.Gender;
        public static string ConfirmPassword => Resource.ConfirmPassword;
        public static string RecoverPassword => Resource.RecoverPassword;
        public static string RecoverEmailDescription => Resource.RecoverEmailDescription;
        public static string VoteMadeTitle => Resource.VoteMadeTitle;
        public static string Start => Resource.Start;
        public static string Finish => Resource.Finish;
        public static string VotingEvents => Resource.VotingEvents;
        public static string BirthDate => Resource.BirthDate;
        public static string Female => Resource.Female;
        public static string Male => Resource.Male;
    }
}
