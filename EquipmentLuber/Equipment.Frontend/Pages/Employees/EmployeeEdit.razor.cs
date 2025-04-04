using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Frontend.Shared;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages.Employees
{
    public partial class EmployeeEdit
    {
        private Employee? employee;
        private FormWithName<Employee>? employeeForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter] public int EmployeeId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Employee>($"/api/Employees/{EmployeeId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/employees");
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            employee = responseHttp.Response;
        }

        private async Task UpdateAsync()
        {
            var responseHttp = await Repository.PutAsync("/api/Employees", employee);
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
            employeeForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/employees");
        }
    }
}