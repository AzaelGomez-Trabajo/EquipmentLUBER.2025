using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net;

namespace Equipment.Frontend.Pages.BranchOffices
{
    public partial class BranchOfficeDetails
    {
        private BranchOffice? branchOffice;
        private List<Department>? departments;
        private int currentPage = 1;
        private int totalPages;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        [Parameter] public int BranchOfficeId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task SelectedPageAsync(int page)
        {
            if (page == currentPage)
            {
                return;
            }
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task LoadAsync(int page = 1)
        {
            var ok = await LoadBranchOfficeAsync();
            if (ok)
            {
                ok = await LoadDepartmentsAsync(page);
                if (ok)
                {
                    await LoadPagesAsync();
                }
            }
        }

        private async Task LoadPagesAsync()
        {
            var responseHttp = await Repository.GetAsync<int>($"api/Departments/totalPages?id={BranchOfficeId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/departments");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
                return;
            }
            totalPages = responseHttp.Response;
        }

        private async Task<bool> LoadDepartmentsAsync(int page)
        {
            var responseHttp = await Repository.GetAsync<List<Department>>($"api/Departments?id={BranchOfficeId}&page={page}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/departments");
                    return false;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            departments = responseHttp.Response;
            return true;
        }

        private async Task<bool> LoadBranchOfficeAsync()
        {
            var responseHttp = await Repository.GetAsync<BranchOffice>($"api/BranchOffices/{BranchOfficeId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/branchoffices");
                    return false;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            branchOffice = responseHttp.Response;
            return true;
        }

        private async Task DeleteAsync(Department department)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmacion",
                Text = $"¿Estas seguro de que quieres borrar el departamento {department.Name}?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Si, borrar",
                CancelButtonText = "No"
            });

            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            var responseHttp = await Repository.DeleteAsync<Department>($"api/Departments/{department.Id}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Title = "Exito",
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000,
            }); 
            await toast.FireAsync(icon: SweetAlertIcon.Success, title: "Departamento borrado exitosamente");
        }
    }
}