using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Model.stub;

namespace foliumTests
{
    public class Tests_Parcours
    {
        [Fact]
        public void Verif_ProprieteParcours_Titre_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.NotNull(p.Titre);
        }

        [Fact]
        public void Verif_Parcours_Non_Null()
        {
            Parcours parcours = new Parcours();
            Assert.NotNull(parcours);
        }

        [Fact]
        public void Verif_ProprieteParcours_Departement_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.Equal(0,p.Departement); 
        }

        [Fact]
        public void Verif_ProprieteParcours_Date_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.Equal(new DateTime(0001, 01, 01), p.Date);
        }

        [Fact]
        public void Verif_ProprieteParcours_Ville_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.NotNull(p.Ville);
        }

        [Fact]
        public void Verif_ProprieteParcours_Type_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.True(Enum.IsDefined(typeof(typeParcours), p.Type));
        }

        [Fact]
        public void Verif_ProprieteParcours_Identifiant_Non_Null()
        {
            Parcours p = new Parcours();
            Assert.Equal(0, p.Identifiant);
        }

        [Fact]
        public void Verif_ProprieteParcours_Titre_Set()
        {
            Parcours p = new Parcours();
            Parcours p1 = new Parcours();
            Parcours p2 = new Parcours();

            p.Titre = "Titi";
            p1.Titre = "          ";
            p2.Titre = null;

            Assert.Equal("Titi", p.Titre);
            Assert.Equal("Pas de titre", p1.Titre);
            Assert.Equal(p1.Titre, p2.Titre);
        }

        [Fact]
        public void Verif_ProprieteParcours_Date_Set()
        {
            Parcours p = new Parcours();
            p.Date = new DateTime(0001, 03, 03);
            Assert.Equal(new DateTime(0001, 03, 03), p.Date);
        }

        [Fact]
        public void Verif_ProprieteParcours_Ville_Set()
        {
            Parcours p = new Parcours(); 
            Parcours p1 = new Parcours();
            Parcours p2 = new Parcours();

            p.Ville = "Titi";
            p1.Ville = "          ";
            p2.Ville = null;

            Assert.Equal("Titi", p.Ville);
            Assert.Equal("Ville non renseignée...", p1.Ville);
            Assert.Equal(p1.Ville, p2.Ville);
        }

        [Fact]
        public void Verif_ProprieteParcours_Departement_Set()
        {
            Parcours p = new Parcours();
            Parcours p1 = new Parcours();

            p1.Departement = -6;
            p.Departement = 3;

            Assert.Equal(3, p.Departement);
            Assert.Equal(0, p1.Departement);
        }

        [Fact]
        public void Verif_ProprieteParcours_Identifiant_Set()
        {
            Parcours p = new Parcours();
            p.Identifiant = 34;
            Assert.Equal(34, p.Identifiant);
        }

        [Fact]
        public void Verif_ProprieteParcours_LDetails_Set()
        {
            Parcours p = new Parcours();
            List<String> liste = new List<String>();

            for(int i = 0; i < 10; i++)
            {
                liste.Add("tata");
                liste.Add("toto");
            }

            p.LDetails = liste;
            Assert.Equal(liste, p.LDetails);
        }

        [Fact]
        public void Verif_ProprieteParcours_Type_Set()
        {
            Parcours p = new Parcours();
            p.Type = typeParcours.Benevolat;
            Assert.Equal(typeParcours.Benevolat, p.Type);
        }

        [Fact]
        public void Verif_ajouterDetails()
        {
            int verif = 0;

            Parcours p = new Parcours();
            String s1 = "Toto";
            p.ajouterDetails(s1);

            foreach(String s in p.LDetails)
            {
                if (s == s1)
                {
                    verif = 1;
                    break;
                }
            }

            Assert.Equal(1, verif);
        }

        [Fact]
        public void Verif_supprimerDetails()
        {
            int verif = 0;

            Parcours p = new Parcours();
            String s1 = "Toto";
            p.ajouterDetails(s1);
            p.supprimerDetails(s1);

            foreach (String s in p.LDetails)
            {
                if (s == s1)
                {
                    verif = 1;
                    break;
                }
            }

            Assert.Equal(0, verif);
        }
    }
}
