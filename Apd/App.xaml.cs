using Apd.Views;

namespace Apd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

            protected override void OnStart()
        {
            base.OnStart();
            CheckUserStatus();
        }

        private void CheckUserStatus()
        {
            bool isFirstTime = Preferences.Get(StorageKeys.IsFirstTimeKey, true);
            bool legalPrivacyAccept = Preferences.Get(StorageKeys.LegalAndPrivacyAccept, true);
            bool initialQuestionsAnswered = Preferences.Get(StorageKeys.InitialQuestionsAnsweredKey, false);
            bool initialQuestionsApiAnsw = Preferences.Get(StorageKeys.InitialQuestionsApiAnsw, false);
            if (isFirstTime)
            {
                Preferences.Set(StorageKeys.LegalAndPrivacyAccept, false);
                Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, false);
                Preferences.Set(StorageKeys.InitialQuestionsApiAnsw, false);
                // Navegar a la página de bienvenida o registro
                MainPage = new NavigationPage(new LegalAndPrivacyNotice());
                
            }
            if(!legalPrivacyAccept)
            {
                MainPage = new NavigationPage(new LegalAndPrivacyNotice());
            }
            if (!initialQuestionsAnswered && !isFirstTime && initialQuestionsApiAnsw)
            {
                MainPage = new NavigationPage(new TalkAboutYou());
            }
            else if(!initialQuestionsAnswered && !isFirstTime && !initialQuestionsApiAnsw)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            if(initialQuestionsAnswered && !isFirstTime)
            {
                // Navegar a la página principal de la app
                MainPage = new NavigationPage(new MainPage());
            }
        }

    }
}

