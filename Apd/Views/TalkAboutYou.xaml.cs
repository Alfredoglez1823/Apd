using Apd.LogicApp;
using Apd.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace Apd.Views;

public partial class TalkAboutYou : ContentPage
{
	public TalkAboutYou()
	{
		InitializeComponent();
	}

    private async void ConsentLabel_Tapped(object sender, EventArgs e)
    {
        // Crea una nueva instancia de la vista ConsentQuestions
        var consentQuestionsPage = new ConsentQuestions();

        // Navega a la vista ConsentQuestions
        await Navigation.PushAsync(consentQuestionsPage);
    }

    private void ConsentChange(object sender, CheckedChangedEventArgs e)
    {
        if(ConsentCheckBox.IsChecked)
        {

        }
    }
    // Event handlers to toggle visibility of additional questions based on checkbox selection
    private void OnDiagnosedYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (DiagnosedYesCheckBox.IsChecked)
        {
            DiagnosedNoCheckBox.IsChecked = false;
            DiagnosisQuestionLabel.IsVisible = true;
            DiagnosisEntry.IsVisible = true;
        }
        else
        {
            DiagnosedYesCheckBox.IsChecked = false;
            DiagnosisQuestionLabel.IsVisible = false;
            DiagnosisEntry.IsVisible = false;
        }
    }
    private void OnDiagnosedNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (DiagnosedNoCheckBox.IsChecked)
        { 
            DiagnosedYesCheckBox.IsChecked = false;
            DiagnosisQuestionLabel.IsVisible = false;
            DiagnosisEntry.IsVisible = false;
        }
    }

    private void OnTreatmentYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (TreatmentYesCheckBox.IsChecked)
        {
            TreatmentNoCheckBox.IsChecked = false;
            TreatmentQuestionLabel.IsVisible = true;
            TreatmentEntry.IsVisible = true;
        }
        else
        {
            TreatmentYesCheckBox.IsChecked = false;
            TreatmentQuestionLabel.IsVisible = false;
            TreatmentEntry.IsVisible = false;
        }
    }
    private void OnTreatmentNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (TreatmentNoCheckBox.IsChecked)
        { 
            TreatmentYesCheckBox.IsChecked = false;
            TreatmentQuestionLabel.IsVisible = false;
            TreatmentEntry.IsVisible = false;
        }
    }


    private void OnCurrentMedicationYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (CurrentMedicationYesCheckBox.IsChecked)
        {
            CurrentMedicationNoCheckBox.IsChecked = false;
            CurrentMedicationDescriptionLabel.IsVisible = true;
            CurrentMedicationDescriptionEntry.IsVisible = true;
        }
        else
        {
            CurrentMedicationYesCheckBox.IsChecked = false;
            CurrentMedicationDescriptionLabel.IsVisible = false;
            CurrentMedicationDescriptionEntry.IsVisible = false;
        }
    }

    private void OnCurrentMedicationNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (CurrentMedicationNoCheckBox.IsChecked)
        {
            CurrentMedicationYesCheckBox.IsChecked = false;
            CurrentMedicationDescriptionLabel.IsVisible = false;
            CurrentMedicationDescriptionEntry.IsVisible = false;
        }
    }

    private void OnSubstanceUseYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (SubstanceUseYesCheckBox.IsChecked)
        {
            SubstanceUseNoCheckBox.IsChecked = false;
            SubstanceUseFrequencyLabel.IsVisible = true;
            SubstanceUseFrequencyEntry.IsVisible = true;

            SubstanceUseTypeLabel.IsVisible = true;
            SubstanceUseTypeEntry.IsVisible = true;
        }
        else
        {
            SubstanceUseYesCheckBox.IsChecked = false;
            SubstanceUseFrequencyLabel.IsVisible = false;
            SubstanceUseFrequencyEntry.IsVisible = false;

            SubstanceUseTypeLabel.IsVisible = false;
            SubstanceUseTypeEntry.IsVisible = false;
        }
    }

    private void OnSubstanceUseNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (SubstanceUseNoCheckBox.IsChecked)
        {
            SubstanceUseYesCheckBox.IsChecked = false;
            SubstanceUseFrequencyLabel.IsVisible = false;
            SubstanceUseFrequencyEntry.IsVisible = false;

            SubstanceUseTypeLabel.IsVisible = false;
            SubstanceUseTypeEntry.IsVisible = false;
        }
    }

    private void OnTrustedFriendsFamilyYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (TrustedFriendsFamilyYesCheckBox.IsChecked)
        {
            TrustedFriendsFamilyNoCheckBox.IsChecked = false;
            ComfortableTalkingProblemsLabel.IsVisible = true;
            ComfortableTalkingProblemsEntry.IsVisible = true;
        }
        else
        {
            TrustedFriendsFamilyYesCheckBox.IsChecked = false;
            ComfortableTalkingProblemsLabel.IsVisible = false;
            ComfortableTalkingProblemsEntry.IsVisible = false;
        }
    }

    private void OnTrustedFriendsFamilyNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (TrustedFriendsFamilyNoCheckBox.IsChecked)
        {
            TrustedFriendsFamilyYesCheckBox.IsChecked = false;
            ComfortableTalkingProblemsLabel.IsVisible = false;
            ComfortableTalkingProblemsEntry.IsVisible = false;
        }
    }

    private void OnUsedMentalHealthResourcesYesCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (UsedMentalHealthResourcesYesCheckBox.IsChecked)
        {
            TrustedFriendsFamilyNoCheckBox.IsChecked = false;
            UsedMentalHealthResourcesNoCheckBox.IsChecked = false;

            HelpfulMentalHealthResourcesLabel.IsVisible = true;
            HelpfulMentalHealthResourcesEntry.IsVisible = true;

            WillingToSeekHelpAgainLabel.IsVisible = true;
            WillingToSeekHelpAgainEntry.IsVisible = true;

            BarriersToSeekingHelpLabel.IsVisible = false;
            BarriersToSeekingHelpEntry.IsVisible = false;
        }
        else
        {
            UsedMentalHealthResourcesYesCheckBox.IsChecked = false;
            HelpfulMentalHealthResourcesLabel.IsVisible = false;
            HelpfulMentalHealthResourcesEntry.IsVisible = false;

            WillingToSeekHelpAgainLabel.IsVisible = false;
            WillingToSeekHelpAgainEntry.IsVisible = false;
        }
    }

    private void OnUsedMentalHealthResourcesNoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (UsedMentalHealthResourcesNoCheckBox.IsChecked )
        {
            UsedMentalHealthResourcesYesCheckBox.IsChecked = false;
            HelpfulMentalHealthResourcesLabel.IsVisible = false;
            HelpfulMentalHealthResourcesEntry.IsVisible = false;

            WillingToSeekHelpAgainLabel.IsVisible = false;
            WillingToSeekHelpAgainEntry.IsVisible = false;

            BarriersToSeekingHelpLabel.IsVisible = true;
            BarriersToSeekingHelpEntry.IsVisible = true;
        }
        else
        {
            BarriersToSeekingHelpLabel.IsVisible = false;
            BarriersToSeekingHelpEntry.IsVisible = false;
        }
    }

    private void ConfortableYesChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ComfortableTalkingProblemsYCh.IsChecked)
            ComfortableTalkingProblemsNCh.IsChecked = false;
    }
    private void ConfortableNoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ComfortableTalkingProblemsNCh.IsChecked)
            ComfortableTalkingProblemsYCh.IsChecked = false;
    }

    private void ComfortableTalkingYesChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ComfortableTalkingEmotionsYesCheckBox.IsChecked)
            ComfortableTalkingEmotionsNoCheckBox.IsChecked = false;
    }
    private void ComfortableTalkingNoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ComfortableTalkingEmotionsNoCheckBox.IsChecked)
            ComfortableTalkingEmotionsYesCheckBox.IsChecked = false;
    }

    private void ReceivingYesChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ReceivingProfessionalHelpYesCheckBox.IsChecked)
            ReceivingProfessionalHelpNoCheckBox.IsChecked = false;
    }
    private void ReceivingNoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ReceivingProfessionalHelpNoCheckBox.IsChecked)
            ReceivingProfessionalHelpYesCheckBox.IsChecked = false;
    }

    private void HelpfulYesChanged(object sender, CheckedChangedEventArgs e)
    {
        if (HelpfulMentalHealthResourcesYCh.IsChecked)
            HelpfulMentalHealthResourcesNCh.IsChecked = false;
    }
    private void HelpfulNoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (HelpfulMentalHealthResourcesNCh.IsChecked)
            HelpfulMentalHealthResourcesYCh.IsChecked = false;
    }

    private void WillingYesChanged(object sender, CheckedChangedEventArgs e)
    {
        if (WillingToSeekHelpAgainYCh.IsChecked)
            WillingToSeekHelpAgainNCh.IsChecked = false;
    }
    private void WillingNoChanged(object sender, CheckedChangedEventArgs e)
    {
        if (WillingToSeekHelpAgainNCh.IsChecked)
            WillingToSeekHelpAgainYCh.IsChecked = false;
    }
    //
    private void NoChangesInSleepChange(object sender, CheckedChangedEventArgs e)
    {
        if (NoChangesInSleepCheckBox.IsChecked)
        {
                SleepLessThanUsualCheckBox.IsChecked = false;
                SleepMoreThanUsualCheckBox.IsChecked = false;
                SleepMuchMoreThanUsualCheckBox.IsChecked = false;
                SleepMuchLessThanUsualCheckBox.IsChecked = false;
                SleepMostOfTheDayCheckBox.IsChecked = false;
                WakeUpEarlyCheckBox.IsChecked = false;
        }
        
    }
    private void SleepMoreThanUsualChange(object sender, CheckedChangedEventArgs e)
    {
        if (SleepMoreThanUsualCheckBox.IsChecked)
        {
                SleepLessThanUsualCheckBox.IsChecked = false;
                NoChangesInSleepCheckBox.IsChecked = false;
                SleepMuchMoreThanUsualCheckBox.IsChecked = false;
                SleepMuchLessThanUsualCheckBox.IsChecked = false;
                SleepMostOfTheDayCheckBox.IsChecked = false;
                WakeUpEarlyCheckBox.IsChecked = false;
        }
            
    }
    private void SleepLessThanUsualChange(object sender, CheckedChangedEventArgs e)
    {
        if (SleepLessThanUsualCheckBox.IsChecked)
        {
                SleepMoreThanUsualCheckBox.IsChecked = false;
                NoChangesInSleepCheckBox.IsChecked = false;
                SleepMuchMoreThanUsualCheckBox.IsChecked = false;
                SleepMuchLessThanUsualCheckBox.IsChecked = false;
                SleepMostOfTheDayCheckBox.IsChecked = false;
                WakeUpEarlyCheckBox.IsChecked = false;
        }
            
    }
    private void SleepMuchMoreThanUsualChange(object sender, CheckedChangedEventArgs e)
    {
        if (SleepMuchMoreThanUsualCheckBox.IsChecked)
        {
            SleepMoreThanUsualCheckBox.IsChecked = false;
            NoChangesInSleepCheckBox.IsChecked = false;
            SleepLessThanUsualCheckBox.IsChecked = false;
            SleepMuchLessThanUsualCheckBox.IsChecked = false;
            SleepMostOfTheDayCheckBox.IsChecked = false;
            WakeUpEarlyCheckBox.IsChecked = false;
        }
            
    }
    private void SleepMuchLessThanUsualChange(object sender, CheckedChangedEventArgs e)
    {
        if (SleepMuchLessThanUsualCheckBox.IsChecked)
        {
            SleepMoreThanUsualCheckBox.IsChecked = false;
            NoChangesInSleepCheckBox.IsChecked = false;
            SleepLessThanUsualCheckBox.IsChecked = false;
            SleepMuchMoreThanUsualCheckBox.IsChecked = false;
            SleepMostOfTheDayCheckBox.IsChecked = false;
            WakeUpEarlyCheckBox.IsChecked = false;
        }
            
    }
    private void SleepMostOfTheDayChange(object sender, CheckedChangedEventArgs e)
    {
        if (SleepMostOfTheDayCheckBox.IsChecked)
        {
            SleepMoreThanUsualCheckBox.IsChecked = false;
            NoChangesInSleepCheckBox.IsChecked = false;
            SleepLessThanUsualCheckBox.IsChecked = false;
            SleepMuchMoreThanUsualCheckBox.IsChecked = false;
            SleepMuchLessThanUsualCheckBox.IsChecked = false;
            WakeUpEarlyCheckBox.IsChecked = false;
        }
            
    }
    private void WakeUpEarlyChange(object sender, CheckedChangedEventArgs e)
    {
        if (WakeUpEarlyCheckBox.IsChecked)
        {
            SleepMoreThanUsualCheckBox.IsChecked = false;
            NoChangesInSleepCheckBox.IsChecked = false;
            SleepLessThanUsualCheckBox.IsChecked = false;
            SleepMuchMoreThanUsualCheckBox.IsChecked = false;
            SleepMuchLessThanUsualCheckBox.IsChecked = false;
            SleepMostOfTheDayCheckBox.IsChecked = false;
        }
            
    }
    ///////////////
    ///
    private void NoChangesInAppetiteChange(object sender, CheckedChangedEventArgs e)
    {
        if (NoChangesInAppetiteCheckBox.IsChecked)
        {
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void AppetiteSlightlyDecreasedChange(object sender, CheckedChangedEventArgs e)
    {
        if (AppetiteSlightlyDecreasedCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void AppetiteSlightlyIncreasedChange(object sender, CheckedChangedEventArgs e)
    {
        if (AppetiteSlightlyIncreasedCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void AppetiteMuchDecreasedChange(object sender, CheckedChangedEventArgs e)
    {
        if (AppetiteMuchDecreasedCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void AppetiteMuchIncreasedChange(object sender, CheckedChangedEventArgs e)
    {
        if (AppetiteMuchIncreasedCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void NoAppetiteAtAllChange(object sender, CheckedChangedEventArgs e)
    {
        if (NoAppetiteAtAllCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            WantToEatAllTheTimeCheckBox.IsChecked = false;
        }
            
    }
    private void WantToEatAllTheTimeChange(object sender, CheckedChangedEventArgs e)
    {
        if (WantToEatAllTheTimeCheckBox.IsChecked)
        {
            NoChangesInAppetiteCheckBox.IsChecked = false;
            AppetiteSlightlyDecreasedCheckBox.IsChecked = false;
            AppetiteSlightlyIncreasedCheckBox.IsChecked = false;
            AppetiteMuchDecreasedCheckBox.IsChecked = false;
            AppetiteMuchIncreasedCheckBox.IsChecked = false;
            NoAppetiteAtAllCheckBox.IsChecked = false;
        }
            
    }


    private async void OnSaveResponsesClicked(object sender, EventArgs e)
    {
        int userId = int.Parse(await SecureStorage.GetAsync("user_id"));

        var responseDT = new DepresionTest
        {
            //Id = 0, // This would be set by the database or API
            UserId = userId,

            // I. Información Personal
            Nombre = NameEntry.Text,
            Edad = (byte?)(int.TryParse(AgeEntry.Text, out int age) ? (int?)age : null),
            Fecha = DateTime.UtcNow,
            Genero = (byte?)GenderPicker.SelectedIndex,
            FueDiagnosticado = DiagnosedYesCheckBox.IsChecked,
            QueDiagnostico = DiagnosisEntry.IsVisible ? DiagnosisEntry.Text : null,
            EstaEnTratamiento = TreatmentYesCheckBox.IsChecked,
            TipoDeTratamiento = TreatmentEntry.IsVisible ? TreatmentEntry.Text : null,

            //preguntas
            Tristeza = (byte?)TristezaPicker.SelectedIndex,
            Pesimismo = (byte?)PesimismoPicker.SelectedIndex,
            Fracaso = (byte?)FracasoPicker.SelectedIndex,
            PerdidaDePlacer = (byte?)PerdidaDePlacerPicker.SelectedIndex,
            SentimientosDeCulpa = (byte?)SentimientosDeCulpaPicker.SelectedIndex,
            DisconformidadConUnoMismo = (byte?)DisconformidadConUnoMismoPicker.SelectedIndex,
            Autocritica = (byte?)AutocriticaPicker.SelectedIndex,
            PensamientosOdeseosSuicidas = (byte?)PensamientosDeseosSuicidasPicker.SelectedIndex,
            Llanto = (byte?)LlantoPicker.SelectedIndex,
            Agitacion = (byte?)AgitacionPicker.SelectedIndex,
            PerdidaDeInteres = (byte?)PerdidaDeInteresPicker.SelectedIndex,
            Indecision = (byte?)IndecisionPicker.SelectedIndex,
            Desvalorizacion = (byte?)DesvalorizacionPicker.SelectedIndex,
            PerdidaDeEnergia = (byte?)PerdidaDeEnergiaPicker.SelectedIndex,

            CambiosEnLosHabitosDeSueño = (byte?)(NoChangesInSleepCheckBox.IsChecked ? 0 : SleepMoreThanUsualCheckBox.IsChecked ? 11 
            : SleepLessThanUsualCheckBox.IsChecked ? 21 
            : SleepMuchMoreThanUsualCheckBox.IsChecked ? 12 : SleepMuchLessThanUsualCheckBox.IsChecked ? 22 
            : SleepMostOfTheDayCheckBox.IsChecked ? 13 : WakeUpEarlyCheckBox.IsChecked ? 23 : 100),

            Irritabilidad = (byte?)IrritabilidadPicker.SelectedIndex,

            CambiosEnElApetito = (byte?)(NoChangesInAppetiteCheckBox.IsChecked ? 0 : AppetiteSlightlyDecreasedCheckBox.IsChecked ? 11 
            : AppetiteSlightlyIncreasedCheckBox.IsChecked ? 21 
            : AppetiteMuchDecreasedCheckBox.IsChecked ? 12 : AppetiteMuchIncreasedCheckBox.IsChecked ? 22
            : NoAppetiteAtAllCheckBox.IsChecked ? 13 : WantToEatAllTheTimeCheckBox.IsChecked ? 23 : 100),

            DificultadDeConcentracion = (byte?)DificultadDeConcentracionPicker.SelectedIndex,
            CansancioOfatiga = (byte?)CansancioOFatigaPicker.SelectedIndex,
            PerdidaDeInteresSexual = (byte?)PerdidaDeInteresEnElDeseoPicker.SelectedIndex,


            // II. Estado de Ánimo y Emociones

            ComoTeHasSentido = EmotionalDescriptionEditor.Text,
            SituacionEventoQueAfecta = CurrentSituationEditor.Text,

            // III. Síntomas Físicos y Conductuales
            SintomasFisicos = OtherPhysicalSymptomsEntry.Text,
           

            // IV. Recursos de Apoyo
            AntecedentesDeAnFamiliares = (byte)SupportResourcesPicker.SelectedIndex,
            TomandoMedicamentosActual = CurrentMedicationYesCheckBox.IsChecked,
            QueMedicamentos = CurrentMedicationDescriptionEntry.IsVisible ? CurrentMedicationDescriptionEntry.Text : null,
            AlcoholOdrogas = SubstanceUseYesCheckBox.IsChecked,
            FrecuenciaConsumoD = SubstanceUseFrequencyEntry.IsVisible ? SubstanceUseFrequencyEntry.Text : null,
            TipoDeSustancias = SubstanceUseTypeEntry.IsVisible ? SubstanceUseTypeEntry.Text : null,
            OtrosAspectoDeSalud = OtherHealthConcernsEntry.Text,
            AmigoOfamiliarConfianza = TrustedFriendsFamilyYesCheckBox.IsChecked,
            AoFconfianzaHablar = ComfortableTalkingProblemsYCh.IsChecked,
            HablarConPersonasE = ComfortableTalkingEmotionsYesCheckBox.IsChecked,
            RecibeAyudaActualmente = ReceivingProfessionalHelpYesCheckBox.IsChecked,
            RecibioAyudaAntes = UsedMentalHealthResourcesYesCheckBox.IsChecked,
            FueUtilParaTi = HelpfulMentalHealthResourcesYCh.IsChecked,
            BuscariasAyudaDeNuevo = WillingToSeekHelpAgainYCh.IsChecked,
            QueTeDetiene = BarriersToSeekingHelpEntry.IsVisible ? BarriersToSeekingHelpEntry.Text : null,

            //hola


            //final
            ApoyoUtilAhora = HelpfulSupportTypesEditor.Text,
            PropositoUsoApp = ExpectationsEditor.Text,
            ObjetivosParaMejorar = EmotionalWellbeingGoalsEditor.Text


        };

        var responseAT = new AnsiedadTest
        {
            UserId = userId,
            Fecha = DateTime.UtcNow,
            TorpeEntumecido = GetSelectedValue(Question1),
            Acalorado = GetSelectedValue(Question2),
            TemblorPiernas = GetSelectedValue(Question3),
            IncapazRelajarse = GetSelectedValue(Question4),
            TemorOcurrirPeor = GetSelectedValue(Question5),
            Mareado = GetSelectedValue(Question6),
            LatidosFuertesAcelerados = GetSelectedValue(Question7),
            Inestable = GetSelectedValue(Question8),
            Atemorizado = GetSelectedValue(Question9),
            Nervioso = GetSelectedValue(Question10),
            SensacionBloqueo = GetSelectedValue(Question11),
            TembloresManos = GetSelectedValue(Question12),
            InquietoInseguro = GetSelectedValue(Question13),
            MiedoPerderControl = GetSelectedValue(Question14),
            SensacionAhogo = GetSelectedValue(Question15),
            TemorMorir = GetSelectedValue(Question16),
            Miedo = GetSelectedValue(Question17),
            ProblemasDigestivos = GetSelectedValue(Question18),
            Desvanecimientos = GetSelectedValue(Question19),
            RuborFacial = GetSelectedValue(Question20),
            SudoresFriosCalientes = GetSelectedValue(Question21)
        };

        int anxietyScore = TestScore.AnxietyScore(responseAT);
        int depressionScore = TestScore.DepressionScore(responseDT);

        if(anxietyScore >= 100 || depressionScore >= 100)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Debes responder todas las preguntas", "OK");
            return;
        }

        var ansiedadTestJson = JsonConvert.SerializeObject(responseAT);
        var depresionTestJson = JsonConvert.SerializeObject(responseDT);

        await SecureStorage.SetAsync("ansiedadTestData", ansiedadTestJson);
        await SecureStorage.SetAsync("depresionTestData", depresionTestJson);

        await SecureStorage.SetAsync("ansiedadScoreData", anxietyScore.ToString());
        await SecureStorage.SetAsync("depresionScoreData", depressionScore.ToString());

        await SecureStorage.SetAsync("habitosDelSueñoData", responseDT.CambiosEnLosHabitosDeSueño.ToString());
        await SecureStorage.SetAsync("cambiosEnApetitoData", responseDT.CambiosEnElApetito.ToString());

        // Guardar la fecha de la respuesta
        await SecureStorage.SetAsync("last_test_date", DateTime.UtcNow.ToString("o"));

        //var ansiedadTestRJson = await SecureStorage.GetAsync("ansiedadTestData");
        //var ansiedadTestRecovered = JsonConvert.DeserializeObject<AnsiedadTest>(ansiedadTestRJson);

        Preferences.Set(StorageKeys.InitialQuestionsAnsweredKey, true);

        if (ConsentCheckBox.IsChecked)
        {
            responseDT.PuntuacionDepresion = depressionScore;
            responseAT.PuntuacionAnsiedad = anxietyScore;

            // Convertir el objeto a JSON
            var jsonDT = JsonConvert.SerializeObject(responseDT);
            var jsonAT = JsonConvert.SerializeObject(responseAT);


            var contentDT = new StringContent(jsonDT, Encoding.UTF8, "application/json");
            var contentAT = new StringContent(jsonAT, Encoding.UTF8, "application/json");

            // Crear una instancia de HttpClient
            using (var client = new HttpClient())
            {
                string accessToken = await SecureStorage.GetAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                // Configurar la URL de la API
                var url1 = "https://apdwebapi.somee.com/api/DepresionTest";
                var url2 = "https://apdwebapi.somee.com/api/AnsiedadTest";

                // Enviar la solicitud POST
                var responseDeT = await client.PostAsync(url1, contentDT);
                var responseAnT = await client.PostAsync(url2, contentAT);

                if (responseDeT.IsSuccessStatusCode && responseAnT.IsSuccessStatusCode)
                {
                    // La solicitud fue exitosa
                    var responseDataDT = await responseDeT.Content.ReadAsStringAsync();
                    var responseDataAT = await responseAnT.Content.ReadAsStringAsync();
                    // Puedes hacer algo con responseData si lo necesitas
                    

                    // Mostrar una confirmación al usuario
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El cuestionario se ha guardado correctamente.DB", "OK");
                    await Navigation.PushAsync(new MainPage());

                }
                else
                {
                    // La solicitud falló
                    var errorDataDT = await responseDeT.Content.ReadAsStringAsync();
                    var errorDataAT = await responseAnT.Content.ReadAsStringAsync();
                    // Manejar el error
                    await Application.Current.MainPage.DisplayAlert("Error", "Hubo un problema al guardar el cuestionario en nuestra base de datos. Puedes continuar usando la app.", "OK");
                    await Navigation.PushAsync(new MainPage());

                }
            }
        
        }
        else
        {
            // Mostrar una confirmación al usuario
            await Application.Current.MainPage.DisplayAlert("Éxito", "El cuestionario se ha guardado correctamente.", "OK");
            await Navigation.PushAsync(new MainPage());

        }

        await Navigation.PushAsync(new MainPage());

    }

    // Método genérico para obtener el valor seleccionado de un grupo de RadioButton por GroupName
    private byte GetSelectedValue(Grid questionGrid)
    {
        foreach (var child in questionGrid.Children)
        {
            if (child is RadioButton radioButton && radioButton.IsChecked)
            {
                return Byte.Parse((string)radioButton.Value);
            }
        }
        return 100; // O algún valor por defecto si no hay ningún RadioButton seleccionado
    }
}