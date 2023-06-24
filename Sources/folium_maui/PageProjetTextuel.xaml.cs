using Model;

namespace folium_maui;

public partial class PageProjetTextuel : ContentPage
{

	public PageProjetTextuel(Projet p)
	{
		InitializeComponent();
		Projet projetTemporaire = p;
		//projetTemporaire.initialisationProjetTextuel();

		BindingContext = projetTemporaire;
	}


    private async void retourAccueil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}

