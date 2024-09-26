using Microsoft.AspNetCore.Components;

namespace Mastermind.Components.Pages
{
    public partial class Correcteur
    {
        [Parameter]
        public ValidationType Validation { get; set; }

        // Récupérer la couleur sélectionnée
        private string CouleurEnvoie => GetColor(Validation);

        // Méthode pour obtenir le code hexadécimal correspondant à l'énumération
        private string GetColor(ValidationType validation)
        {
            return validation switch
            {
                ValidationType.PLACE => "#41c806",
                ValidationType.EXISTE => "#ffb900",
                ValidationType.INEXISTANT => "#e10000",
            };
        }
    }
}
