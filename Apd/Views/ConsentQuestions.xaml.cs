namespace Apd.Views;

public partial class ConsentQuestions : ContentPage
{
	public ConsentQuestions()
	{
		InitializeComponent();
	}


	private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Verifica si hay una p�gina anterior en la pila de navegaci�n
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync(); // Regresa a la vista anterior
        }
    }
}