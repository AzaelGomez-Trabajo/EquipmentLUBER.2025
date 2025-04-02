using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Frontend.Shared;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages.Departments
{
    public partial class DepartmentEdit
    {
        private Department? department;
        private FormWithName<Department>? departmentForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        [Parameter] public int DepartmentId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Department>($"api/Departments/{DepartmentId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    Return ();
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            department = responseHttp.Response;
        }

        private async Task SaveAsync() 
        {
            var responseHttp = await Repository.PutAsync($"/api/Departments", department);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con exito.");

        }
        private void Return()
        {
            departmentForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/branchOffice/details/{department!.BranchOfficeId}");
        }
    }
}
