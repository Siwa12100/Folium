// See https://aka.ms/new-console-template for more information

using Model;
using Model.stub;
using Model.serializer;

using System.Runtime.CompilerServices;

Console.WriteLine("========================");
Console.WriteLine("Début du test console :");
Console.WriteLine("========================");
Console.WriteLine();

// Commentaire pour faire un push et tester le build & les tests

void affichage_projet(Projet p)
{
   int i = 1;
   Console.WriteLine();
   Console.WriteLine(" -> Nom du projet : " + p.Nom);
   Console.WriteLine("- - - - - - - - - - ");
   Console.WriteLine("      -> Identifiant du projet : " + p.Identifiant);
   Console.WriteLine("      -> Image principale du projet : " + p.Image_principale);
   Console.WriteLine("      -> Description du projet : " + p.Description);
   Console.WriteLine();

   foreach( Bloc b in p.LBlocs)
   {
       Console.WriteLine("      ----- Bloc " + i + " ----- ");
       Console.WriteLine("      - Nom du bloc : " + b.ToString());
       Console.WriteLine();
       i = i + 1;
   }
   Console.WriteLine();
}

void affichage_utilisateur(Utilisateur u)
{
   Console.WriteLine("================================================");
   Console.WriteLine("   Utilisateur :   " +  u.Nom + " " + u.Prenom);
   Console.WriteLine("================================================");

   Console.WriteLine(" --> Biographie : " + u.Biographie);
   Console.WriteLine(" --> A Propos : " + u.APropos);
   Console.WriteLine(" --> Image de profil : " + u.ImageProfil);
   Console.WriteLine(" --> Bannière de profil : " + u.BanniereProfil);

    Console.WriteLine();
    Console.WriteLine(" Affichage des réseaux de : " + u.Nom + " " + u.Prenom);
    Console.WriteLine(" - - - - - - - - - - - - -");
    foreach(Reseau r in u.LReseaux)
    {
        Console.WriteLine(r);
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(" Affichage des parcours de : " + u.Nom + " " + u.Prenom);
    Console.WriteLine("- - - - - - - - - - - - - - ");
    foreach(Parcours p in u.LParcours)
    {
        Console.WriteLine(p);
        Console.WriteLine();
    }
    Console.WriteLine();

   //Console.WriteLine();
   //Console.WriteLine(" Liste des différents projets de l'utilisateur : ");
   //Console.WriteLine(" -----------------------------------------------");
   Console.WriteLine();

   //foreach (Projet p in u.LProjets)
   //{
   //    //Console.WriteLine("Passage par ici...");
   //    affichage_projet(p);
   //}
}

void testModifierParcours()
{
    Utilisateur u = new Utilisateur();
    Parcours p1 = new Parcours();
    u.ajouterParcours(p1);

    affichage_utilisateur(u);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    Parcours p2 = u.LParcours[0];
    p2.Titre = "Test de modification du titre";
    u.modifierParcours(p2);
    affichage_utilisateur(u);
}

void testSerialisationProjets()
{
    stubManager stubManager = new stubManager();
    xmlSerialiser xmlSerialiser = new xmlSerialiser(Directory.GetCurrentDirectory());

    List<BlocTextuel> ListeBlocsTextuels = stubManager.getBlocstextuels().ToList();
    List<Projet> ListeProjets1 = stubManager.GetAllProjets().ToList();

    BlocTextuel nvBlocTextuel = new BlocTextuel();
    nvBlocTextuel.Titre = "Mi pichoun pais";
    nvBlocTextuel.Texte = "tèxte en la lengua occitana";
    ListeProjets1[2].ajouterBloc(nvBlocTextuel);


    xmlSerialiser.EnregistrementBlocsTextuels(ListeBlocsTextuels);
    xmlSerialiser.EnregistrementProjets(ListeProjets1);

    List<Projet> ListeProjets2 = xmlSerialiser.ChargementProjets();

    int cpt = 0;
    foreach (Projet p in ListeProjets2)
    {
        cpt = cpt + 1;
        Console.WriteLine("Projet affiché dans le program.cs (" + cpt + ")");
        Console.WriteLine(p);
        Console.WriteLine();
        Console.WriteLine();
    }
}

void testSerialisationUtilisateur()
{
    stubManager stubManager = new stubManager();
    xmlSerialiser xmlSerialiser = new xmlSerialiser(Directory.GetCurrentDirectory());

    Utilisateur u1 = stubManager.getUtilisateurs().ToList()[0];
    Console.WriteLine(" ---> Affichage initialement de u1 : ");
    Console.WriteLine();
    affichage_utilisateur(u1);

    xmlSerialiser.EnregistrementUtilisateur(u1);

    Utilisateur u2 = xmlSerialiser.ChargementUtilisateur();
    Console.WriteLine(" ---> Affichage de u2 qui vient d'être chargé : ");
    Console.WriteLine();
    affichage_utilisateur(u2);
    Console.WriteLine();
}

void testSerialisationApplication()
{
    stubManager stubManager = new stubManager();
    xmlSerialiser xmlSerialiser = new xmlSerialiser(Directory.GetCurrentDirectory());

    Application app = new Application();
    app.Mode = Mode.Clair;
    app.Logo = " Test de texte pour le chemin vers le logo de l'application";

    Console.WriteLine(" ---> Affichage une première fois de app : ");
    Console.WriteLine(app);

    xmlSerialiser.EnregistrementApplication(app);

    Application nvapp = xmlSerialiser.ChargementApplication();
    Console.WriteLine();
    Console.WriteLine(" ---> Affichage de nvapp une fois le chargement effectué : ");
    Console.WriteLine(nvapp);
    Console.WriteLine();
}

void testManagerProjets()
{
    Manager manager = new Manager(new xmlSerialiser(Directory.GetCurrentDirectory()));
    stubManager stubManager = new stubManager();
    manager.resetProjets();

    //Console.WriteLine(" ---> Affichage de tous les projets juste après le resetProjets");
    //foreach(Projet p in manager.getProjets())
    //{
    //    affichage_projet(p);
    //}
    //Console.WriteLine();

    Projet p1 = stubManager.GetAllProjets().ToList()[0];
    manager.ajouterProjet(p1);

    //Console.WriteLine(" ---> Affichage de tous les projets juste après l'ajout de p1 ");
    //foreach (Projet p in manager.getProjets())
    //{
    //    affichage_projet(p);
    //}
    //Console.WriteLine();

    BlocPolyvalent b1 = stubManager.getBlocsPolyvalents().ToList()[1];
    manager.ajouterBloc(manager.getProjets()[0].Identifiant, b1);

    //Console.WriteLine(" ---> Affichage de tous les projets juste après l'ajout d'un quatrième bloc ");
    //foreach(Projet p in manager.getProjets())
    //{
    //    affichage_projet(p);
    //}
    //Console.WriteLine();

    b1.Titre = "CECI EST LE TEST DE LA MODIFICATION DE BLOC DEPUIS LE MANAGER ( titre )";
    b1.Texte = "CECI EST TOUJOURS LE TEST ( texte )";
    manager.modifierBloc(manager.getProjets()[0].Identifiant, b1);

    //Console.WriteLine(" ---> Affichage de tous les projets juste après modif qui bloc 4  ");
    //foreach (Projet p in manager.getProjets())
    //{
    //    affichage_projet(p);
    //}
    //Console.WriteLine();

    Projet p2 = manager.getProjets()[0];
    Bloc b2 = new Bloc();
    b2.Identifiant = 2;
    manager.supprimerBloc(p2.Identifiant, b2);

    Projet p3 = stubManager.GetAllProjets().ToList()[2];
    manager.ajouterProjet(p3);

    Console.WriteLine(" ---> Liste des projets après suppression du b. à l'ID 2 et ajout d'un nv projet ");
    foreach (Projet p in manager.getProjets())
    {
        affichage_projet(p);
    }
    Console.WriteLine();
}

void testManagerAppEtUser()
{
    Manager mgr = new Manager(new xmlSerialiser(Directory.GetCurrentDirectory()));
    stubManager stubManager = new stubManager();

    Console.WriteLine(" ---> Affichage initial user & app : ");
    Console.WriteLine();
    affichage_utilisateur(mgr.getUser());
    Console.WriteLine();
    Console.WriteLine(mgr.getApp());
    Console.WriteLine();
    Console.WriteLine(" ---> Reaffichage de l'app après changement de mode :");
    mgr.changerTheme();
    Console.WriteLine(mgr.getApp());
    Console.WriteLine();
}


void visionnageProjets()
{
    Manager mgr = new Manager(new xmlSerialiser(Directory.GetCurrentDirectory()));

    Projet p1 = new Projet(6, typeProjet.Polyvalent);
    p1.initialisationProjetPolyvalent();
    affichage_projet(p1);
}


void visionnageManager()
{
    Manager mgr = new Manager(new xmlSerialiser(Directory.GetCurrentDirectory()));

    //foreach(Projet p in mgr.LProjets)
    //{
    //    Console.WriteLine();
    //    affichage_projet(p);
    //}

    affichage_utilisateur(mgr.User);
}
void application_console_jean()
{
    //testSerialisationProjets();
    //testSerialisationUtilisateur();
    //testSerialisationApplication();
    //testManagerProjets();
    //testManagerAppEtUser();
    //testModifierParcours();
    //visionnageProjets();
    visionnageManager();

}

application_console_jean();


