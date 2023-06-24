using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Ce type de Bloc est constitué d'un titre et d'un texte
    /// </summary>
    [DataContract (Name = "BlocTextuel")]
    public class BlocTextuel : Bloc
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
        // Texte du Bloc 
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

        public override int GetHashCode()
            => Identifiant.GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as BlocTextuel);
        }

        public bool Equals(BlocTextuel other)
            => (this.Identifiant == other.Identifiant);

        public override string ToString()
        {
            return $" ID :{Identifiant} | Titre du bloc : {titre} | texte du bloc : {texte}";
        }

        public BlocTextuel()
        {
            this.titre = placeholder_titre;
            this.texte = placeholder_texte;
            this.Identifiant = 0;
        }
    }
}
