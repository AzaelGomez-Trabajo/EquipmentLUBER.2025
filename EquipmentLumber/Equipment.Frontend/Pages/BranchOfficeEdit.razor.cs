using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Pages.BranchOffices;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages
{
    public partial class BranchOfficeEdit
    {
        private BranchOffice? branchOffice;
        private BranchOfficeForm? branchOfficeForm;
        [Inject] private IRepository repository { get; set; } = null!;
        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager navigationManager { get; set; } = null!;
        [EditorRequired, Parameter] public int Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            var responseHttp = await repository.GetAsync<BranchOffice>($"/api/BranchOffices/{Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/branchOffices");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
            }
            else
            {
                branchOffice = responseHttp.Response;
            }
        }

        private async Task UpdateAsync()
        { 
            var responseHttp = await repository.PutAsync("/api/BranchOffices", branchOffice);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro actualizado con exito.");
        }
        private void Return()
        {
            branchOfficeForm!.FormPostedSuccessFully = true;
            navigationManager.NavigateTo("/branchOffices");
        }

    }
}
