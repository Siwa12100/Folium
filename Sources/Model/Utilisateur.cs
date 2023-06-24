using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Input;

namespace Model
{
    [DataContract(Name = "utilisateur")]
    public class Utilisateur : INotifyPropertyChanged

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
        // Nom de l'utilisateur
        private string nom;
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
                    nom = "Nom vide";
                }
                else
                {
                    nom = value;
                }
                OnPropertyChanged(nameof(Nom));
            }
        }

        [DataMember]
        // Prenom de l'utilisateur 
        private string prenom;
        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    prenom = "Prenom vide";
                }
                else
                {
                    prenom = value;
                }
                OnPropertyChanged(nameof(Prenom));
            }
        }

        [DataMember]
        // Biographie de l'utilisateur 
        private string biographie;
        public string Biographie
        {
            get
            {
                return biographie;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    biographie = "Biographie vide...";
                }
                else
                {
                    biographie = value;
                }
                OnPropertyChanged(nameof(Biographie));
            }
        }

        [DataMember]
        // Texte de la catégorie " a propos " du profil de l'utilisateur 
        private string aPropos;
        public string APropos
        {
            get
            {
                return aPropos;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    aPropos = "A propos vide...";
                }
                else
                {
                    aPropos = value;
                }
                OnPropertyChanged(nameof(APropos));
            }
        }

        [DataMember]
        // Image de profil de l'utilisateur 
        private string imageProfil;
        public string ImageProfil
        {
            get
            {
                return imageProfil;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    imageProfil = "lien vers image de profil vide";
                }
                else
                {
                    imageProfil = value;
                }
                OnPropertyChanged(nameof(ImageProfil));
            }
        }

        [DataMember]
        // Banniere de profil de l'utilisateur 
        private string banniereProfil;
        public string BanniereProfil
        {
            get
            {
                return banniereProfil;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    banniereProfil = "lien vers image de bannière vide";
                }
                else
                {
                    banniereProfil = value;
                }
                OnPropertyChanged(nameof(BanniereProfil));
            }
        }

        [DataMember (EmitDefaultValue = false)]
        // Liste des parcours de l'utilisateur 
        private List<Parcours> lParcours;
        public List<Parcours> LParcours
        {
            get { return lParcours; }
            set { lParcours = value;
                OnPropertyChanged(nameof(LParcours));
            }
        }

        /// <summary>
        /// Permet d'ajouter un parcours à la liste des parcours de l'utilisateur 
        /// </summary>
        /// <param name="nvp"></param>
        public void ajouterParcours(Parcours nvp)
        {
            int verif = 0;
            int cpt = 1;

            do
            {
                verif = 0;
                foreach (Parcours p in this.lParcours)
                {
                    if (cpt == p.Identifiant)
                    {
                        verif = 1;
                        cpt = cpt + 1;
                        break;
                    }
                }
            } while (verif != 0);

            nvp.Identifiant = cpt;
            lParcours.Add(nvp);
        }

        /// <summary>
        /// Permet de supprimer un parcours de la liste des parcours de l'utilisateur 
        /// </summary>
        /// <param name="modif_p"></param>
        public void modifierParcours(Parcours modif_p)
        {
            int pos = -1;

            foreach(Parcours p in lParcours)
            {
                if (modif_p.Identifiant == p.Identifiant)
                {
                    pos = lParcours.IndexOf(p);
                }
            }

            if (pos != -1)
            {
                lParcours[pos] = modif_p;
            }
        }

        /// <summary>
        /// Permet de supprimer un parcours de la liste de parcours de l'utilisateur 
        /// </summary>
        /// <param name="supp_p"></param>
        public void supprimerParcours(Parcours supp_p)
        {
            int pos = -1;
            foreach (Parcours p in lParcours)
            {
                if (supp_p.Identifiant == p.Identifiant)
                {
                    pos = lParcours.IndexOf(p);
                }
            }

            if (pos != -1)
            {
                lParcours.Remove(lParcours[pos]);
            }
        }

        //[DataMember(EmitDefaultValue = false)]
        //private List<Projet> lProjets;
        //public List<Projet> LProjets
        //{
        //    get { return lProjets; }
        //    set { lProjets = value; }
        //}


        [DataMember(EmitDefaultValue = false)]
        // Liste de réseaux de l'utilisateur
        private List<Reseau> lReseaux;
        public List<Reseau> LReseaux
        {
            get { return lReseaux; }
            set { lReseaux = value;
                OnPropertyChanged(nameof(LReseaux));
            }
        }

        /// <summary>
        /// Permet d'ajouter un réseau social à l'utilisateur 
        /// </summary>
        /// <param name="lien"></param>
        /// <param name="type"></param>
        public void ajouterReseau(string lien, typeReseaux type)
        {
            int cpt = 1;
            int verif = 0;

            do
            {
                verif = 0;
                foreach (Reseau r in this.lReseaux)
                {
                    if (cpt == r.Identifiant)
                    {
                        verif = 1;
                        cpt = cpt + 1;
                        break;
                    }
                }
            } while (verif != 0);

            Reseau nvr = new Reseau(cpt, lien, type);
            lReseaux.Add(nvr);
        }

        /// <summary>
        /// Permet de modifier un réseau social de l'utilisateur
        /// </summary>
        /// <param name="modif_r"></param>
        public void modifierReseau(Reseau modif_r)
        {
            int pos = -1;

            foreach(Reseau r in lReseaux)
            {
                if (r.Identifiant == modif_r.Identifiant)
                {
                    pos = lReseaux.IndexOf(r);
                }
            }

            if(pos != -1)
            {
                lReseaux[pos] = modif_r;
            }
        }

        /// <summary>
        /// Permet de supprime un réseau social de l'utilisateur 
        /// </summary>
        /// <param name="supp_r"></param>
        public void supprimerReseau(Reseau supp_r)
        {
            int pos = -1;
            foreach (Reseau r in lReseaux)
            {
                if (r.Identifiant == supp_r.Identifiant)
                {
                    pos = lReseaux.IndexOf(r);
                }
            }

            if(pos != -1)
            {
                lReseaux.Remove(LReseaux[pos]);
            }
        }

        public override int GetHashCode()
            => nom.GetHashCode() ^ prenom.GetHashCode() ^ biographie.GetHashCode();

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null)) return false;
            if (object.ReferenceEquals(this, right)) return true;
            if (this.GetType() != right.GetType()) return false;
            return this.Equals(right as Utilisateur);
        }

        public bool Equals(Utilisateur other)
            => (this.nom == other.nom && this.prenom == other.prenom /*&& this.lProjets == other.lProjets*/);

        public override string ToString()
        {
            return $"Nom Prenom : {nom} {prenom} \nBiographie : {biographie} \nA propos : {aPropos} \nBanniere Profil : {banniereProfil} \nImage Profil : {imageProfil}";
        }

        public Utilisateur()
        {
            lReseaux = new List<Reseau>();
            //lProjets = new List<Projet>();
            lParcours= new List<Parcours>();

            nom = "Nouvel";
            prenom = "utilisateur";

            biographie = " Pas de biographie renseignée ";
            aPropos = " Pas de A propos renseigné ";
            banniereProfil = " Lien vers bannière non renseignée... ";
            imageProfil = " Lien vers image non renseignée...";
        }
    }
}
