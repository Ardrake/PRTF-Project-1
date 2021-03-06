﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI
{
    /// <summary>
    /// Classe chef de projet et point d'entré dans le DLL
    /// </summary>
    public class Galerie
    {
        public Conservateurs TableauConservateurs = new Conservateurs();
        public Artistes TableauArtistes = new Artistes();
        public Oeuvres TableauOeuvres = new Oeuvres();


        public void AjouterConservateurs(string idconservateur, string prenomconservateur, string nomconservateur, string modetest)
        {
            Conservateur nouvconsevateur = new Conservateur(idconservateur, prenomconservateur, nomconservateur);
            TableauConservateurs.Add(nouvconsevateur);
            Console.WriteLine("Le Conservateur ID: {0}, Prenom: {1}, Nom: {2} a été ajouté au système", nouvconsevateur.ID, nouvconsevateur.Prenom, nouvconsevateur.Nom);
            if (modetest == "N")
            {
                Console.ReadKey();
            }
        }


        /// <summary>
        /// Afficher la liste des conservateur 
        /// </summary>
        public void AfficherConservateur()
        {
            Console.WriteLine("Liste des Conservateur");
            if (TableauConservateurs.Count > 0)
            {
                foreach (Conservateur c in TableauConservateurs)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else Console.WriteLine("Aucun Conservateur dans la collection");
            Console.ReadKey();
        }


        /// <summary>
        /// Vendre oeuvre
        /// </summary>
        /// <param name="oOeuvre"></param> 
        /// <param name="prixvente"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool VendreOeuvre(Oeuvre oOeuvre, double prixvente, bool verbose=true)
        {
            bool OeuvreVendu = false;
            
            if (oOeuvre != null)
            {
                if (oOeuvre.ValeurEstimee < prixvente)
                {
                    oOeuvre.Prix = prixvente;
                    oOeuvre.Etat = "V";
                    OeuvreVendu = true;

                    // Attribué commission au conservateur pour la vente
                    Artiste oArtiste = TableauArtistes.TrouveParID(oOeuvre.IDArtiste);
                    Conservateur oConservateur = TableauConservateurs.TrouveParID(oArtiste.IDConservateur);
                    double commissionaPayer = oOeuvre.CalculerComm(prixvente, oConservateur);
                    oConservateur.SetComm(commissionaPayer);
                    Console.WriteLine("Oeuvre vendu, {0} $ en commission attribué au conservateur {1}.", commissionaPayer, oConservateur.Prenom + " " + oConservateur.Nom);
                    if (verbose)
                    {
                        Console.ReadKey();
                    }
                }
                else
                {
                    if (verbose)
                    {
                        Console.WriteLine("Le prix de vente est inferieur a la valeur estimée cette transaction est refusé");
                        Console.ReadKey();
                    }
                    
                }
            }
            return OeuvreVendu;
        }


        /// <summary>
        /// Ajouter Artiste 
        /// </summary>
        /// <param name="idartiste"></param>
        /// <param name="prenomartiste"></param>
        /// <param name="nomartiste"></param>
        /// <param name="idconservateur"></param>
        /// <param name="modetest"></param>
        public void AjouterArtiste(string idartiste, string prenomartiste, string nomartiste, string idconservateur, string modetest)
        {
            Artiste nouvartiste = new Artiste(idartiste, prenomartiste, nomartiste, idconservateur);
            TableauArtistes.Add(nouvartiste);
            Console.WriteLine("L'Artiste ID: {0}, Prenom: {1}, Nom: {2} a été ajouté au système", nouvartiste.ID, nouvartiste.Prenom, nouvartiste.Nom);
            if (modetest == "N")
            {
                Console.ReadKey();
            }
        }
        

        /// <summary>
        /// Afficher la liste des artiste
        /// </summary>
        public void AfficherArtiste()
        {
            Console.WriteLine("Liste des Artistes");
            if (TableauArtistes.Count > 0)
            {
                foreach (Artiste c in TableauArtistes)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else Console.WriteLine("Aucun Artiste dans la collection");
            Console.ReadKey();
        }


        /// <summary>
        /// Ajouter une oeuvre
        /// </summary>
        /// <param name="idoeuvre"></param>
        /// <param name="titreoeuvre"></param>
        /// <param name="anneeoeuvre"></param>
        /// <param name="valeuroeuvre"></param>
        /// <param name="idartiste"></param>
        /// <param name="modetest"></param>
        public void AjouterOeuvre(string idoeuvre, string titreoeuvre,  int anneeoeuvre, double valeuroeuvre, string idartiste, string modetest)
        {
            //string idOeuvre, string titre, int annee, double valeurEstimee, string idArtiste
            Oeuvre nouvelleOeuvre = new Oeuvre(idoeuvre, titreoeuvre, anneeoeuvre, valeuroeuvre, idartiste);
            TableauOeuvres.Add(nouvelleOeuvre);
            Console.WriteLine("L'artiste {0} a été assigné comme l'auteur de cette oeuvre", idartiste);
            Console.WriteLine("L'ouvre a été créer en {0} et a une valeur estimé de : {1}", anneeoeuvre, valeuroeuvre);
            Console.WriteLine("Enregistrement de l'oeuvre - code: {0} - {1} à été effectuer", idoeuvre, titreoeuvre);
            if (modetest == "N")
            {
                Console.ReadKey();
            }
        }


        /// <summary>
        /// Afficher la liste des oeuvres
        /// </summary>
        public void AfficherOeuvre()
        {
            Console.WriteLine("Liste des Oeuvres");
            if (TableauOeuvres.Count > 0)
            {
                foreach (Oeuvre o in TableauOeuvres)
                {
                    Console.WriteLine(o.ToString());
                }
            }
            else Console.WriteLine("Aucune Ouevre dans la collection");
            Console.ReadKey();
        }

    }
}
