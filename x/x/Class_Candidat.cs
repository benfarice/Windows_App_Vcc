using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace x
{
    class Class_Candidat
    {
        public String Nom;
        public String Prenom;
        public Boolean genre;
        public DateTime date_naissace;
        public String cv_fileName;
        public String ville;
        public String quartier;
        public String cin;
        public String email;
        public Boolean vcc;
        public List<Class_telephone> Son_telephones = new List<Class_telephone>();
        public List<Class_sourcing> Son_sourcing = new List<Class_sourcing>();
        public List<Class_emploi_metier> son_emplois_metiers = new List<Class_emploi_metier>();
        public List<Class_ateliers> son_ateliers = new List<Class_ateliers>();
        public List<Class_langage> son_langages = new List<Class_langage>();
        public List<Class_diplome> son_diplomes = new List<Class_diplome>();
        public List<Class_bac> son_bac = new List<Class_bac>();
        public List<Class_experience> ses_experiences = new List<Class_experience>();
        public List<Class_niveau_bac> ses_niveau_bac = new List<Class_niveau_bac>();

    }
}
