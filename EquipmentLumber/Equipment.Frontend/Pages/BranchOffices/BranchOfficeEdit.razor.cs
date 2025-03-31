using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages.BranchOffices
{
    public partial class BranchOfficeEdit
    {
        private BranchOffice? branchOffice;
        private BranchOfficeForm? branchOfficeForm;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [EditorRequired, Parameter] public int Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<BranchOffice>($"/api/BranchOffices/{Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/branchOffices");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
            }
            else
            {
                branchOffice = responseHttp.Response;
            }
        }

        private async Task UpdateAsync()
        { 
            var responseHttp = await Repository.PutAsync("/api/BranchOffices", branchOffice);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
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
            NavigationManager.NavigateTo("/branchOffices");
        }

    }
}
