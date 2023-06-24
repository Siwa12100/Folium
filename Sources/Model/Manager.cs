using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model.stub;
using System.Diagnostics.Metrics;

namespace Model
{
    /// <summary>
    /// Cette classe est le coeur de l'application. C'est elle qui gère les différents projets de Folium, les 
    /// informations de l'utilisateur et les paramètres de l'application. 
    /// C'est cette classe qui fait l'intermédiaire entre la vue et le modèle 
    /// </summary>
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public ReadOnlyObservableCollection<Projet> Projets { get; set; }

        // Cet attribut permet gérer les données. A l'aide d'une injection de dépendance au niveau du constructeur,
        // Le IDataManager est soit un stubManager, soit un xmlSerialiser. 
        private readonly IDataManager IDataManager;


        // Liste finale des projets de l'application. Ce sont les projets finaux chargés au niveau de la vue 
        private List<Projet> lProjets;
        public List<Projet> LProjets
        {
            get { return lProjets; }
            set { lProjets = value; 
            OnPropertyChanged(nameof(lProjets));}
        }

        // Cette classe contient les informations de l'utilisateur de l'application 
        private  Utilisateur user;
        public Utilisateur User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
                OnPropertyChanged(nameof(user));
            }
        }

        // Cette classe contient les informations relatives aux paramètres de l'application 
        private Application app;
        public Application App
        {
            get => app;
            set
            {
                app = value;
                OnPropertyChanged(nameof(app));
            }
        }

        // Cet attribut permet de stocker les projets dans un conteneur qui notifie le fait qu'il y ait eu des 
        // modifications au niveau des projets pour ensuite afficher la bonne version au niveau de la vue 
        public ReadOnlyObservableCollection<Projet> ProjetsVisibles { get; set; }
        private readonly ObservableCollection<Projet> lProjetsObservables;

        /// <summary>
        ///Cette fonction est appelée à chaque fois qu'un projet est modifié. Il enregistre tous les projets 
        //puis les recharge instanémement pour ainsi les sauvegarder et les mettre à jour
        /// </summary>

        private void rechargementProjets()
        {
            this.IDataManager.EnregistrementProjets(this.lProjets);
            this.lProjets = this.IDataManager.ChargementProjets();
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un projet à la liste des projets 
        /// </summary>
        /// <param name="projet"></param>
        public void ajouterProjet(Projet projet)
        {
            int verif = 0; // utilisé pour trouver un identifiant non utilisé 
            int cpt = 1; // utilisé pour trouver un identifiant non utilisé 

            do
            { // On parcours la liste des projets 
                verif = 0;
                foreach (Projet p in this.lProjets)
                {
                    if (cpt == p.Identifiant)
                    {
                        // Tant que le compteur est égal à un identifiant de projet 
                        // On l'incrémente et on met verif à 1 pour dire qu'il faut continuer 
                        verif = 1;
                        cpt = cpt + 1;
                        break;
                    }
                }
            } while (verif != 0); // On continue t'as qu'un numéro disponible pour mettre en identifiant n'est pas disponible 

            projet.Identifiant = cpt;
            lProjets.Add(projet);

            // On met à jour les projets
            rechargementProjets();
        }

        /// <summary>
        /// Cette fonction permet de supprimer un projet de la liste 
        /// </summary>
        /// <param name="projet"></param>
        public void supprimerProjet(Projet projet)
        {
            // On parcours la liste des projets 
            foreach(Projet p in lProjets)
            {
                // Si un projet correspond à celui passé en paramètre 
                if (p.Identifiant == projet.Identifiant)
                {
                    // On le supprime 
                    lProjets.Remove(p);
                    // On actualise la liste des projets 
                    rechargementProjets();
                }
            }
        }

        /// <summary>
        /// Cette fonction permet de modifier un projet déjà existant 
        /// </summary>
        /// <param name="projet"></param>
        public void modifierProjet(Projet projet)
        {
            // On parcours la liste des projets 
            foreach(Projet p in lProjets)
            {
                // Si le projet est trouvé 
                if (p.Identifiant == projet.Identifiant)
                {
                    // On met le projet passé en paramètre à l'emplacement du projet initial dans la liste de projets 
                    lProjets[lProjets.IndexOf(p)] = projet;
                    rechargementProjets();
                }
            }
        }

        /// <summary>
        /// Permet de modifier un bloc spécifique d'un projet 
        /// </summary>
        /// <param name="idProjet"></param>
        /// <param name="b"></param>
        public void modifierBloc(int idProjet, Bloc b)
        {
            // On parcours la liste des projets 
            foreach(Projet p in lProjets)
            {
                // Si on trouve le projet 
                if (idProjet == p.Identifiant)
                {
                    // On appelle la méthode pour modifier un bloc et on passe le bloc
                    // a modifier en paramètre 
                    p.modifierBloc(b);
                    // On met à jour les projets 
                    rechargementProjets();
                }
            }
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un bloc à un projet 
        /// </summary>
        /// <param name="idProjet"></param>
        /// <param name="b"></param>
        public void ajouterBloc(int idProjet, Bloc b)
        {
            // On parcours la liste des projets 
            foreach(Projet p in lProjets)
            {
                // si on trouve le projet 
                if (p.Identifiant == idProjet)
                {
                    // On ajoute le bloc au projet 
                    p.ajouterBloc(b);
                }
            }
        }

        /// <summary>
        /// Cette fonction est utilisée pour supprimer un bloc à un projet 
        /// </summary>
        /// <param name="idProjet"></param>
        /// <param name="b"></param>
        public void supprimerBloc(int idProjet, Bloc b)
        {
            // On parcours la liste des projets 
            foreach(Projet p in lProjets)
            {
                // Si le projet est trouvé 
                if (p.Identifiant == idProjet)
                {
                    // On supprime le bloc 
                    p.supprimerBloc(b);
                }
            }
        }

        /// <summary>
        /// Cette fonction permet de recharger les informations des paramètres de 
        /// l'application s'ils ont été modifiés 
        /// </summary>
        private void rechargementApplication()
        {
            // On enregistre les paramètres de l'application 
            IDataManager.EnregistrementApplication(app);
            // On recharge les paramètres 
            app = IDataManager.ChargementApplication();
        }

        /// <summary>
        /// Cette fonction permet de changer le thème Clair / Sombre de l'application 
        /// </summary>
        public void changerTheme()
        {
            // Si le thème est clair, il passe au sombre et inversement 
            if (app.Mode == Mode.Clair)
            {
                app.Mode = Mode.Sombre;
            }
            else
            {
                app.Mode = Mode.Clair;
            }
            // et on recharge les paramètres de l'application 
            rechargementApplication();
        }

        /// <summary>
        /// Cette fonction permet de modifier le logo de l'application 
        /// </summary>
        /// <param name="logo"></param>
        public void setLogoApplication(string logo)
        {
            this.app.Logo = logo;
            rechargementApplication();
        }

        /// <summary>
        /// Cette fonction permet de recharger les informations de l'utilisateur si elles ont 
        /// été modifiées 
        /// </summary>
        private void rechargementUtilisateur()
        {
            // On enregistre les informations de l'utilisateur 
            IDataManager.EnregistrementUtilisateur(user);
            // On charge de nouveau les informations de l'utilisateur 
            user = IDataManager.ChargementUtilisateur();    
        }

        /// <summary>
        /// Cette fonction permet de modofier un utilisateur 
        /// </summary>
        /// <param name="u"></param>
        public void modifierUtilisateur(Utilisateur u)
        {
            // L'utilisateur actuel devient l'utilisateur passé en paramètre 
            user = u;
            // Les informations de l'utilisateur actuel sont rechargées 
            rechargementUtilisateur();
        }

        /// <summary>
        /// Permet d'ajouter un réseau à un utilisateur 
        /// </summary>
        /// <param name="nvr"></param>
        public void ajouterReseau(Reseau nvr)
        {
            // On utilise la fonction pour ajouter un réseau de la classe utilisateur 
            user.ajouterReseau(nvr.Lien, nvr.Type);
            // On recharge les informations sur l'utilisateur 
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction est utilisée pour modifier un réseau de l'utilisateur 
        /// </summary>
        /// <param name="r"></param>
        public void modifierReseau(Reseau r)
        {
            user.modifierReseau(r);
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction est utilisée pour supprimer un réseau de l'utilisateur 
        /// </summary>
        /// <param name="r"></param>
        public void supprimerReseau(Reseau r)
        {
            user.supprimerReseau(r);
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un parcours à un utilisateur 
        /// </summary>
        /// <param name="p"></param>
        public void ajouterParcours(Parcours p)
        {
            user.ajouterParcours(p);
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction permet de supprimer le parcours d'un utilisateur 
        /// </summary>
        /// <param name="p"></param>
        public void modifierParcours(Parcours p)
        {
            user.modifierParcours(p);
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction permet de supprimer le parcours d'un utilisateur 
        /// </summary>
        /// <param name="p"></param>
        public void supprimerParcours(Parcours p)
        {
            user.supprimerParcours(p);
            rechargementUtilisateur();
        }

        /// <summary>
        /// Cette fonction permet de supprimer tous les projets présents dans la liste des projets du manager 
        /// </summary>
        public void resetProjets()
        {
            // Attention fonction très dangereuse ! 
            // En l'appelant, tous les projets de l'application sont supprimés pour toujours ! 

            lProjets.RemoveAll(p => true);
            rechargementApplication();
        }

        /// <summary>
        /// Permet de renvoyer l'attribut application du manager 
        /// </summary>
        /// <returns></returns>
        public Application getApp()
        {
            return app;
        }

        /// <summary>
        /// Permet de renvoyer l'utilisateur actif 
        /// </summary>
        /// <returns></returns>
        public Utilisateur getUser()
        {
            return user;
        }

        /// <summary>
        /// Permet de renvoyer tous les projets du manager 
        /// </summary>
        /// <returns></returns>
        public List<Projet> getProjets()
        {
            return lProjets;
        }

        /// <summary>
        /// Permet de renvoyer un seul projet en fonction de son identifiant 
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        public Projet getProjet(int idProjet)
        {
            foreach(Projet p in lProjets)
            {
                if(idProjet == p.Identifiant) return p;
            }
            return null;
        }

        public Manager(IDataManager ChoixDataManager)
        {
            // Injection de dépendance 
            this.IDataManager = ChoixDataManager;

            // On charge tous les projets 
            LProjets = IDataManager.ChargementProjets();

            lProjetsObservables = new ObservableCollection<Projet>(lProjets);
            ProjetsVisibles = new ReadOnlyObservableCollection<Projet>(lProjetsObservables);            

            app = IDataManager.ChargementApplication();
            //if (app == null )
            //{
            //    app = new Application();
            //    app.Mode = Mode.Clair;
            //    app.Logo = "logoapp.png";
            //}

            user = IDataManager.ChargementUtilisateur();
            //if (user == null )
            //{
            //    stubManager stub = new stubManager();
            //    user = stub.getUtilisateurs().ToList()[0];
            //}
        }
    }
}
