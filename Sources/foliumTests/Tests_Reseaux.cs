using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace foliumTests
{
    public class Tests_Reseaux
    {
        [Fact]
        public void Verif_Reseau_Non_Null()
        {
            Reseau r = new Reseau(3, "Lien", typeReseaux.Facebook);
            Assert.NotNull(r);
        }

        [Fact]
        public void Verif_ProprieteReseau_Lien_Non_Null()
        {
            Reseau r = new Reseau(3, "Lien", typeReseaux.Facebook);
            Assert.NotNull(r.Lien);
        }

        [Fact]
        public void Verif_ProprieteReseau_Logo_Non_Null()
        {
            Reseau r = new Reseau(3, "Lien", typeReseaux.Facebook);
            Assert.True(Enum.IsDefined(typeof(typeReseaux), r.Type));
        }

        [Fact]
        public void Verif_ProprieteReseau_Lien_Identifiant_Null()
        {
            Reseau r = new Reseau(3, "Lien", typeReseaux.Facebook);
            Assert.Equal(3, r.Identifiant);
        }

        [Fact]
        public void Verif_ProprieteReseau_Lien_Set()
        {
            Reseau r = new Reseau(4, "Lien", typeReseaux.Facebook);
            Reseau r1 = new Reseau(5, "Lien1", typeReseaux.Facebook);
            Reseau r2 = new Reseau(1, "Lien2", typeReseaux.Facebook);

            r1.Lien = "         ";
            r2.Lien = null;
            r.Lien = "Nouveau Lien";

            Assert.Equal("Nouveau Lien", r.Lien);
            Assert.Equal("Lien vide...", r1.Lien);
            Assert.Equal(r1.Lien, r2.Lien);
        }

        [Fact]
        public void Verif_ProprieteReseau_Logo_Set()
        {
            Reseau r = new Reseau(4, "Lien", typeReseaux.Facebook);
            //Reseau r1 = new Reseau(5, "Lien1", typeReseaux.Facebook);
            //Reseau r2 = new Reseau(1, "Lien2", typeReseaux.Facebook);

            r.Type = typeReseaux.Youtube;

            Assert.Equal(typeReseaux.Youtube, r.Type);
        }

        [Fact]
        public void Verif_ProprieteReseau_Identifiant_Set()
        {
            Reseau r = new Reseau(4, "Lien", typeReseaux.Facebook);
            r.Identifiant = 5;
            Assert.Equal(5, r.Identifiant);
        }
    }
}
