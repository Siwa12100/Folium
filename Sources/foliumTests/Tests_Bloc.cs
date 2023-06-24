using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace foliumTests
{
    public class Tests_Bloc
    {
        [Fact]
        public void Verif_Bloc_Non_Null()
        {
            Bloc b = new Bloc();
            Assert.NotNull(b);
        }

        [Fact]
        public void Verif_ProprieteBloc_Identifiant_Non_Set()
        {
            Bloc b = new Bloc();
            b.Identifiant = 6;
            Assert.Equal(6, b.Identifiant);
        }
    }
}
