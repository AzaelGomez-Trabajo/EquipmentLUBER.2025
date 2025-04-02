using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Frontend.Shared;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Equipment.Frontend.Pages.Employments
{
    public partial class EmploymentCreate
    {
        private Employment employment = new();
        private FormWithName<Employment>? employmentForm;
        
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter] public int DepartmentId { get; set; }
        private async Task CreateAsync()
        {
            employment.DepartmentId = DepartmentId;
            var responseHttp = await Repository.PostAsync("/api/Employments", employment);
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
            employmentForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/department/details/{DepartmentId}");
        }
    }
}
