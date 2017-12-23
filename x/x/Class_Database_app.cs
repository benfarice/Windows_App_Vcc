using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace x
{
    class Class_Database_app
    {
        
        public static SqlConnection connection_x = new SqlConnection("Data Source=youssef\\SQLEXPRESS;Initial Catalog=imzoughene;Integrated Security=True");
        public static DataTable get_INFOS_to_contact(ArrayList y)
        {
            try
            {
                if (connection_x.State != ConnectionState.Open)
                connection_x.Open();
                string in_ = "(";
                foreach (int i in y)
                    in_ += i+",";
                in_ += "1)";
                string query = "select  c.CIN,c.Nom,c.Prenom,c.Email,t.Numero from Candidat c  inner join Telephone t on c.ID = t.ID_candidat where ID in "+in_;
                SqlCommand command1 = new SqlCommand(query, connection_x);
                SqlDataReader reader1;
                reader1 = command1.ExecuteReader();
                DataTable t1 = new DataTable();
                t1.Load(reader1);
                reader1.Close();
                connection_x.Close();
                return t1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public static DataTable view_sourcing_by_date(DateTime x)
        {
            try
            {
                connection_x.Open();
                string query = "select s.Entreprise,s.poste,c.Nom,c.Prenom,s.resultat from sourcing s inner join Candidat c on c.ID=s.ID_candidat where s.date_soorcing = '" + x + "'";
                SqlCommand command2 = new SqlCommand(query, connection_x);
                SqlDataReader reader2;
                reader2 = command2.ExecuteReader();
                DataTable t2 = new DataTable();
                t2.Load(reader2);
                reader2.Close();
                connection_x.Close();
                return t2;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public static ArrayList get_ALL_emails()
        {
            ArrayList x = new ArrayList();
            try
            {
                connection_x.Open();
                string query = "select c.Email from Candidat c";
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader;
                reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    string mail;
                    mail = reader[0].ToString();
                    if(IsValidEmail(mail)==true)
                    x.Add(mail);
                }

                connection_x.Close();
                return x;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //public static ArrayList get_ALL_emails()
        //{
        //    ArrayList x = new ArrayList();
        //    try
        //    {
        //        connection_x.Open();
        //        string query = "select c.Email from Candidat c";
        //        SqlCommand command3 = new SqlCommand(query, connection_x);
        //        SqlDataReader reader;
        //        reader = command3.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            string mail;
        //            mail = reader[0].ToString();
        //            if (IsValidEmail(mail) == true)
        //                x.Add(mail);
        //        }

        //        connection_x.Close();
        //        return x;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //        return null;
        //    }
        //}
        public static void add_new_candidat()
        {
            if (Program.new_candidat_to_add.cv_fileName != null && Program.new_candidat_to_add.cv_fileName != "")
            {
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    FileStream fStream = File.OpenRead(Program.new_candidat_to_add.cv_fileName);
                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();
                    string query = "insert into Candidat(Nom,Prenom,Ville,Quartier,vcc,CIN,CV,DateNaissance,Email,Genre)";
                    query += "values('" +
                    Program.new_candidat_to_add.Nom
                        + "', '" +
                    Program.new_candidat_to_add.Prenom
                        + "', '" +
                    Program.new_candidat_to_add.ville
                        + "', '" +
                    Program.new_candidat_to_add.quartier
                        + "', '" +
                    Program.new_candidat_to_add.vcc.ToString()
                        + "', '" +
                    Program.new_candidat_to_add.cin
                        + "', @data, '" +
                    Program.new_candidat_to_add.date_naissace.ToString()
                    + "', '" +
                    Program.new_candidat_to_add.email.ToString()
                        + "', '" +
                    Program.new_candidat_to_add.genre.ToString()
                        + "')";

                    SqlCommand command_add = new SqlCommand(query, connection_x);
                    command_add.Parameters.Add("@data", contents);
                    int i = command_add.ExecuteNonQuery();
                    if (i != 0)
                        MessageBox.Show("okay");
                    connection_x.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    int y = 0;
                    foreach (Class_ateliers x in Program.new_candidat_to_add.son_ateliers)
                    {
                        string query = "insert into Atelier(ID_candidat,Date_Debut_atelier,Date_Fin_atelier,observation,theme)";
                        query += " values(dbo.getID('" + Program.new_candidat_to_add.Nom + "', '" +
                          Program.new_candidat_to_add.Prenom + "', '" + Program.new_candidat_to_add.date_naissace + "'), " +
                          "'" + x.date_debut + "', '" + x.date_Fin + "', '" + x.observation + "', '" + x.theme + "')";
                        //here you stop writing code
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        y += command5.ExecuteNonQuery();

                        //you stop writing code here dohhr
                    }
                    connection_x.Close();
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_bac v in Program.new_candidat_to_add.son_bac)
                    {
                        string query = "insert into baccalaureat(ID_candidat,annee_obtention,Type_)";
                        query += "  values(dbo.getID('" + Program.new_candidat_to_add.Nom + "'" +
                          ", '" + Program.new_candidat_to_add.Prenom + "', '" + Program.new_candidat_to_add.date_naissace + "')" +
                          ", " + v.annee_obtention + ", '" + v.Type + "')";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_diplome v in Program.new_candidat_to_add.son_diplomes)
                    {
                        string query = "insert into diplome(ID_candidat,Niveau,date_obtention,specialite,Etablissement)";
                         query+=" values(dbo.getID('"+Program.new_candidat_to_add.Nom
                             +"','"+Program.new_candidat_to_add.Prenom
                             +"','"+Program.new_candidat_to_add.date_naissace+"'),'"+
                             v.niveau+"',"+v.date_obtention+",'"+v.specialite+"','"+v.etablissement+"')";
                         SqlCommand command5 = new SqlCommand(query, connection_x);
                         command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_emploi_metier v in Program.new_candidat_to_add.son_emplois_metiers)
                    {
                        string query = "insert into emploi_metier(ID_candidat,emploi_metier)";
                        query += " values(dbo.getID('"+Program.new_candidat_to_add.Nom
                            +"','"+Program.new_candidat_to_add.Prenom
                            +"','"+Program.new_candidat_to_add.date_naissace+"'),'"+
                           v.emploi_metier +"')";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
               
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_experience v in Program.new_candidat_to_add.ses_experiences)
                    {
                        int x = 0;
                        if (v.enCours)
                            x = 1;
                        string query = "insert into experience(ID_candidat,Poste,Service_,entreprise,secteur_activite";
                        query+=",type_,ville,DateDebut,DateFin,Encours) values(dbo.getID('"+Program.new_candidat_to_add.Nom
                            +"','"+Program.new_candidat_to_add.Prenom+"','"+
                            Program.new_candidat_to_add.date_naissace+"'),";
                        query+="'"+v.poste+"','"+v.Service+"','"+v.entreprise
                            +"','"+v.secteur_activite+"','"+v.type+
                            "','"+v.ville+"','"+v.date_debut+"','"+v.date_fin+"',"+x+")";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_telephone v in Program.new_candidat_to_add.Son_telephones)
                    {
                 
                        string query = "insert into Telephone(ID_candidat,Numero)";
                        query+="values(dbo.getID('"+Program.new_candidat_to_add.Nom+"','"+
                        Program.new_candidat_to_add.Prenom+"','" + Program.new_candidat_to_add.date_naissace +
                            "'),"+v.numero+")";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_langage v in Program.new_candidat_to_add.son_langages)
                    {

                        string query = "insert into langues(ID_candidat,Niveau,langue)";
                               query +="values(dbo.getID('"+Program.new_candidat_to_add.Nom
                               +"','"+Program.new_candidat_to_add.Prenom+"','"+
                               Program.new_candidat_to_add.date_naissace  +"'),'"+v.niveau+"',";
                               query+="'"+v.langue+"')";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
                try
                {
                    if (connection_x.State != ConnectionState.Open)
                    {
                        connection_x.Open();
                    }
                    foreach (Class_niveau_bac v in Program.new_candidat_to_add.ses_niveau_bac)
                    {

                        string query = "insert into niveau_Bac(ID_candidat,Type_,annee)";
                            query+="values(dbo.getID('"+Program.new_candidat_to_add.Nom
                            +"','"+Program.new_candidat_to_add.Prenom+"','"+
                            Program.new_candidat_to_add.date_naissace+"'),";
                            query+="'"+v.type+"','"+v.annee+"')";
                        SqlCommand command5 = new SqlCommand(query, connection_x);
                        command5.ExecuteNonQuery();
                    }
                    connection_x.Close();
                    //you stoped writing code here
                    //you need to complete all candidat infos here for insert all tables in sqlserver
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.ToString());
                }
               
            }
               
            else {
                MessageBox.Show("cv obligatoire","cv",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public static ArrayList get_number_count_query(string query_count) {
            ArrayList myIds = new ArrayList();
            try
            {
                if(connection_x.State != ConnectionState.Open)
                connection_x.Open();
                SqlCommand myCountCommande = new SqlCommand(query_count,connection_x);
                SqlDataReader reader_count = myCountCommande.ExecuteReader();
                while (reader_count.Read())
                    myIds.Add((int)reader_count[0]);
                reader_count.Close();
            }
            catch (Exception t){
                MessageBox.Show(t.ToString());
            }
            return myIds;
        }
        public static Class_Candidat get_candidat_position_query(int query_position,string query_search)
        {
            Class_Candidat my_candidat_find = new Class_Candidat();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                query_search += " and c.ID =  " + query_position +" ";
                //MessageBox.Show(query_search);
                SqlCommand myCountCommande = new SqlCommand(query_search, connection_x);
                SqlDataReader reader_count = myCountCommande.ExecuteReader();
                if (reader_count.Read()) {
                   
                    my_candidat_find.cin = reader_count[0].ToString();
                    string genre = reader_count[1].ToString() ;
                    if (genre == "True" || genre == "true" )
                        my_candidat_find.genre = true;
                    else
                        my_candidat_find.genre = false;
                    DateTime naissance = (DateTime)reader_count[2];
                    my_candidat_find.date_naissace = naissance;
                    my_candidat_find.Nom = reader_count[3].ToString();
                    my_candidat_find.Prenom = reader_count[4].ToString();
                    string vcc = reader_count[5].ToString();
                    if (vcc == "True" || vcc == "true")
                        my_candidat_find.vcc = true;
                    else
                        my_candidat_find.vcc = false;
                    my_candidat_find.ville = reader_count[6].ToString();
                    my_candidat_find.quartier = reader_count[7].ToString();
                    my_candidat_find.email = reader_count[8].ToString();
                    byte[] fileData = (byte[])reader_count[9];
                    File.WriteAllBytes(@"imzoughene_youssef.pdf", fileData);
                   
                }
                reader_count.Close();
                   
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return my_candidat_find;
        }
        public static Boolean is_a_user(string u, string p) {
            Boolean x = false;
            try {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select COUNT(*) from application_users where username = '"+u+"' and pass_word = '"+p+"' ";
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int r = (int)command3.ExecuteScalar();
                if (r == 1)
                    x = true;
                connection_x.Close();
            }
            catch (Exception t) {
                MessageBox.Show(t.ToString());
            }
            return x;
        
        }
        public static ArrayList get_all_users()
        {
            ArrayList all_users = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select username from application_users ";
                SqlCommand command3 = new SqlCommand(query, connection_x);
                
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                    all_users.Add((string)reader[0]);
               
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return all_users;

        }
        public static Boolean add_application_user(string user, string pass) {
            Boolean resultat = false;
             try {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "insert into application_users(username,pass_word) values('"+user+"','"+pass+"')";
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int a = command3.ExecuteNonQuery();
                // MessageBox.Show(a.ToString());
                if (a == 1)
                    resultat = true;
                connection_x.Close();
             }
             catch (Exception t)
             {
                 MessageBox.Show(t.ToString());
             }
            return resultat;
        
        }
        public static Boolean update_password(string new_pass,string old_pass, string username) {
            Boolean is_updated = false;
             try {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                
                string query2 = "select COUNT(*) from application_users where username = '"+username+"' and pass_word = '"+old_pass+"' ";
                SqlCommand command4 = new SqlCommand(query2, connection_x);
                int r = (int)command4.ExecuteScalar();
                if (r == 1)
                {
                    string query = "update application_users set pass_word = '" + new_pass + "' where username ='" + username + "'";
                   // MessageBox.Show(query);
                    SqlCommand command3 = new SqlCommand(query, connection_x);
                    int a = command3.ExecuteNonQuery();
                   // MessageBox.Show(a.ToString());
                    if (a == 1)
                        is_updated = true;
                }
                else {
                    MessageBox.Show("old password is false");
                }
                connection_x.Close();
             }
             catch (Exception t)
             {
                 MessageBox.Show(t.ToString());
             }
            return is_updated;
        }
        public static ArrayList get_ids_to_update(string query_to_update) {
            ArrayList my_list = new ArrayList();
             try {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                SqlCommand command3 = new SqlCommand(query_to_update, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                    my_list.Add((int)reader[0]);
                connection_x.Close();
             }
             catch (Exception t)
             {
                 MessageBox.Show(t.ToString());
             }
            return my_list;
        
        }
        public static ArrayList get_ids_diploma_update(string query_to_update)
        {
            ArrayList my_list = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                SqlCommand command3 = new SqlCommand(query_to_update, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                    my_list.Add((int)reader[0]);
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return my_list;

        }
        public static Class_diplome get_diploma_by_id(int id_diploma)
        {
            Class_diplome diplome = new Class_diplome();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select d.Niveau,d.date_obtention,d.specialite,d.Etablissement from diplome d where d.ID_diplome = " + id_diploma;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    diplome.niveau = reader[0].ToString();
                    diplome.date_obtention = (int)reader[1];
                    diplome.specialite = reader[2].ToString();
                    diplome.etablissement = reader[3].ToString();
                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return diplome;

        }
        public static ArrayList get_diploma_ids_by_id_candidat(int id_candidat)
        {
            ArrayList diploma_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select ID_diplome from diplome where ID_candidat =  " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    diploma_ids.Add((int)reader[0]);
                   
                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return diploma_ids;

        }
        public static ArrayList get_bac_ids_by_id_candidat(int id_candidat)
        {
            ArrayList bac_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select b.ID_bac from baccalaureat b where b.ID_candidat =  " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    bac_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return bac_ids;

        }
        public static ArrayList get_niveau_bac_ids_by_id_candidat(int id_candidat)
        {
            ArrayList bac_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select n.ID_niveau_Bac from niveau_Bac n where n.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    bac_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return bac_ids;

        }
        public static ArrayList get_telephone_ids_by_id_candidat(int id_candidat)
        {
            ArrayList tel_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select t.ID_tel from Telephone t where t.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    tel_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return tel_ids;

        }
        public static ArrayList get_emploi_metier_ids_by_id_candidat(int id_candidat)
        {
            ArrayList emploi_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select m.ID_emploi_metier from emploi_metier m where m.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    emploi_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return emploi_ids;

        }
        public static ArrayList get_experience_ids_by_id_candidat(int id_candidat)
        {
            ArrayList experience_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select x.ID_experience from experience x where x.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    experience_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return experience_ids;

        }
        public static ArrayList get_ateliers_ids_by_id_candidat(int id_candidat)
        {
            ArrayList ateliers_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select t.ID_Atelier from Atelier t where t.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    ateliers_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return ateliers_ids;

        }
        public static ArrayList get_langues_by_id_candidat(int id_candidat)
        {
            ArrayList langues_ids = new ArrayList();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select l.ID_langue from langues l where l.ID_candidat = " + id_candidat;
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    langues_ids.Add((int)reader[0]);

                }
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return langues_ids;

        }
        public static Class_Candidat get_candidate_by_id(int id)
        {
            Class_Candidat candidat = new Class_Candidat();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select c.CIN,c.Genre,c.Nom,c.Prenom,c.DateNaissance,c.Ville,c.Quartier,c.Email,c.vcc from Candidat c where c.ID = ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read()) {
                    candidat.cin = reader[0].ToString();
                    string genre = reader[1].ToString();
                    if (genre == "True" || genre == "true")
                        candidat.genre = true;
                    else
                        candidat.genre = false;
                    candidat.Nom = reader[2].ToString();
                    candidat.Prenom = reader[3].ToString();
                    candidat.date_naissace = (DateTime)reader[4];
                    candidat.ville = reader[5].ToString();
                    candidat.quartier = reader[6].ToString();
                    candidat.email = reader[7].ToString();
                    string vcc = reader[8].ToString();
                    if (vcc == "True" || vcc == "true")
                        candidat.vcc = true;
                    else
                        candidat.vcc = false;
                }
                   
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return candidat;

        }
        public static Class_bac get_bac_by_id(int id)
        {
            Class_bac bac = new Class_bac();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select b.Type_,b.annee_obtention from baccalaureat b where b.ID_bac = ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    bac.Type = reader[0].ToString();
                    bac.annee_obtention = (int)reader[1];
                   
                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return bac;

        }
        public static Class_niveau_bac get_niveau_bac_by_id(int id)
        {
            Class_niveau_bac bac = new Class_niveau_bac();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select n.Type_,n.Niveau from niveau_Bac n where n.ID_niveau_Bac =  ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    bac.type= reader[0].ToString();
                    bac.annee = reader[1].ToString();

                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return bac;

        }
        public static Class_telephone get_telephone_by_id(int id)
        {
            Class_telephone tel = new Class_telephone();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select t.Numero from Telephone t where t.ID_tel =  ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    tel.numero = (int)reader[0];
                    

                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return tel;

        }
        public static Class_emploi_metier get_emploi_metier_by_id(int id)
        {
            Class_emploi_metier emploi = new Class_emploi_metier();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select m.emploi_metier from emploi_metier m where m.ID_emploi_metier =  ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    emploi.emploi_metier = reader[0].ToString();


                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return emploi;

        }
        public static Class_experience get_experience_by_id(int id)
        {
            Class_experience experience = new Class_experience();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select x.DateDebut,x.DateFin,x.Encours,x.entreprise,x.Poste,x.secteur_activite,x.Service_,x.type_,x.ville from experience x where x.ID_experience = ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    experience.date_debut = (DateTime)reader[0];
                    experience.date_fin = (DateTime)reader[1];
                    int x = (int)reader[2];
                    if (x == 0)
                        experience.enCours = false;
                    else
                        experience.enCours = true;
                    experience.entreprise = reader[3].ToString();
                    experience.poste = reader[4].ToString();
                    experience.secteur_activite = reader[5].ToString();
                    experience.Service = reader[6].ToString();
                    experience.type = reader[7].ToString();
                    experience.ville = reader[8].ToString();
                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return experience;

        }
        public static Class_ateliers get_atelier_by_id(int id)
        {
            Class_ateliers atelier = new Class_ateliers();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select t.Date_Debut_atelier,t.Date_Fin_atelier,t.observation,t.theme from Atelier t where t.ID_Atelier = ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    atelier.date_debut= (DateTime)reader[0];
                    atelier.date_Fin = (DateTime)reader[1];
                  
                    atelier.observation = reader[2].ToString();
                    atelier.theme = reader[4].ToString();
                   
                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return atelier;

        }
        public static Class_langage get_langue_by_id(int id)
        {
            Class_langage langue = new Class_langage();
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "select l.langue,l.Niveau from langues l where l.ID_langue = ";
                query += id.ToString();
                SqlCommand command3 = new SqlCommand(query, connection_x);
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    langue.langue = reader[0].ToString();
                    langue.niveau= reader[1].ToString();

                   
                }

                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return langue;

        }
        
        public static Boolean delete_a_candidat(int id) {
            Boolean is_deleted = false;
            try{
            if (connection_x.State != ConnectionState.Open)
                connection_x.Open();
            string query = "delete from Candidat where ID = "+id.ToString();
            //MessageBox.Show(query);
            SqlCommand command3 = new SqlCommand(query, connection_x);
            int x = command3.ExecuteNonQuery();
            //MessageBox.Show(x.ToString());
            if (x > 0)
                is_deleted = true;
            connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return is_deleted;
        
        }
        public static Boolean delete_a_user(string username)
        {
            Boolean is_deleted = false;
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                string query = "delete from application_users where username = '"+username+"'";
                //MessageBox.Show(query);
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int x = command3.ExecuteNonQuery();
                //MessageBox.Show(x.ToString());
                if (x > 0)
                    is_deleted = true;
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return is_deleted;

        }
        public static Boolean update_candidat_infos(string query)
        {
            Boolean is_updated = false;
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();
                
                //MessageBox.Show(query);
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int x = command3.ExecuteNonQuery();
                //MessageBox.Show(x.ToString());
                if (x > 0)
                    is_updated = true;
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return is_updated;

        }
        public static Boolean update_diplome_infos(string query)
        {
            Boolean is_updated = false;
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();

                //MessageBox.Show(query);
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int x = command3.ExecuteNonQuery();
                //MessageBox.Show(x.ToString());
                if (x > 0)
                    is_updated = true;
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return is_updated;

        }
        public static Boolean add_sourcing(string query)
        {
            Boolean is_saved = false;
            try
            {
                if (connection_x.State != ConnectionState.Open)
                    connection_x.Open();

                
                SqlCommand command3 = new SqlCommand(query, connection_x);
                int x = command3.ExecuteNonQuery();
               
                if (x > 0)
                    is_saved = true;
                connection_x.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.ToString());
            }
            return is_saved;

        }
        public static void add_data(string query) {
            
            try
            {
                if (connection_x.State != ConnectionState.Open)
                {
                    connection_x.Open();
                }
              
                    
               SqlCommand command5 = new SqlCommand(query, connection_x);
               command5.ExecuteNonQuery();
                
                connection_x.Close();
                //you stoped writing code here
                //you need to complete all candidat infos here for insert all tables in sqlserver
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
        }
    }
}
