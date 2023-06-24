using Model;

namespace folium_maui;

public partial class PageProjetPolyvalent : ContentPage
{
	public PageProjetPolyvalent(Projet p)
	{
		InitializeComponent();
		Projet projetTemporaire = p;
		//projetTemporaire.initialisationProjetPolyvalent();

		BindingContext = projetTemporaire;
	}

    private async void retourAccueil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}