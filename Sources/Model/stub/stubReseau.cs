using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubReseau
    {
        private List<Reseau> lReseaux;

        public List<Reseau> getReseaux()
        {
            return lReseaux;
        }

        private IEnumerable<Reseau> GetReseaux()
        {
            List<Reseau> liste = new List<Reseau>();

            Reseau r1 = new Reseau(1, "https://fr-fr.facebook.com/", typeReseaux.Facebook);

            Reseau r2 = new Reseau(2, "https://twitter.com/home", typeReseaux.Twitter);

            Reseau r3 = new Reseau(3, "https://www.youtube.com/", typeReseaux.Youtube);

            Reseau r4 = new Reseau(4, "https://github.com/", typeReseaux.GitHub);

            liste.Add(r1);
            liste.Add(r2);
            liste.Add(r3);
            liste.Add(r4);

            return liste;
        }

        public stubReseau()
        {
            lReseaux = GetReseaux().ToList();
        }
    }
}
