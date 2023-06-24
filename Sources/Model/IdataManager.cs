using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// token ultra caché : 
// squ_01119177c7cead619e96aa79537bafe181123382
namespace Model
{
    /// <summary>
    /// Interface qui gère la gestion des données au sein de l'application. Elle est implémentée 
    /// par le xmlSerialiser et le stubManager 
    /// </summary>
    public interface IDataManager
    {
        // Renvoie un utilisateur 
        public Utilisateur ChargementUtilisateur();

        // Sauvegarde un utilisateur 
        public void EnregistrementUtilisateur(Utilisateur u);

        // Permet de charger les différents projets du programme 
        public List<Projet> ChargementProjets();

        // Permet d'enregistrer les différents projets du programme 
        public void EnregistrementProjets(List<Projet> liste);

        // Permet de charger les différents paramètres de l'application
        public Application ChargementApplication();

        // Permet d'enregistrer les différents paramètres de l'application
        public void EnregistrementApplication(Application a);
    }
}
