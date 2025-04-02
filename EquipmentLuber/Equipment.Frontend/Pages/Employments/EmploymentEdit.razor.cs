using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Pages.BranchOffices;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages.Employments
{
    public partial class EmploymentEdit
    {
        private Employment? employment;
        //private EmploymentForm? employmentForm;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [EditorRequired, Parameter] public int Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Employment>($"/api/Employments/{Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/employments");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
            }
            else
            {
                employment = responseHttp.Response;
            }
        }

        private async Task UpdateAsync()
        {
            var responseHttp = await Repository.PutAsync("/api/Employments", employment);
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
            //employmentForm!.FormPostedSuccessFully = true;
            NavigationManager.NavigateTo("/employments");
        }

    }
}
