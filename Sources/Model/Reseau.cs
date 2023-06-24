using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Input;

namespace Model
{
    /// <summary>
    /// Différents types de réseaux sociaux pouvant être spécifiés 
    /// </summary>
    public enum typeReseaux
    {
        Youtube,
        Twitch,
        Twitter,
        Facebook,
        GitHub,
        Instagram,
        Linkedln
    }

    [DataContract (Name = "reseau")]
    public class Reseau : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler? PropertyChanged;

            void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

        // Permet de faire l'association entre le type de ré"seau et son logo 
        public static readonly Dictionary<typeReseaux, string> Reseaux = new Dictionary<typeReseaux, string> ();

        // Fait l'association entre le type de réseau et la couleur de son bouton sur la vue ( Youtube rouge, twitter bleu, ... )
        public static readonly Dictionary<typeReseaux, string> CouleurReseaux = new Dictionary<typeReseaux, string>();
        static Reseau()
        {
            Reseaux.Add(typeReseaux.Instagram, "logo_insta.png");
            Reseaux.Add(typeReseaux.Facebook, "logo_facebook.png");
            Reseaux.Add(typeReseaux.Linkedln, "logo_linkedln.png");
            Reseaux.Add(typeReseaux.Twitter, "logo_twitter.png");
            Reseaux.Add(typeReseaux.GitHub, "logo_github.png");
            Reseaux.Add(typeReseaux.Twitch, "logo_twitch.png");
            Reseaux.Add(typeReseaux.Youtube, "logo_youtube.png");

            CouleurReseaux.Add(typeReseaux.Instagram, "BC1C67");
            CouleurReseaux.Add(typeReseaux.Facebook, "256FD3");
            CouleurReseaux.Add(typeReseaux.Linkedln, "359AAE");
            CouleurReseaux.Add(typeReseaux.Twitter, "43C5DF");
            CouleurReseaux.Add(typeReseaux.GitHub, "60773B");
            CouleurReseaux.Add(typeReseaux.Twitch, "8A22C2");
            CouleurReseaux.Add(typeReseaux.Youtube, "FA0000");
        }

        // Cet attribut va ensuite prendre une méthode au niveau de la vue qui permet d'ouvrir 
        // Un navigateur internet avec le lien du réseau de la personne 
        private ICommand boutonCommande;
        public ICommand BoutonCommande { get; set; }

        [DataMember]
        private  string lien;
        public string Lien
        {
            get
            {
                return lien;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    lien = "Lien vide...";
                }
                else
                {
                    lien = value;
                }
                OnPropertyChanged(nameof(Lien));
            }
        }

        [DataMember]
        // Logo du réseau
        private string logo;
        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    logo = "Lien vide...";
                }
                else
                {
                    logo = value;
                }
                OnPropertyChanged(nameof(Logo));
            }
        }

        [DataMember]
        // Couleur du bouton du réseau 
        private string couleur;
        public string Couleur
        {
            get
            {
                return couleur;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    couleur = "Lien vide...";
                }
                else
                {
                    couleur = value;
                }
                OnPropertyChanged(nameof(couleur));
            }
        }

        [DataMember]
        // Type de réseau 
        private typeReseaux type;
        public typeReseaux Type
        {
            get { return type; }
            set { type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        [DataMember]
        // identifiant pour le retrouver parmis la liste des réseaux de l'utilisateur 
        private int identifiant;
        public int Identifiant
        {
            get { return identifiant; }
            set { identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }

        public override int GetHashCode()
            => lien.GetHashCode() ^ Reseaux[this.type].GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as Reseau);
        }

        public bool Equals(Reseau other)
            => (this.lien == other.lien && this.type == other.type);

        public override string ToString()
        {
            return $" - Lien du Reseau : {lien} \n - Lien du Logo : {Reseaux[this.type]}";
        }

        public Reseau(int id, string lien, typeReseaux type)
        {
            this.lien = lien;
            this.type = type;
            this.identifiant = id;

            couleur = CouleurReseaux[this.type];
            logo = Reseaux[this.type];
            boutonCommande = null;
        }
    }
}
