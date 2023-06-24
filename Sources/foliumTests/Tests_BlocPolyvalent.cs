using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace foliumTests
{
    public class Tests_BlocPolyvalent
    {
        [Fact]
        public void Verif_BlocPolyvalent_Non_Null()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            Assert.NotNull(b);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Titre_Non_Null()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            Assert.NotNull(b.Titre);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Texte_Non_Null()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            Assert.NotNull(b.Texte);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Image_Non_Null()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            Assert.NotNull(b.Image);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Titre_Set()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            BlocPolyvalent b1 = new BlocPolyvalent();
            BlocPolyvalent b2 = new BlocPolyvalent();

            b.Titre = "Nouveau texte...";
            b1.Titre = "         ";
            b2.Titre = null;

            Assert.Equal("Nouveau texte...", b.Titre);
            Assert.Equal(Bloc.placeholder_titre, b1.Titre);
            Assert.Equal(b1.Titre, b2.Titre);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Image_Set()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            BlocPolyvalent b1 = new BlocPolyvalent();
            BlocPolyvalent b2 = new BlocPolyvalent();

            b.Image = "Nouveau texte...";
            b1.Image = "         ";
            b2.Image = null;

            Assert.Equal("Nouveau texte...", b.Image);
            Assert.Equal(Bloc.placeholder_image, b1.Image);
            Assert.Equal(b1.Image, b2.Image);
        }

        [Fact]
        public void Verif_ProprieteBlocPolyvalent_Texte_Set()
        {
            BlocPolyvalent b = new BlocPolyvalent();
            BlocPolyvalent b1 = new BlocPolyvalent();
            BlocPolyvalent b2 = new BlocPolyvalent();

            b.Texte = "Nouveau texte...";
            b1.Texte = "         ";
            b2.Texte = null;

            Assert.Equal("Nouveau texte...", b.Texte);
            Assert.Equal(Bloc.placeholder_texte, b1.Texte);
            Assert.Equal(b1.Texte, b2.Texte);
        }
    }
}
