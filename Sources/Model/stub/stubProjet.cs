using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubProjet
    {
        private stubBlocGraphique stubBlocGraphique;
        private stubBlocPolyvalent stubBlocPolyvalent;
        private stubBlocTextuel stubBlocTextuel;

        private List<Projet> lProjets;

        public List<Projet> getlProjets()
        {
            return this.lProjets;
        }

        public IEnumerable<Projet> GetProjets()
        {
            List<Projet>  lProjets = new List<Projet>();
;


            Projet p1 = new Projet(1, typeProjet.Polyvalent);
            p1.Nom = "Mon voyage au Japon";
            p1.Description = "Je suis ravi de partager avec vous les " +
                            "merveilleuses aventures de mon voyage au Japon. Depuis " +
                            "le moment où j'ai posé les pieds sur ce sol mystique," +
                            " j'ai été immergé dans une culture vibrante et captivante. ";


            p1.Image_principale = "japon1.jpg";

            BlocPolyvalent bp1 = new BlocPolyvalent();
            bp1.Texte = "Chers amis du voyage,\r\n\r\n" +
                        "Je suis rempli d'excitation et d'anticipation " +
                        "à l'idée de vous narrer les débuts de mon aventure " +
                        "incroyable au Japon. Mon périple a commencé dans " +
                        "l'effervescence de Tokyo, la capitale dynamique et " +
                        "moderne qui m'a accueilli à bras ouverts. Les lumières" +
                        " chatoyantes et les gratte-ciel vertigineux ont " +
                        "instantanément transporté mes sens dans un autre monde," +
                        " où tradition et modernité se marient harmonieusement.";

            bp1.Titre = "Un voyage formidable !";
            bp1.Image = "japon5.png";

            BlocPolyvalent bp2 = new BlocPolyvalent();
            bp2.Texte = "En me promenant dans les ruelles animées de Shibuya," +
                        " j'ai été fasciné par la foule multicolore et l'énergie " +
                        "électrisante qui émanait de cette métropole en perpétuel mouvement." +
                        " J'ai découvert des sanctuaires cachés au cœur de la ville," +
                        " où j'ai pu ressentir la spiritualité profonde qui imprègne " +
                        "la vie quotidienne des Japonais.";

            bp2.Titre = "Une  ambiance magique ! ";
            bp2.Image = "japon3.jpeg";

            BlocPolyvalent bp3 = new BlocPolyvalent();
            bp3.Texte = "Ma curiosité m'a ensuite mené vers Kyoto," +
                        " l'ancienne capitale impériale. Cette ville" +
                        " empreinte de tradition et de sérénité m'a " +
                        "plongé dans une atmosphère envoûtante. J'ai été" +
                        " émerveillé par les temples majestueux et les " +
                        "jardins zen qui m'ont invité à la contemplation et" +
                        " à l'introspection. Chaque pas que j'ai fait dans " +
                        "les allées pavées m'a ramené des siècles en arrière," +
                        " au cœur d'une culture millénaire.\r\n\r\nMais " +
                        "mon voyage ne s'est pas arrêté là. La prochaine " +
                        "étape de mon itinéraire m'a conduit à Hiroshima, " +
                        "un lieu emblématique chargé d'histoire et de mémoire. ";

            bp3.Titre = "Un pays chargé d'Histoire...";
            bp3.Image = "japon2.jpg";

            BlocPolyvalent bp4 = new BlocPolyvalent();
            bp4.Texte = "En visitant le mémorial de la paix et en" +
                        " écoutant les récits émouvants des survivants, " +
                        "j'ai été témoin de la force et de la résilience" +
                        " du peuple japonais. C'était un rappel poignant " +
                        "de l'importance de préserver la paix dans le " +
                        "monde.\r\n\r\nLe Japon est un pays qui m'a ensorcelé " +
                        "dès les premiers instants, et je suis impatient de" +
                        " vous dévoiler la suite de cette aventure extraordinaire." +
                        " Restez connectés, car il y a encore" +
                        " tant de merveilles à explorer !";

            bp4.Titre = "Une ambiance à couper le souffle...";
            bp4.Image = "japon4.jpg";

            p1.ajouterBloc(bp1);
            p1.ajouterBloc(bp2);
            p1.ajouterBloc(bp3);
            p1.ajouterBloc(bp4);


            Projet p2 = new Projet(2, typeProjet.Graphique);
            p2.Nom = "Voyage à travers mes tableaux";
            p2.Image_principale = "art7.jpg";
            p2.Description = "Il me fait un immense plaisir de vous ouvrir " +
                            "les portes de mon univers créatif et de vous inviter à " +
                            "explorer mes différentes peintures, chacune étant un fragment" +
                            " de mon imagination. À travers mes pinceaux, je donne vie à " +
                            "des paysages colorés, des personnages intrigants et des" +
                            " émotions qui se déploient sur la toile.";

            foreach (Bloc b in stubBlocGraphique.getBlocsGraphiques())
            {
                p2.ajouterBloc(b);
            }


            Projet p3 = new Projet(3, typeProjet.Textuel);
            p3.Nom = "Construction de mon sabre laser";
            p3.Image_principale = "sabre1.jpeg";

            foreach (Bloc b in stubBlocTextuel.getlBlocstextuels())
            {
                p3.ajouterBloc(b);
            }

            lProjets.Add(p1);
            lProjets.Add(p2);   
            lProjets.Add(p3);

            return lProjets;
        }

        public stubProjet()
        {
            stubBlocGraphique = new stubBlocGraphique();
            stubBlocPolyvalent = new stubBlocPolyvalent();  
            stubBlocTextuel = new stubBlocTextuel();

            lProjets = GetProjets().ToList();
        }
    }
}
