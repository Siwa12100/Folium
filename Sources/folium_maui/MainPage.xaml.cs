using Model;
using Model.serializer;
using Windows.Devices.AllJoyn;
using Windows.System;

namespace folium_maui;

public partial class MainPage : ContentPage
{
	Manager mgr;

	public MainPage()
	{
		InitializeComponent();
		mgr = new Manager(new xmlSerialiser(Directory.GetCurrentDirectory()));
		mgr.App.Logo = "logoapp.png";
		BindingContext = mgr;

		foreach(Projet p in mgr.LProjets)
		{

			p.BoutonCommande = new Command<Projet>(chargementPageprojet);
		}


		foreach(Reseau r in mgr.User.LReseaux)
		{
			r.BoutonCommande = new Command<Reseau>(chargerReseau);
		}
	}

	private async void chargerReseau(Reseau r)
	{
		await Microsoft.Maui.ApplicationModel.Launcher.TryOpenAsync(r.Lien);
	}

    private async void chargerPageProfil(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profil());
    }

    private async void chargementPageprojet(Projet projet)
	{

		switch (projet.Type)
		{
			case typeProjet.Textuel:
				await Navigation.PushAsync(new PageProjetTextuel(projet));
				break;

			case typeProjet.Graphique:
				await Navigation.PushAsync(new PageProjetGraphique(projet));
				break;

			case typeProjet.Polyvalent:
				await Navigation.PushAsync(new PageProjetPolyvalent(projet));
				break;
		}

	}

	private void creationProjetTextuel(object sender, EventArgs e)
	{
		Projet p = new Projet(1, typeProjet.Textuel);
		p.initialisationProjetTextuel();
		mgr.ajouterProjet(p);
	}

	

    //  private async void ChangementPage(object sender, EventArgs e)
    //  {
    //await Navigation.PushAsync(new PageProjetGraphique());
    //  }
}

