using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Model.stub;

namespace foliumTests
{
    public class Tests_Projet
    {
        [Fact]
        public void Verif_Projet_Non_Null()
        {
            Projet p = new Projet(5);
            Assert.NotNull(p);
        }

        [Fact]
        public void Verif_ProprieteProjet_LBlocs_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.NotNull(p.LBlocs);
        }

        [Fact]
        public void Verif_ProprieteProjet_Identifiant_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.Equal(6, p.Identifiant);
        }

        [Fact]
        public void Verif_ProprieteProjet_Nom_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.NotNull(p.Nom);
        }

        [Fact]
        public void Verif_ProprieteProjet_Tags_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.NotNull(p.Tags);
        }

        [Fact]
        public void Verif_ProprieteProjet_Image_principale_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.NotNull(p.Image_principale);
        }

        [Fact]
        public void Verif_ProprieteProjet_Description_Non_Null()
        {
            Projet p = new Projet(6);
            Assert.NotNull(p.Description);
        }

        [Fact]
        public void Verif_ProprieteProjet_LBlocs_Set()
        {
            stubManager mgr = new stubManager();
            Projet p = new Projet(6);
            List<Bloc> liste = new List<Bloc>();

            foreach(Bloc b in mgr.getBlocsGraphiques().ToList())
            {
                liste.Add(b);
            }

            p.LBlocs = liste;
            Assert.Equal(liste, p.LBlocs);
        }

        [Fact]
        public void Verif_ProprieteProjet_identifiant_Set()
        {
            Projet p = new Projet(3);
            p.Identifiant = 12;
            Assert.Equal(12, p.Identifiant);
        }

        [Fact]
        public void Verif_ProprieteProjet_Nom_Set()
        {
            Projet p = new Projet(3);
            Projet p1 = new Projet(1);
            Projet p2 = new Projet(2);
            p2.Nom = null;
            p1.Nom = "     ";
            p.Nom = "texte...";
            Assert.Equal("texte...", p.Nom);
            Assert.Equal("Nouveau projet", p1.Nom);
            Assert.Equal("Nouveau projet", p2.Nom);
        }

        [Fact]
        public void Verif_ProprieteProjet_Image_principale_Set()
        {
            Projet p  = new Projet(3);
            Projet p1 = new Projet(5);
            Projet p2 = new Projet(8);

            p.Image_principale = "texte...";
            p1.Image_principale = "      ";
            p2.Image_principale = null;

            Assert.Equal("texte...", p.Image_principale);
            Assert.Equal("Insérer lien vers image...", p1.Image_principale);
            Assert.Equal(p1.Image_principale, p2.Image_principale);
        }

        [Fact]
        public void Verif_ProprieteProjet_Description_Set()
        {
            Projet p = new Projet(3);
            Projet p1 = new Projet(5);
            Projet p2 = new Projet(8);

            p.Description = "texte...";
            p1.Description = "     ";
            p2.Description = null;

            Assert.Equal(" Le projet ne possède pas de description... ", p1.Description);
            Assert.Equal(p1.Description, p2.Description);
            Assert.Equal("texte...", p.Description);
        }

        [Fact]
        public void Verif_ProprieteProjet_Tags_Set()
        {
            Projet p = new Projet(3);
            List<Tag> liste = new List<Tag>();

            for(int i =  0; i < 10; i++)
            {
                liste.Add(Tag.Dessin);
                liste.Add(Tag.JeuxVideos);
            }

            p.Tags = liste;
            Assert.Equal(liste, p.Tags);
        }

        [Fact]
        public void Verif_InitialisationPojetTextuel()
        {
            int cpt = 0;
            Projet p = new Projet(1);

            p.initialisationProjetTextuel();

            foreach(Bloc b in p.LBlocs)
            {
                if(b.GetType() == typeof(BlocTextuel))
                {
                    cpt++;
                }
            }

            Assert.Equal(3, cpt);
        }

        [Fact]
        public void Verif_InitialisationPojetGraphique()
        {
            int cpt = 0;
            Projet p = new Projet(1);

            p.initialisationProjetGraphique();

            foreach (Bloc b in p.LBlocs)
            {
                if (b.GetType() == typeof(BlocGraphique))
                {
                    cpt++;
                }
            }

            Assert.Equal(3, cpt);
        }

        [Fact]
        public void Verif_InitialisationPojetPolyvalent()
        {
            int cpt = 0;
            Projet p = new Projet(1);

            p.initialisationProjetPolyvalent();

            foreach (Bloc b in p.LBlocs)
            {
                if (b.GetType() == typeof(BlocPolyvalent))
                {
                    cpt++;
                }
            }

            Assert.Equal(3, cpt);
        }

        [Fact]
        public void Verif_modifierBloc()
        {
            Projet p = new Projet(7);
            stubManager mgr = new stubManager();
            BlocTextuel bt = mgr.getBlocstextuels().ToList()[0];

            p.ajouterBloc(bt);
            BlocTextuel bt2 = (BlocTextuel)p.LBlocs.ToList()[0];
            bt2.Titre = " Le nouveau titre pour tester la modification...";
            p.modifierBloc(bt2);

            Assert.Equal(bt2, (BlocTextuel)p.LBlocs.ToList()[0]);
        }

        [Fact]
        public void Verif_supprimerBloc()
        {
            int scan = 0;
            Projet p = new Projet(7);
            stubManager mgr = new stubManager();
            BlocTextuel bt = mgr.getBlocstextuels().ToList()[0];

            p.ajouterBloc(bt);
            BlocTextuel verif = (BlocTextuel)p.LBlocs.ToList()[0];
            p.supprimerBloc(p.LBlocs.ToList()[0]);

            foreach(Bloc b in p.LBlocs)
            {
                if( verif == b)
                {
                    scan++;
                    break;
                }
            }
            Assert.Equal(0, scan);
        }
    }
}
