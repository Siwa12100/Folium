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
    /// Les blocs sont les éléments qui composent les projets dans l'application. 
    /// C'est eux qui contiennent toutes les informations. Il est ainsi possible de 
    /// créer de nouveaux blocs dans un projet, de modifier leurs attributs et d'en supprimer 
    /// </summary>
    [DataContract (Name = "Bloc")]
    public class Bloc : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        // Différents placeholder qui sont utilisés lorsqu'un attribut dans une instance n'est pas rempli par l'utilisateur. 
        public static readonly string placeholder_titre = "Entrer titre ici...";
        public static readonly string placeholder_texte = "Entrer texte ici...";
        public static readonly string placeholder_image = "placeholderimageneraldeux.jpg";
        public static readonly string placeholder_titre1 = "Entrez premier titre ici..."; // Titre réservé au bloc graphique 
        public static readonly string placeholder_titre2 = "Entrez second titre ici..."; // Titre réservé au bloc graphique 
        public static readonly string placeholder_image1 = "placeholderimageneraldeux.jpg"; // Image réservée au bloc graphique 
        public static readonly string placeholder_image2 = "placeholderimageneral.jpg"; // Image réservée au bloc graphique

        [DataMember]
        // Identifiant qui permet de repérer les différents blocs au sein d'un projet 
        private int identifiant;
        public int Identifiant
        {
            get { return this.identifiant; }    
            set { this.identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }
    }
}
