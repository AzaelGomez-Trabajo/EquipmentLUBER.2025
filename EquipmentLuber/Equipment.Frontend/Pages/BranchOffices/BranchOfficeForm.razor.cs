using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;

namespace Equipment.Frontend.Pages.BranchOffices
{
    public partial class BranchOfficeForm
    {
        private EditContext editContext = null!;

        [EditorRequired, Parameter] public BranchOffice BranchOffice { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        public bool FormPostedSuccessFully { get; set; }

        protected override void OnInitialized()
        {
            editContext = new(BranchOffice);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (formWasEdited || FormPostedSuccessFully)
            {
                return;
            }
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmacion",
                Text = "Deseas abandonar la pagina y perder los cambios",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true
            });
            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            context.PreventNavigation();
        }
    }
}