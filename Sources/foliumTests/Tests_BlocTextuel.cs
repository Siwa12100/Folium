using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
namespace foliumTests
{
    public class Tests_BlocTextuel
    {
        [Fact]
        public void Verif_BlocTextuel_Non_Null()
        {
            BlocTextuel b = new BlocTextuel();
            Assert.NotNull(b);
        }

        [Fact]
        public void Verif_ProprieteBlocTextuel_Titre_Non_Null()
        {
            BlocTextuel b = new BlocTextuel();
            Assert.NotNull(b.Titre);
        }

        [Fact]
        public void Verif_ProprieteBlocTextuel_Texte_Non_Null()
        {
            BlocTextuel b = new BlocTextuel();
            Assert.NotNull(b.Texte);
        }

        [Fact]
        public void Verif_ProprieteBloctextuel_Titre_Set()
        {
            BlocTextuel b = new BlocTextuel();
            BlocTextuel b1 = new BlocTextuel();
            BlocTextuel b2 = new BlocTextuel();

            b.Titre = "Nouveau texte...";
            b1.Titre = "        ";
            b2.Titre = null;

            Assert.Equal("Nouveau texte...", b.Titre);
            Assert.Equal(Bloc.placeholder_titre, b1.Titre);
            Assert.Equal(b1.Titre, b2.Titre);
        }

        [Fact]
        public void Verif_ProprieteBloctextuel_Texte_Set()
        {
            BlocTextuel b = new BlocTextuel();
            BlocTextuel b1 = new BlocTextuel();
            BlocTextuel b2 = new BlocTextuel();

            b.Texte = "Nouveau texte...";
            b1.Texte = "        ";
            b2.Texte = null;

            Assert.Equal("Nouveau texte...", b.Texte);
            Assert.Equal(Bloc.placeholder_texte, b1.Texte);
            Assert.Equal(b1.Texte, b2.Texte);
        }
    }
}
