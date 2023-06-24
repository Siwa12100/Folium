using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Ce type de bloc est constitué d'un texte, d'un titre et d'une image.
    /// </summary>
    [DataContract (Name = "BlocPolyvalent")]
    public class BlocPolyvalent : Bloc
    {
        [DataMember]
        // Titre du bloc 
        private string titre;
        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    titre = placeholder_titre;
                }
                else
                {
                    titre = value;
                }
            }
        }

        [DataMember]
        // Texte principal du Bloc 
        private string texte;
        public string Texte
        {
            get
            {
                return texte;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    texte = placeholder_texte;
                }
                else
                {
                    texte = value;
                }
            }
        }

        [DataMember]
        // Image du bloc 
        private string image;
        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    image = placeholder_image;
                }
                else
                {
                    image = value;
                }
                
            }
        }
        public override int GetHashCode()
            => Identifiant.GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as BlocPolyvalent);
        }

        public bool Equals(BlocPolyvalent other)
            => (this.Identifiant == other.Identifiant);

        public override string ToString()
        {
            return $" ID : {Identifiant} | Titre du bloc : {titre} | Texte : {texte} | Image : {image}";
        }

        public BlocPolyvalent()
        {
            this.titre = placeholder_titre;
            this.texte = placeholder_texte;
            this.image = placeholder_image;
            this.Identifiant = 0;
        }
    }
}
