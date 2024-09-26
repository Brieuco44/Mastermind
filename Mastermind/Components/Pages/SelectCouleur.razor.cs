using Microsoft.AspNetCore.Components;
using static Mastermind.Couleur;

namespace Mastermind.Components.Pages
{
    public partial class SelectCouleur
    {
        [Parameter]
        public bool AfficheBtn { get; set; }

        // Index de la couleur sélectionnée
        [Parameter]
        public Couleur SelectedColorIndex { get; set; }

        [Parameter]
        public EventCallback<Couleur> SelectedColorIndexChanged { get; set; }

        // Récupérer la couleur sélectionnée
        private string SelectedColor => GetColor(SelectedColorIndex);

        // Méthode pour obtenir le code hexadécimal correspondant à l'énumération
        private string GetColor(Couleur color)
        {
            return color switch
            {
                Couleur.Rouge => "#f22f2f",
                Couleur.Bleu => "#2fb4f2",
                Couleur.Jaune => "#f2e92f",
                Couleur.Violet => "#b72ff2",
                Couleur.Rose => "#ff3bea",
                Couleur.Vert => "#018e0c"
            };
        }

        private void SetColor(Couleur color)
        {
            SelectedColorIndex = color;

        }

        // Méthode pour aller à la couleur suivante
        private void UpColor()
        {
            SelectedColorIndex = (Couleur)(((int)SelectedColorIndex + 1) % Enum.GetValues(typeof(Couleur)).Length);
            SelectedColorIndexChanged.InvokeAsync(SelectedColorIndex);
        }

        // Méthode pour aller à la couleur précédente
        private void DownColor()
        {
            int totalColors = Enum.GetValues(typeof(Couleur)).Length;
            SelectedColorIndex = (Couleur)(((int)SelectedColorIndex - 1 + totalColors) % totalColors);
            SelectedColorIndexChanged.InvokeAsync(SelectedColorIndex);
        }
    }
}
