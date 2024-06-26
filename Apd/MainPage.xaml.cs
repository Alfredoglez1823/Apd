using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Apd.Models;
using Apd.Views;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace Apd
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            // Llama al método de limpieza (comentar/descomentar según sea necesario)
            //ResetApp();

            CheckUserStatus();

        }

        private async void CheckUserStatus()
        {
            try
            {
                bool isFirstTime = Preferences.Get(StorageKeys.IsFirstTimeKey, true);
                string accessToken = await SecureStorage.GetAsync("access_token");

                if (isFirstTime || string.IsNullOrEmpty(accessToken))
                {
                    await Navigation.PushAsync(new WelcomePage());
                    return;
                }

                // Check if the initial questions have been answered
                //Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, false);
                bool initialQuestionsAnswered = Preferences.Get(StorageKeys.InitialQuestionsAnsweredKey, false);
                
                if (!initialQuestionsAnswered)
                {
                    QuestionnaireMessage.IsVisible = true;
                    AnswerQuestionnaireButton.IsVisible = true;
                    var userIdString = await SecureStorage.GetAsync("user_id");
                    bool apiAnswered = Preferences.Get(StorageKeys.InitialQuestionsApiAnsw, false);
                    if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId) && !apiAnswered)
                    {
                        var hasResponded = await CheckIfUserHasRespondedAsync(userId, accessToken);
                        if (hasResponded)
                        {
                            Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, true);
                            await CheckIfWeekPassed();
                            QuestionnaireMessage.IsVisible = false;
                            AnswerQuestionnaireButton.IsVisible = false;
                        }
                        else
                        {
                            Preferences.Set(StorageKeys.InitialQuestionsApiAnsw, true);
                            // En la pantalla anterior a TalkAboutYou
                            await Navigation.PushModalAsync(new TalkAboutYou());
                            NavigationPage.SetHasNavigationBar(this, false);
                            return;
                        }
                    }
                    else if(apiAnswered)
                    {
                        await Navigation.PushModalAsync(new TalkAboutYou());
                        NavigationPage.SetHasNavigationBar(this, false);
                        return;
                    }
                }
                else
                {
                    await CheckIfWeekPassed();
                    QuestionnaireMessage.IsVisible = false;
                    AnswerQuestionnaireButton.IsVisible = false;
                }
                    

                // Navigate to the actual main page of your app
                await Navigation.PushAsync(new Lobby()); // Replace with the actual main page of your app
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
        }

        private async Task<bool> CheckIfUserHasRespondedAsync(int userId, string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.GetAsync($"https://apdwebapi.somee.com/api/DepresionTest/ByUser/{userId}");
                var response2 = await _httpClient.GetAsync($"https://apdwebapi.somee.com/api/AnsiedadTest/ByUser/{userId}");

                if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    var content2 = await response2.Content.ReadAsStringAsync();

                    DepresionTest hasResponded = JsonConvert.DeserializeObject<DepresionTest>(content);
                    AnsiedadTest hasResponded2 = JsonConvert.DeserializeObject<AnsiedadTest>(content2);

                    var depresionTestJson = JsonConvert.SerializeObject(hasResponded);
                    var ansiedadTestJson = JsonConvert.SerializeObject(hasResponded2);

                    await SecureStorage.SetAsync("depresionTestData", depresionTestJson);
                    await SecureStorage.SetAsync("ansiedadTestData", ansiedadTestJson);

                    int? PuDe = hasResponded.PuntuacionDepresion == null ? 100 : hasResponded.PuntuacionDepresion;
                    int? PuAn = hasResponded2.PuntuacionAnsiedad == null ? 100 : hasResponded2.PuntuacionAnsiedad;

                    await SecureStorage.SetAsync("depresionScoreData", PuDe.ToString());
                    await SecureStorage.SetAsync("ansiedadScoreData", PuDe.ToString());
                    

                    await SecureStorage.SetAsync("habitosDelSueñoData", hasResponded.CambiosEnLosHabitosDeSueño.ToString());
                    await SecureStorage.SetAsync("cambiosEnApetitoData", hasResponded.CambiosEnElApetito.ToString());

                    await SecureStorage.SetAsync("last_test_date", hasResponded.Fecha.ToString("o"));


                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                await DisplayAlert("Error", "An error occurred while checking responses: " + ex.Message, "OK");
            }

            return false;
        }

        private void ResetApp()
        {
            // Borrar todas las preferencias
            Preferences.Clear();

            // Borrar todas las claves del almacenamiento seguro
            SecureStorage.RemoveAll();
        }
        private async Task CheckIfWeekPassed()
        {
            var lastTestDateStr = await SecureStorage.GetAsync("last_test_date");
            if (!string.IsNullOrEmpty(lastTestDateStr) && DateTime.TryParse(lastTestDateStr, out DateTime lastTestDate))
            {
                if ((DateTime.UtcNow - lastTestDate).TotalDays >= 7)
                {
                    // Ha pasado una semana desde el último cuestionario
                    Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, false);
                    await Application.Current.MainPage.DisplayAlert("Nuevo Cuestionario", "Ha pasado una semana desde tu último cuestionario. Por favor, completa uno nuevo.", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                // No hay una fecha guardada o la fecha no es válida
            }
        }


        private async void OnAnswerQuestionnaireButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TalkAboutYou());
        }
    }

    public static class StorageKeys
    {
        public const string IsFirstTimeKey = "IsFirstTime";
        public const string LegalAndPrivacyAccept = "LegalAndPrivaceAccept";
        public const string InitialQuestionsAnsweredKey = "InitialQuestionsAnswered";
        public const string InitialQuestionsApiAnsw = "InitialQuestionsApiAnsw";
    }
}
