using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.Runtime.Serialization;
using Model.stub;
using System.Diagnostics;

namespace Model.serializer
{
    public class xmlSerialiser : IDataManager
    {
        private string path;
        public List<BlocTextuel> ChargementBlocsTextuels()
        {
            List<BlocTextuel> liste = new List<BlocTextuel>();

            var serializer = new DataContractSerializer(typeof(List<BlocTextuel>));
            string xmlFile = "BlocsTextuels.xml";

            using (Stream s = File.OpenRead(xmlFile))
            {
                liste = serializer.ReadObject(s) as List<BlocTextuel>;
            }

            return liste;
        }

        public List<BlocGraphique> ChargementBlocsGraphiques()
        {
            List<BlocGraphique> liste = new List<BlocGraphique>();

            var serializer = new DataContractSerializer(typeof(List<BlocGraphique>));
            string xmlFile = "BlocsGraphiques.xml";

            using (Stream s = File.OpenRead(xmlFile))
            {
                liste = serializer.ReadObject(s) as List<BlocGraphique>;
            }

            return liste;
        }

        public List<BlocPolyvalent> ChargementBlocsPolyvalents()
        {
            List<BlocPolyvalent> liste = new List<BlocPolyvalent>();

            var serializer = new DataContractSerializer(typeof(List<BlocPolyvalent>));
            string xmlFile = "BlocsPolyvalents.xml";

            using (Stream s = File.OpenRead(xmlFile))
            {
                liste = serializer.ReadObject(s) as List<BlocPolyvalent>;
            }

            return liste;
        }

        public Utilisateur ChargementUtilisateur()
        {
            Utilisateur u = new Utilisateur();
            stubManager stub = new stubManager();

            List<Type> typesConnus = new List<Type>()
            {
                typeof(Reseau),
                typeof(Parcours)
            };

            var serializer = new DataContractSerializer(typeof(Utilisateur), typesConnus);
            string xmlFile = "Utilisateur.xml";

            if (!File.Exists(xmlFile))
            {
                u = stub.getUtilisateurs().ToList()[0];
                return u;
            }

            using (Stream s = File.OpenRead(xmlFile))
            {
                u = serializer.ReadObject(s) as Utilisateur;
            }

            return u;
        }

        public List<Projet> ChargementProjets()
        {
            stubManager stub = new stubManager();
            string xmlFile = "Projets.xml";
            List<Projet> liste = new List<Projet>();

            if (!File.Exists(xmlFile))
            {
                liste = stub.GetAllProjets().ToList();
                return liste;
            }

            List<Type> typesConnus = new List<Type>()
            {
                typeof(BlocTextuel),
                typeof(BlocGraphique),
                typeof(BlocPolyvalent)
            };

            var serializer = new DataContractSerializer(typeof(List<Projet>), typesConnus);

            using (Stream s = File.OpenRead(xmlFile))
            {
                liste = serializer.ReadObject(s) as List<Projet>;
            }

            return liste;
        }

        public Application ChargementApplication()
        {
            Application a = new Application();
            stubManager stub = new stubManager();

            List<Type> typesConnus = new List<Type>()
            {
                typeof(Mode)
            };

            var serializer = new DataContractSerializer(typeof(Application), typesConnus);
            string xmlFile = "Application.xml";

            if (!File.Exists(xmlFile))
            {
                a.Mode = Mode.Sombre;
                a.Logo = "Chemin vers le logo";
                return a;
            }

            using (Stream s = File.OpenRead(xmlFile))
            {
                a = serializer.ReadObject(s) as Application;
            }

            return a;
        }

        public void EnregistrementBlocsTextuels(List<BlocTextuel> liste)
        {
            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(List<BlocTextuel>));
            string xmlFile = "BlocsTextuels.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, liste);
                }
            }
        }  

        public void EnregistrementBlocsGraphiques(List<BlocGraphique> liste)
        {
            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(List<BlocGraphique>));
            string xmlFile = "BlocsGraphiques.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, liste);
                }
            }
        }

        public void EnregistrementBlocsPolyvalents(List<BlocPolyvalent> liste)
        {
            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(List<BlocPolyvalent>));
            string xmlFile = "BlocsPolyvalents.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, liste);
                }
            }
        }

        public void EnregistrementProjets(List<Projet> liste)
        {
            List<Type> typesConnus = new List<Type>()
            {
                typeof(BlocTextuel),
                typeof(BlocGraphique),
                typeof(BlocPolyvalent)
            };


            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(List<Projet>), typesConnus);
            string xmlFile = "Projets.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, liste);
                }
            }
        }

        public void EnregistrementUtilisateur(Utilisateur u)
        {
            List<Type> typesConnus = new List<Type>()
            {
                typeof(Reseau),
                typeof(Parcours)
            };


            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(Utilisateur), typesConnus);
            string xmlFile = "Utilisateur.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, u);
                }
            }
        }

        public void EnregistrementApplication(Application a)
        {
            List<Type> typesConnus = new List<Type>()
            {
                typeof(Mode)
            };


            Directory.SetCurrentDirectory(Path.Combine(this.path, "."));
            var serializer = new DataContractSerializer(typeof(Application), typesConnus);
            string xmlFile = "Application.xml";

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(xmlFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, a);
                }
            }
        }

        public xmlSerialiser(string path)
        {
            this.path = path;
        }
    }
}
