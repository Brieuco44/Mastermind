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
                Couleur.Rouge => "#FF0000",
                Couleur.Bleu => "#0000FF",
                Couleur.Jaune => "#FFFF00",
                Couleur.Violet => "#c903f9",
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
