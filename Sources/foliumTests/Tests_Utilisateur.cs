using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Model;
using Model.stub;

namespace foliumTests
{
    public class Tests_Utilisateur
    {
        [Fact]
        public void Verif_Utilisateur_Non_Null()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Nom_Non_Null()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.Nom);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Prenom_Non_Null()
        {
            Utilisateur utilisateur=new Utilisateur();
            Assert.NotNull (utilisateur.Prenom);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Biographie_Non_Null()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.Biographie);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_APropos_Non_Null()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.APropos);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_ImageProfil_Non_Null()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.ImageProfil);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_BanniereProfil()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.BanniereProfil);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_LParcours()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.LParcours);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_LReseaux()
        {
            Utilisateur utilisateur = new Utilisateur();
            Assert.NotNull(utilisateur.LReseaux);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Nom_Set()
        {
            Utilisateur u = new Utilisateur();
            u.Nom = "Louis";
            Assert.Equal("Louis", u.Nom);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Prenom_Set()
        {
            Utilisateur u = new Utilisateur();
            u.Prenom = "Louis";
            Assert.Equal("Louis", u.Prenom);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_Biographie_Set()
        {
            Utilisateur u = new Utilisateur();
            u.Biographie = "Louis";
            Assert.Equal("Louis", u.Biographie);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_APropos_Set()
        {
            Utilisateur u = new Utilisateur();
            u.APropos = "Louis";
            Assert.Equal("Louis", u.APropos);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_ImageProfil_Set()
        {
            Utilisateur u = new Utilisateur();
            u.ImageProfil = "Louis";
            Assert.Equal("Louis", u.ImageProfil);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_BanniereProfil_Set()
        {
            Utilisateur u = new Utilisateur();
            u.BanniereProfil = "Louis";
            Assert.Equal("Louis", u.BanniereProfil);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_lParcours_Set()
        {
            stubManager mgr = new stubManager();
            Utilisateur u = new Utilisateur();
            u.LParcours = mgr.getParcours().ToList();
            Assert.Equal(mgr.getParcours().ToList(), u.LParcours);
        }

        [Fact]
        public void Verif_ProprieteUtilisateur_LReseaux_Set()
        {
            stubManager mgr = new stubManager();
            Utilisateur u = new Utilisateur();
            u.LReseaux = mgr.getReseaux().ToList();
            Assert.Equal(mgr.getReseaux().ToList(), u.LReseaux);
        }

        [Fact]
        public void Verif_ajouterParcoursFonctionnel()
        {
            int verif = 1;
            Utilisateur u = new Utilisateur();
            Parcours nvp = new Parcours();

            u.ajouterParcours(nvp);

            foreach(Parcours p in u.LParcours)
            {
                if(p.Titre == nvp.Titre && p.Date == nvp.Date &&
                   p.Ville == nvp.Ville && p.Departement == nvp.Departement &&
                   p.Type == nvp.Type)
                {
                    verif = 0;
                    break;
                }
            }

            Assert.Equal(0, verif);
        }

        [Fact]
        public void Verif_modifierParcours()
        {
            Utilisateur u = new Utilisateur();
            Parcours p1 = new Parcours();
            u.ajouterParcours(p1);

            Parcours p2 = u.LParcours[0];
            p2.Titre = "Test de modification du titre";
            u.modifierParcours(p2);

            Assert.Equal(p2, u.LParcours[0]);
        }

        [Fact]
        public void Verif_supprimerParcours()
        {
            int verif = 0;

            Utilisateur u = new Utilisateur();
            Parcours p1 = new Parcours();
            Parcours p2 = new Parcours();
            u.ajouterParcours(p1);
            p2.Titre = " Titre de p2...";
            u.ajouterParcours(p2);

            Parcours verifp = u.LParcours[0];
            u.supprimerParcours(p1);

            foreach(Parcours p in u.LParcours)
            {
                if(p == verifp)
                {
                    verif = 1;
                    break;
                }
            }

            Assert.NotEqual(1, verif);
        }

        [Fact]
        public void Verif_ajouterReseau()
        {
            Utilisateur u = new Utilisateur();
            Reseau r1 = new Reseau(0, "Lien", typeReseaux.Facebook);
            u.ajouterReseau("Lien", typeReseaux.Facebook);

            Assert.Equal(r1, u.LReseaux[0]);
        }

        [Fact]
        public void Verif_modifierReseau()
        {
            Utilisateur u = new Utilisateur();
            u.ajouterReseau("Lien", typeReseaux.Facebook);

            Reseau r2 = u.LReseaux[0];
            r2.Lien = "Lien version 2";
            u.modifierReseau(r2);

            Assert.Equal(r2, u.LReseaux[0]);
        }

        [Fact]
        public void Verif_supprimerReseau()
        {
            int verif = 0;

            Utilisateur u = new Utilisateur();
            u.ajouterReseau("Lien1", typeReseaux.Facebook);
            u.ajouterReseau("Lien2", typeReseaux.Youtube);

            Reseau r1 = u.LReseaux[1];
            u.supprimerReseau(r1);

            foreach(Reseau r in u.LReseaux)
            {
                if (r == r1)
                {
                    verif = 1;
                    break;
                }
            }

            Assert.Equal(0, verif);
        }
    }
}