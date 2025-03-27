using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Equipment.Frontend.Pages.BranchOffices
{
    public partial class BranchOfficeCreate
    {
        private BranchOffice branchOffice = new();
        private BranchOfficeForm? branchOfficeForm;
        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await repository.PostAsync("/api/BranchOffices", branchOffice);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
            var toast = sweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000,
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con exito.");
        }

        private void Return()
        {
            branchOfficeForm!.FormPostedSuccessFully = true;
            navigationManager.NavigateTo("/branchOffices");
        }
    }
}