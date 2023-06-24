using System.Net;
using System.Numerics;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Input;

namespace Model
{
    /// <summary>
    /// Différents tags pour qualifier un projet 
    /// </summary>
    public enum Tag
    {
        Dessin,
        Video, 
        Photographie,
        Automobile,
        Technologie,
        Developpement,
        Systeme,
        Reseau,
        Voyage,
        Culture, 
        Art, 
        Decouverte,
        JeuxVideos

    }

    /// <summary>
    /// Différent type de projet utilisé pour savoir avec quel bloc l'initialiser 
    /// et dans quelle page XAML l'afficher 
    /// </summary>
    public enum typeProjet
    {
        Textuel,
        Graphique,
        Polyvalent
    }

    [DataContract (Name = "projet")]
    public class Projet : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Type de projet 
        private typeProjet type;
        public typeProjet Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(type));
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Permet ensuite de prendre la méthode pour changer de page qui est définie 
        // Dans la main page 
        private ICommand boutonCommande;
        public ICommand BoutonCommande { get; set; }




        [DataMember(EmitDefaultValue = false)]
        // La liste de blocs du projet 
        private List<Bloc> lBlocs;
        public List<Bloc> LBlocs
        {
            get { return lBlocs; }
            set { lBlocs = value;
                OnPropertyChanged(nameof(LBlocs));
            }
        }

        [DataMember]
        // Identifiant qui sert à retrouver le projet au sein d'une liste de projets 
        private int identifiant;
        public int Identifiant
        {
            get
            {
                return identifiant;
            }

            set { identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }

        [DataMember]
        // Nom principal du projet 
        string nom;
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    nom = "Nouveau projet";
                }
                else
                {
                    nom = value;
                }
                OnPropertyChanged(nameof(Nom));
            }
        }

        [DataMember]
        // Liste de tags du projet 
        private List<Tag> tags;
        public List<Tag> Tags
        {
            get { return tags; }
            set { tags = value;
                OnPropertyChanged(nameof(Tags));
            }
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un tag à la liste de tags du projet 
        /// </summary>
        /// <param name="t"></param>
        public void ajouterTag(Tag t)
        {
            this.tags.Add(t);
        }

        [DataMember]
        // Image principale du projet 
        private string image_principale;
        public string Image_principale
        {
            get
            {
                return image_principale;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    image_principale = "placeholderimageprojets.png";                }
                else
                {
                    image_principale = value;
                }

                OnPropertyChanged(nameof(Image_principale));
            }
        }

        [DataMember]
        // Description du projet affichée au niveau de la page principale 
        private string description;
        public string Description
        {
            get => description;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    description = " Le projet ne possède pas de description... ";
                }
                else
                {
                    description = value;
                }
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Ajoute 3 blocs textuels au projet 
        /// </summary>
        public void initialisationProjetTextuel()
        {
            for (int i = 0; i < 3; i++)
            {
                lBlocs.Add(new BlocTextuel());
            }
        }

        /// <summary>
        /// Ajoute 3 bloc graphiques au projet 
        /// </summary>
        public void initialisationProjetGraphique()
        {
            for (int i = 0; i < 3; i++)
            {
                lBlocs.Add(new BlocGraphique());
            }
        }

        /// <summary>
        /// Ajoute 3 blocs polyalents au projet 
        /// </summary>
        public void initialisationProjetPolyvalent()
        {
            for (int i = 0; i < 3; i++)
            {
                lBlocs.Add(new BlocPolyvalent());
            }
        }

        /// <summary>
        /// Ajoute un bloc quelquonque au projet en utilisant le polymorphisme 
        /// </summary>
        /// <param name="nvb"></param>
        public void ajouterBloc(Bloc nvb)
        {
            int verif = 0;
            int cpt = 1;

            do
            { // On parcours la liste de blocs 
                verif = 0;
                foreach (Bloc b in this.lBlocs)
                {
                    // Si l'identifiant est déjà pris 
                    if (cpt == b.Identifiant)
                    {
                        verif = 1; // On dit que l'identifiant est déjà pris 
                        cpt = cpt + 1; // On augmente le compteur 
                        break; // On quitte la boucle 
                    }
                }
            } while (verif != 0); // On fait ça tant qu'on a pas un identifiant de dispo 

            nvb.Identifiant = cpt;  // on donne le nouvel identifiant 
            lBlocs.Add(nvb); // On ajoute le nouveau bloc 
        }

        /// <summary>
        /// Permet de modifier le Bloc d'un projet 
        /// </summary>
        /// <param name="modif_b"></param>
        public void modifierBloc( Bloc modif_b)
        {
            // On parcours la liste de blocs 
            int pos = 0;
            foreach(Bloc b in this.lBlocs)
            {
                // Si on trouve le bloc 
                if (b.Identifiant == modif_b.Identifiant)
                {
                    // On retient sa position dans la liste 
                    pos = lBlocs.IndexOf(b);
                }
            }
            // On supprime le bloc 
            lBlocs[pos] = modif_b;
        }

        /// <summary>
        /// Permet de supprimer un bloc de la liste 
        /// </summary>
        /// <param name="supp_b"></param>
        public void supprimerBloc(Bloc supp_b)
        {
            int pos = 0;
            // On parcours la liste de blocs 
            foreach (Bloc b in this.lBlocs)
            {
                // Si on trouve le bloc 
                if (b.Identifiant == supp_b.Identifiant)
                {
                    // On retient sa position 
                    pos = lBlocs.IndexOf(b);
                }
            }
            // On supprime le bloc de la liste 
            lBlocs.Remove(lBlocs[pos]);
        }

        public override int GetHashCode()
            => identifiant.GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals((Projet)right);
        }

        public bool Equals(Projet other)
            => (this.identifiant == other.identifiant);

        public override string ToString()
        {
            string chaine = string.Empty;

            foreach (Bloc bloc in lBlocs)
            {
                chaine = chaine + bloc.ToString() + "\n";
            }

            return chaine;
        }

        public Projet(int id, typeProjet type)
        {
            lBlocs = new List<Bloc>();

            image_principale = "placeholderimageprojets.png";
            nom = "Nouveau projet";
            description = " Le projet ne possède pas de description...";

            this.identifiant = id;
            tags = new List<Tag>();
            this.type = type;
            boutonCommande = null;
        }
    }
}