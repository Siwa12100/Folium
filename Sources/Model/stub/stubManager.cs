namespace Model.stub
{
    public class stubManager //: IdataManager
    {
        stubBlocGraphique stubBlocGraphique;
        stubBlocPolyvalent stubBlocPolyvalent;
        stubBlocTextuel stubBlocTextuel;
        stubProjet stubProjet;
        stubReseau stubReseau;
        stubParcours stubParcours;
        stubUtilisateur stubUtilisateur;

        public stubManager() 
        {
            stubBlocGraphique = new stubBlocGraphique();
            stubBlocPolyvalent = new stubBlocPolyvalent();
            stubBlocTextuel = new stubBlocTextuel();
            stubProjet = new stubProjet();
            stubReseau = new stubReseau();
            stubParcours = new stubParcours();
            stubUtilisateur = new stubUtilisateur();
        }
        
        public IEnumerable<Utilisateur> getUtilisateurs()
        {
            return stubUtilisateur.getUtilisateurs();
        }

        public IEnumerable<Parcours> getParcours()
        {
            return stubParcours.getParcours();
        }

        public IEnumerable<Reseau> getReseaux()
        {
            return stubReseau.getReseaux();
        }

        public IEnumerable<BlocPolyvalent> getBlocsPolyvalents()
        {
            return stubBlocPolyvalent.getBlocsPolyvalents();
        }


        public IEnumerable<BlocGraphique> getBlocsGraphiques()
        {
            return stubBlocGraphique.getBlocsGraphiques();
        }

        public IEnumerable<BlocTextuel> getBlocstextuels()
        {
            return stubBlocTextuel.getBlocsTextuels();
        }

        public IEnumerable<Projet> GetProjets(List<int> lIds)
        {
            List<Projet> AllProjets = stubProjet.getlProjets();

            List<Projet> lProjets = new List<Projet>();

            foreach ( Projet p in AllProjets)
            {
                if (lIds.Contains(p.Identifiant))
                {
                    lProjets.Add(p);
                }
            }

            return lProjets;
        }

        public Projet GetProjet(int Id)
        {
            List<Projet> AllProjets = stubProjet.getlProjets();


            foreach (Projet p in AllProjets)
            {
                if (p.Identifiant == Id)
                {
                    return p;
                }
            }

            return null;
        }

        public IEnumerable<Projet> GetAllProjets()
        {
            List<Projet> lprojets= stubProjet.getlProjets();

            return lprojets; 
        }

        //public void CreateProjet(Projet p)
        //{
        //    stubProjet.AjouterProjet(p);
        //}

        //public void CreateProjets(List<Projet> lprojets)
        //{
        //    stubProjet.AjouterProjets(lprojets);
        //}

        public IEnumerable<Projet> DeleteProjet(int Id)
        {
            List<Projet> AllProjets = stubProjet.getlProjets();

            foreach (Projet p in AllProjets)
            {
                if (p.Identifiant == Id)
                {
                    AllProjets.Remove(p);

                    return AllProjets;
                }
            }

            return AllProjets;
        }
    }
}
