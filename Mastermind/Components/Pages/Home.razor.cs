using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Mastermind.Components.Pages
{
    public partial class Home
    {
        public Couleur? SelectedColor { set; get; }
        public int NbTentatives = 0;
        private Couleur Couleur0 = Couleur.Rouge;
        private Couleur Couleur1 = Couleur.Rouge;
        private Couleur Couleur2 = Couleur.Rouge;
        private Couleur Couleur3 = Couleur.Rouge;
        private Couleur Couleur4 = Couleur.Rouge;
        public List<List<Couleur>> ListeEnvoie { set; get; }
        public List<int>? ListeEnvoieCouleur { set; get; }
        public List<Couleur>? ListeReponse { set; get; }

        // Liste qui stocke les index des composants ajoutés
        private List<int> Composant = new List<int>();
        private int NextComposantId = 1;

        private void Envoie()
        {
            // Nouvelle sous-liste de couleurs que tu veux ajouter
            var nouvelleSousListe = new List<Couleur> { Couleur0, Couleur1, Couleur2, Couleur3, Couleur4 };

            // Ajout de la nouvelle sous-liste à la liste principale
            ListeEnvoie.Add(nouvelleSousListe);

            Composant.Add(NextComposantId);
            NextComposantId++; // Incrémentation pour le prochain composant
        }


        protected override void OnInitialized()
        {
            ListeReponse = new List<Couleur>();
            if (ListeReponse != null)
            {
                Random Random = new();
                for (int i = 0; i < 5; i++)
                {
                    int CouleurChoisie = Random.Next(0, 3);
                    switch (CouleurChoisie){
                        case 0:
                            ListeReponse.Add(Couleur.Bleu);
                            break;
                        case 1:
                            ListeReponse.Add(Couleur.Rouge);
                            break;
                        case 2:
                            ListeReponse.Add(Couleur.Violet);
                            break;
                        case 3:
                            ListeReponse.Add(Couleur.Jaune);
                            break;
                    }
                }
            }
        }
    }
}
