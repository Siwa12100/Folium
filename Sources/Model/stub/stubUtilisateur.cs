using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubUtilisateur
    {
        private List<Utilisateur> lUtilisateurs;
        private stubReseau stubReseau;
        private stubParcours stubParcours;
        private stubProjet stubProjet;

        public List<Utilisateur> getUtilisateurs()
        {
            return lUtilisateurs;
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            List<Utilisateur> liste = new List<Utilisateur>();

            Utilisateur u1 = new Utilisateur();
            u1.Nom = "Falques";
            u1.Prenom = "Louis";
            u1.Biographie = "Ceci est la passionnante biographie de Louis Falques";
            u1.APropos = "Ceci est la passionnante section a Propos de Louis Falques";
            u1.ImageProfil = "placeholder_photo_profil.png";
            u1.BanniereProfil = " Lien vers l'image de banniere de profil de Louis Falques";

            Utilisateur u2 = new Utilisateur();
            u2.Nom = "Siwa";
            u2.Prenom = "D'Elendil";
            u2.BanniereProfil = " Lien vers la bannière de profil de Siwa";
            u2.ImageProfil = " Lien vers l'image de profil de Siwa";
            u2.APropos = " Voici la catégorie A propos de Siwa";
            u2.Biographie = " Ceci est la biographie de Siwa";

            //foreach (Parcours p in stubParcours.getParcours())
            //{
            //    //Console.WriteLine("(temp) -> Chargement des parcours dans les utilisateurs");
            //    u1.ajouterParcours(p);
            //}

            u1.ajouterReseau("https://www.youtube.com/", typeReseaux.Youtube);
            u1.ajouterReseau("https://www.twitch.tv/", typeReseaux.Twitch);
            u1.ajouterReseau("https://github.com/", typeReseaux.GitHub);

            foreach (Reseau r in stubReseau.getReseaux())
            {
                //Console.WriteLine("(temp) -> Chargement des réseaux dans les utilisateurs");
                u2.ajouterReseau(r.Lien, r.Type);
            }

            liste.Add(u1);
            liste.Add(u2);

            //Console.WriteLine("Passage par ici...");


            foreach (Utilisateur u in liste)
            {
                foreach (Parcours p in stubParcours.getParcours())
                {
                    //Console.WriteLine("(temp) -> Chargement des parcours dans les utilisateurs");
                    u.ajouterParcours(p);
                }

                //foreach(Projet p in stubProjet.getlProjets())
                //{
                //    //Console.WriteLine("(temp) -> Chargement des projets dans les utilisateurs");
                //    u.AjouterProjet(p);
                //}
            }

            return liste;
        }

        public stubUtilisateur()
        {
            stubReseau = new stubReseau();
            stubProjet = new stubProjet();
            stubParcours = new stubParcours();

            lUtilisateurs = GetUtilisateurs().ToList();
        }
    }
}
