using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    /// <summary>
    /// Permet de spécifier le type de parcours 
    /// </summary>
    public enum typeParcours
    {
        Stage, 
        Entreprise,
        Benevolat
    }

    [DataContract (Name = "parcours")]
    public class Parcours : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        [DataMember]
        // Titre du parcours 
        private string titre;
        public string Titre
        {
            get { return titre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    titre = "Pas de titre";
                }
                else
                {
                    titre = value;
                }
                OnPropertyChanged(nameof(Titre));
            }
        }

        [DataMember]
        // Date à laquelle ce parcours a été réalisé 
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        [DataMember]
        // Ville où ce parcours a été réalisé 
        private string ville;
        public string Ville
        {
            get
            {
                return ville;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ville = "Ville non renseignée...";
                }
                else
                {
                    ville = value;
                }
                OnPropertyChanged(nameof(Ville));
            }
        }

        [DataMember]
        // Departement dans lequel le parcours a été réalisé 
        private int departement;
        public int Departement
        {
            get { return departement; }
            set
            {
                if (value < 0)
                {
                    departement = 0;
                }
                else
                {
                    departement = value;
                }
                OnPropertyChanged(nameof(Departement));
            }
        }

        [DataMember]
        // Type de parcours 
        private typeParcours type;
        public typeParcours Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        [DataMember]
        // Identifiant qui permet de retrouver le parcours parmis tous les 
        // parcours d'un utilisateur 
        private int identifiant;
        public int Identifiant
        {
            get => identifiant;
            set
            {
                identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }

        [DataMember(EmitDefaultValue = false)]
        // Petites textes permettant de donner des informations supplémentaire
        // sur le parcours de manière à être clair et précis 
        private List<string> lDetails;
        public List<string> LDetails
        {
            get => lDetails;
            set
            {
                lDetails = value;
                OnPropertyChanged(nameof(LDetails));
            }
        }

        /// <summary>
        ///  Permet d'ajouter des détails à la liste de détails du parcours 
        /// </summary>
        /// <param name="s"></param>
        public void ajouterDetails(String s)
        {
            lDetails.Add(s);
        }

        /// <summary>
        /// Permet de supprimer un détail au parcours 
        /// </summary>
        /// <param name="s"></param>
        public void supprimerDetails(String s)
        {
            lDetails.Remove(s);
        }


        public override string ToString()
        {
            string details =  string.Empty;

            foreach(string d in lDetails)
            {
                details += d + " |  ";
            }

            return $" - Titre : {titre} \n - Type : {type} \n - Details : {details}\n - Date : {date}\n - Ville : {ville}\n - Departement : {departement}";
        }


        public override int GetHashCode()
            => titre.GetHashCode() ^ lDetails.GetHashCode() ^ date.GetHashCode() ^ ville.GetHashCode() ^ departement.GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as Parcours);
        }

        public bool Equals(Parcours other)
            => (this.titre == other.titre && this.lDetails == other.lDetails && this.date == other.date && this.ville == other.ville && this.departement == other.departement);

        public Parcours()
        {
            titre = "Pas de titre";
            lDetails = new List<string>();
            date = new DateTime(0001, 01, 01);
            ville = " Pas de ville renseignée...";
            type = typeParcours.Entreprise;
            departement = 0;
            identifiant = 0;
        }
    }
}
