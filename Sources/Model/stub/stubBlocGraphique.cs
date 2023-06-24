using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubBlocGraphique
    {
        private List<BlocGraphique> lBlocsgraphiques = new List<BlocGraphique>();

        public List<BlocGraphique> getBlocsGraphiques()
        {
            return lBlocsgraphiques;
        }


        public IEnumerable<BlocGraphique> GetBlocsGraphiques()
        {
            List<BlocGraphique> lBlocsgraphiques = new List<BlocGraphique>();

            BlocGraphique b1 = new BlocGraphique();
            b1.Titre1 = "Les flammes";
            b1.Image1 = "art1.jpg";
            b1.Titre2 = "Les mains d'eau";
            b1.Image2 = "art2.jpg";

            BlocGraphique b2 =  new BlocGraphique();
            b2.Titre1 = "Etincelles";
            b2.Image1 = "art3.jpg";
            b2.Titre2 = "Fraiser";
            b2.Image2 = "art4.jpg";

            BlocGraphique b3 = new BlocGraphique();
            b3.Titre1 = "Tâches noires";
            b3.Image1 = "art5.jpg";
            b3.Titre2 = "Aube";
            b3.Image2 = "art6.jpg";

            lBlocsgraphiques.Add(b1);
            lBlocsgraphiques.Add(b2);
            lBlocsgraphiques.Add(b3);

            return lBlocsgraphiques;
        }

        public stubBlocGraphique()
        {
            lBlocsgraphiques = GetBlocsGraphiques().ToList();
        }
    }
}
