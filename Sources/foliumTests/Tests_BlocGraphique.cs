using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace foliumTests
{
    public class Tests_BlocGraphique
    {
        [Fact]
        public void Verif_BlocGraphique_Non_Null()
        {
            BlocGraphique b = new BlocGraphique();
            Assert.NotNull(b);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Titre1_Non_Null()
        {
            BlocGraphique b = new BlocGraphique();
            Assert.NotNull(b.Titre1);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Titre2_Non_Null()
        {
            BlocGraphique b = new BlocGraphique();
            Assert.NotNull(b.Titre2);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Image1_Non_Null()
        {
            BlocGraphique b = new BlocGraphique();
            Assert.NotNull(b.Image1);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Image2_Non_Null()
        {
            BlocGraphique b = new BlocGraphique();
            Assert.NotNull(b.Image2);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Titre1_Set()
        {
            BlocGraphique b = new BlocGraphique();
            BlocGraphique b1 = new BlocGraphique();
            BlocGraphique b2 = new BlocGraphique();

            b.Titre1 = "Nouveau texte...";
            b1.Titre1 = "         ";
            b2.Titre1 = null;

            Assert.Equal("Nouveau texte...", b.Titre1);
            Assert.Equal(Bloc.placeholder_titre1, b1.Titre1);
            Assert.Equal(b1.Titre1, b2.Titre1);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Titre2_Set()
        {
            BlocGraphique b = new BlocGraphique();
            BlocGraphique b1 = new BlocGraphique();
            BlocGraphique b2 = new BlocGraphique();

            b.Titre2 = "Nouveau texte...";
            b1.Titre2 = "         ";
            b2.Titre2 = null;

            Assert.Equal("Nouveau texte...", b.Titre2);
            Assert.Equal(Bloc.placeholder_titre2, b1.Titre2);
            Assert.Equal(b1.Titre2, b2.Titre2);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Image1_Set()
        {
            BlocGraphique b = new BlocGraphique();
            BlocGraphique b1 = new BlocGraphique();
            BlocGraphique b2 = new BlocGraphique();

            b.Image1 = "Nouveau texte...";
            b1.Image1 = "         ";
            b2.Image1 = null;

            Assert.Equal("Nouveau texte...", b.Image1);
            Assert.Equal(Bloc.placeholder_image1, b1.Image1);
            Assert.Equal(b1.Image1, b2.Image1);
        }

        [Fact]
        public void Verif_ProprieteBlocGraphique_Image2_Set()
        {
            BlocGraphique b = new BlocGraphique();
            BlocGraphique b1 = new BlocGraphique();
            BlocGraphique b2 = new BlocGraphique();

            b.Image2 = "Nouveau texte...";
            b1.Image2 = "         ";
            b2.Image2 = null;

            Assert.Equal("Nouveau texte...", b.Image2);
            Assert.Equal(Bloc.placeholder_image2, b1.Image2);
            Assert.Equal(b1.Image2, b2.Image2);
        }
    }
}
