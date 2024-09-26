using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics;
using System.Security;
using static MudBlazor.CategoryTypes;

namespace Mastermind.Components.Pages
{
    public partial class Home
    {
        private Couleur Couleur0 = Couleur.Rouge;
        private Couleur Couleur1 = Couleur.Rouge;
        private Couleur Couleur2 = Couleur.Rouge;
        private Couleur Couleur3 = Couleur.Rouge;
        private Couleur Couleur4 = Couleur.Rouge;
        public List<List<Couleur>>? ListeEnvoie { set; get; }
        public List<Couleur>? ListeOrdinateur { set; get; }
        public List<ValidationType>? Resultat { set; get; }
        public bool Victoire { set; get; }

        public void Verification(List<Couleur> combinaisonJoueur)
        {
            // Liste de résultats
            var resultats = new List<ValidationType>(new ValidationType[ListeOrdinateur.Count]);

            // Créons une copie de la combinaison de l'ordinateur pour identifier les mal placés
            var combinaisonRestante = new List<Couleur>(ListeOrdinateur);

            // Première étape : identifier les couleurs bien placées
            for (int i = 0; i < ListeOrdinateur.Count; i++)
            {
                if (combinaisonJoueur[i] == ListeOrdinateur[i])
                {
                    resultats[i] = ValidationType.PLACE;
                    combinaisonRestante[i] = default(Couleur); // Marquer la couleur utilisée pour éviter les doublons
                }
            }

            // Deuxième étape : identifier les couleurs mal placées
            for (int i = 0; i < ListeOrdinateur.Count; i++)
            {
                if (resultats[i] != ValidationType.PLACE) // Si la couleur n'est pas déjà bien placée
                {
                    if (combinaisonRestante.Contains(combinaisonJoueur[i]))
                    {
                        resultats[i] = ValidationType.EXISTE;
                        combinaisonRestante[combinaisonRestante.IndexOf(combinaisonJoueur[i])] = default(Couleur); // Marquer la couleur utilisée
                    }
                    else
                    {
                        resultats[i] = ValidationType.INEXISTANT;
                    }
                }
            }

            Resultat = resultats;
            if (resultats.All(r => r == ValidationType.PLACE)) // Vérification de victoire
            {
                Victoire = true;
            }
        }

        private void Envoie()
        {
            // Nouvelle sous-liste de couleurs que tu veux ajouter
            var nouvelleSousListe = new List<Couleur> { Couleur0, Couleur1, Couleur2, Couleur3, Couleur4 };

            // Ajout de la nouvelle sous-liste à la liste principale
            ListeEnvoie.Add(nouvelleSousListe);
            Verification(nouvelleSousListe);
        }

        // Démarrer une nouvelle partie
        private void NouvellePartie()
        {
            Victoire = false;
            ListeEnvoie = new List<List<Couleur>>();
            ListeOrdinateur = new List<Couleur>();
            if (ListeOrdinateur != null)
            {
                Random Random = new();
                for (int i = 0; i < 5; i++)
                {
                    int CouleurChoisie = Random.Next(0, 4);
                    switch (CouleurChoisie)
                    {
                        case 0:
                            ListeOrdinateur.Add(Couleur.Bleu);
                            break;
                        case 1:
                            ListeOrdinateur.Add(Couleur.Rouge);
                            break;
                        case 2:
                            ListeOrdinateur.Add(Couleur.Violet);
                            break;
                        case 3:
                            ListeOrdinateur.Add(Couleur.Jaune);
                            break;
                    }
                }
            }
        }

        protected override void OnInitialized()
        {
            NouvellePartie();
        }
    }
}
