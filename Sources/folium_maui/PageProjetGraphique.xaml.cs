using Model;

namespace folium_maui;

public partial class PageProjetGraphique : ContentPage
{

	public PageProjetGraphique(Projet p)
	{
		InitializeComponent();
		Projet projetTemporaire = p;
		//projetTemporaire.initialisationProjetGraphique();

		BindingContext = projetTemporaire;
	}

    private async void retourAccueil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}