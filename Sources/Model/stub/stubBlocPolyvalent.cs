using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubBlocPolyvalent
    {
        private List<BlocPolyvalent> lBlocspolyvalents;

        public List<BlocPolyvalent> getBlocsPolyvalents()
        {
            return this.lBlocspolyvalents;
        }


        public IEnumerable<BlocPolyvalent> GetBlocsPolyvalents()
        {
            List<BlocPolyvalent> lBlocsPolyvalents = new List<BlocPolyvalent>();

            BlocPolyvalent b1 = new BlocPolyvalent();
            b1.Titre = "Mon site Internet";
            b1.Image = "Lien vers l'image illustrant le site";
            b1.Texte = "Voici la présentation de la page principale de mon site internet";

            BlocPolyvalent b2  = new BlocPolyvalent();
            b2.Titre = "Presentation de ma BDD";
            b2.Image = " Lien vers un modèle de données";
            b2.Texte = "Voici la gestion de ma base de données";

            BlocPolyvalent b3 = new BlocPolyvalent();
            b3.Titre = "Mon voyage en Asie";
            b3.Image = "Lien vers une image de l'Asie";
            b3.Texte = "Presentation de mon voyage en Asie...";

            lBlocsPolyvalents.Add(b1);
            lBlocsPolyvalents.Add(b2);
            lBlocsPolyvalents.Add(b3);

            return lBlocsPolyvalents;
        }

        public stubBlocPolyvalent()
        {
            lBlocspolyvalents = GetBlocsPolyvalents().ToList();
        }
            


    }
}
