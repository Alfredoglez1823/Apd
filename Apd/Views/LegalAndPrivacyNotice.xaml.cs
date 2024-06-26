namespace Apd.Views;

public partial class LegalAndPrivacyNotice : ContentPage
{
	public LegalAndPrivacyNotice()
	{
		InitializeComponent();
	}

    private async void AcceptButtonClicked(object sender, EventArgs e)
    {
        Preferences.Set(StorageKeys.LegalAndPrivacyAccept, true);
        await Navigation.PushAsync(new WelcomePage());
        Navigation.RemovePage(this);
    }
}