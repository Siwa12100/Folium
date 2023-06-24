using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace Model
{
    /// <summary>
    /// Il s'agit d'un type de Bloc composé de 2 images et 2 titres 
    /// </summary>
    [DataContract (Name = "BlocGraphique")]
    public class BlocGraphique : Bloc 
    {
        [DataMember]
        // Titre de la première image du Bloc graphique 
        private string titre1;
        public string Titre1
        {
            get
            {
                return titre1;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    titre1 = placeholder_titre1;
                }
                else
                {
                    titre1 = value;
                }
                OnPropertyChanged(nameof(Titre1));
            }
        }

        [DataMember]
        // Titre de la seconde image du bloc graphique 
        private string titre2;
        public string Titre2
        {
            get
            {
                return titre2;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    titre2 = placeholder_titre2;
                }
                else
                {
                    titre2 = value;
                }
                OnPropertyChanged(nameof(Titre2));
            }
        }

        [DataMember]
        // Première image du bloc 
        private string image1;
        public string Image1
        {
            get
            {
                return image1;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    image1 = placeholder_image1;
                }
                else
                {
                    image1 = value;
                }
                OnPropertyChanged(nameof(Image1));
            }
        }

        [DataMember]
        // Seconde image du bloc 
        private string image2;
        public string Image2
        {
            get
            {
                return image2;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    image2 = placeholder_image2;
                }
                else
                {
                    image2 = value;
                }
                OnPropertyChanged(nameof(Image2));
            }
        }

        public override int GetHashCode()
            => Identifiant.GetHashCode();

        public override bool Equals(object? right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as BlocGraphique);
        }

        public bool Equals(BlocGraphique other)
            => (this.Identifiant == other.Identifiant);

        public override string ToString()
        {
            return $" ID : {Identifiant} | Titre 1 & 2 du bloc : {titre1} ; {titre2} | Image 1 & 2 : {image1} ; {image2} ";
        }


        public BlocGraphique()
        {
            this.titre1 = placeholder_titre1;
            
            this.titre2 = placeholder_titre2;
            this.image1 = placeholder_image1;
            this.image2 = placeholder_image2;

            this.Identifiant = 0;
        }
    }
}
