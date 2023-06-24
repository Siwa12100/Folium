using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.stub
{
    public class stubBlocTextuel
    {
        private List<BlocTextuel> lBlocstextuels;

        public List<BlocTextuel> getlBlocstextuels()
        {
            return lBlocstextuels;
        }

        public IEnumerable<BlocTextuel> getBlocsTextuels()
        {
            List<BlocTextuel> lBlocsTextuels = new List<BlocTextuel>();

            BlocTextuel b1 = new BlocTextuel();
            b1.Titre = "Introduction";
            b1.Texte = "Chers passionnés de science-fiction,\r\n\r\nC'est " +
                    "avec une excitation débordante que je me tiens devant" +
                    " vous pour vous révéler le récit fascinant de la création " +
                    "de mon propre sabre laser. Plongez avec moi dans les méan" +
                    "dres de l'ingénierie et de l'imagination, où la science r" +
                    "encontre la magie de l'univers étendu.";

            BlocTextuel b2 = new BlocTextuel();
            b2.Titre = "Premiere partie";
            b2.Texte = "Tout a commencé par l'étude minutieuse des conceptions " +
                            "et des techniques des anciens maîtres Jedi. J'ai exploré de" +
                            "s textes anciens et des archives intergalactiques, découv" +
                            "rant les secrets bien gardés de la fabrication de cet ar" +
                            "me légendaire. Chaque détail, chaque composant avait so" +
                            "n importance, car j'aspirais à créer une lame à la fois" +
                            " puissante et élégante.";

            BlocTextuel b3 = new BlocTextuel();
            b3.Titre = "Seconde partie";
            b3.Texte = "Le processus de création a débuté par la sélection des" +
                    " cristaux kyber, ces gemmes mystiques qui confèrent au sabre " +
                    "laser sa puissance et sa couleur distincte. Avec une patienc" +
                    "e infinie, j'ai étudié les propriétés uniques de chaque cris" +
                    "tal, cherchant celui qui résonnerait le mieux avec ma force " +
                    "intérieure.\r\n\r\nEnsuite, dans mon atelier, j'ai façonné " +
                    "méticuleusement le manche du sabre laser. J'ai choisi des m" +
                    "atériaux solides et légers, alliant fonctionnalité et esthé" +
                    "tique. Chaque courbe, chaque texture était le fruit d'une r" +
                    "éflexion minutieuse, visant à créer un prolongement parfai" +
                    "t de ma volonté.";

            BlocTextuel b4 = new BlocTextuel();
            b4.Titre = "Troisième partie";
            b4.Texte = "Enfin, vint le moment tant attendu, celui où j'ai asse" +
                "mblé les pièces, intégré le cristal kyber et insufflé la vie" +
                " à mon sabre laser. Lorsque j'ai activé l'interrupteur, un " +
                "faisceau de lumière éclatante jaillit de la poignée, vibr" +
                "ant avec une énergie puissante. Je ressentis un mélange i" +
                "ndescriptible d'émotion et de satisfaction, sachant que j" +
                "'avais créé un véritable symbole de mon engagement env" +
                "ers la Force.\r\n\r\nMon sabre laser devint alors une e" +
                "xtension de moi-même, une arme de défense, mais aussi " +
                "un rappel constant de la responsabilité qui accompagne" +
                " le pouvoir. ";

            BlocTextuel b5 = new BlocTextuel();
            b5.Titre = "Conclusion";
            b5.Texte = "Enfin, vint le moment tant attendu, celui où" +
                " j'ai assemblé les pièces, intégré le cristal ky" +
                "ber et insufflé la vie à mon sabre laser. Lorsque" +
                " j'ai activé l'interrupteur, un faisceau de lumiè" +
                "re éclatante jaillit de la poignée, vibrant avec" +
                " une énergie puissante. Je ressentis un mélange" +
                " indescriptible d'émotion et de satisfaction," +
                " sachant que j'avais créé un véritable symbo" +
                "le de mon engagement envers la Force.\r\n\r\nMon " +
                "sabre laser devint alors une extension de" +
                " moi-même, une arme de défense, mais auss" +
                "i un rappel constant de la responsabilité" +
                " qui accompagne le pouvoir. ";

            lBlocsTextuels.Add(b1);
            lBlocsTextuels.Add(b2);
            lBlocsTextuels.Add(b3);
            lBlocsTextuels.Add(b4);
            lBlocsTextuels.Add(b5);

            return lBlocsTextuels;
        }

        public stubBlocTextuel()
        {
            lBlocstextuels = getBlocsTextuels().ToList();
        }
    }
}
