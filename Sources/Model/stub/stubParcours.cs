using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubParcours
    {
        private List<Parcours> lParcours;

        public List<Parcours> getParcours()
        {
            return lParcours;
        }

        private IEnumerable<Parcours> GetParcours()
        {
            List<Parcours> liste = new List<Parcours>();

            Parcours p1 = new Parcours();
            p1.Titre = "Stage d'observation";
            p1.Date = new DateTime(2016, 5, 23);
            p1.Ville = "St Jean du Bruel";
            p1.Departement = 12;
            p1.Type = typeParcours.Stage;
            p1.ajouterDetails("Decouverte de l'environnement professionnel");
            p1.ajouterDetails("Pas de rémunération");

            Parcours p2 = new Parcours();
            p2.Titre = "Serveur en salle";
            p2.Date = new DateTime(2020, 08, 12);
            p2.Ville = "St Geniez d'Olt";
            p2.Type = typeParcours.Entreprise;
            p2.Departement = 12;
            p2.ajouterDetails("Serveur au café du pont");
            p2.ajouterDetails("Expérience très enrichissante");

            Parcours p3 = new Parcours();
            p3.Date = new DateTime(2021, 09, 10);
            p3.Titre = "Creation du serveur Isildur";
            p3.Type = typeParcours.Benevolat;
            p3.Departement = 45;
            p3.ajouterDetails("Thème Nordique");
            p3.ajouterDetails("Durée de 1 an");
            p3.ajouterDetails("Une centaine de joueurs uniques");

            liste.Add(p1);
            liste.Add(p2);
            liste.Add(p3);

            return liste;
        }

        public stubParcours()
        {
            lParcours = GetParcours().ToList();
        }
    }
}
