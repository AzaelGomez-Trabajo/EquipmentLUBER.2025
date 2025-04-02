using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Equipment.Frontend.Shared;

namespace Equipment.Frontend.Pages.Departments
{
    public partial class DepartmentCreate
    {
        private Department department = new();
        private FormWithName<Department>? departmentForm;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int BranchOfficeId { get; set; }

        private async Task CreateAsync()
        {
            department.BranchOfficeId = BranchOfficeId;
            var responseHttp = await Repository.PostAsync<Department>("api/Departments", department);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con exito.");
        }

        private void Return()
        {
            departmentForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/branchOffice/details/{BranchOfficeId}");
        }
    }
}
