namespace Apd.Views;

public partial class ConsentQuestions : ContentPage
{
	public ConsentQuestions()
	{
		InitializeComponent();
	}


	private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Verifica si hay una página anterior en la pila de navegación
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync(); // Regresa a la vista anterior
        }
    }
}