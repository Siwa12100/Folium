using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// L'Enum mode permet de spécifier le thème de l'application 
    /// </summary>
    public enum Mode
    {
        Clair,
        Sombre
    }

    [DataContract (Name = "application")]
    public class Application
    {
        [DataMember]
        // Mode clair / Sombre de l'application 
        private Mode mode;
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        [DataMember]
        //Chemin vers le logo de l'application 
        private string logo;
        public string Logo
        {
            get
            {
                return logo;
            }
            
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    logo = "Pas de logo pour l'application...";
                }
                else
                {
                    logo = value;
                }
            }
        }

        public override string ToString()
        {
            return $" - Mode : {this.Mode} \n - Logo : {this.Logo}";
        }

        public Application()
        {
            mode = Mode.Clair;
            logo = " Pas de logo de pour l'application...";
        }
    }
}
