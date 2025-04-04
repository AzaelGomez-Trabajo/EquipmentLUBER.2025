using CurrieTechnologies.Razor.SweetAlert2;
using Equipment.Frontend.Repositories;
using Equipment.Shared.DTOs;
using Equipment.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Equipment.Frontend.Pages.Departments
{
    public partial class DepartmentDetails
    {
        private Department? department;
        private List<Employment>? employments;
        private int currentPage = 1;
        private int totalPages;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        [Parameter] public int DepartmentId { get; set; }

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
            var ok = await LoadDepartmentAsync();
            if (ok)
            {
                ok = await LoadEmploymentsAsync(page);
                if (ok)
                {
                    await LoadPagesAsync();
                }
            }
        }

        private async Task LoadPagesAsync()
        {
            var responseHttp = await Repository.GetAsync<int>($"api/Employments/totalPages?id={DepartmentId}");
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

        private async Task<bool> LoadEmploymentsAsync(int page)
        {
            var responseHttp = await Repository.GetAsync<List<Employment>>($"api/Employments?id={DepartmentId}&page={page}");
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
                return false;
            }
            employments = responseHttp.Response;
            return true;
        }

        private async Task<bool> LoadDepartmentAsync()
        {
            var responseHttp = await Repository.GetAsync<Department>($"api/Departments/{DepartmentId}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/branchOffices");
                    return false;
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            department = responseHttp.Response;
            return true;
        }

        //private async Task LoadAsync()
        //{
        //    var responseHttp = await Repository.GetAsync<Department>($"api/Departments/{DepartmentId}");
        //    if (responseHttp.Error)
        //    {
        //        if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            NavigationManager.NavigateTo("/branchOffices");
        //            return;
        //        }
        //        var message = await responseHttp.GetErrorMessageAsync();
        //        await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
        //        return;
        //    }
        //    department = responseHttp.Response;
        //}

        private async Task DeleteAsync(Employment employment)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmacion",
                Text = $"¿Estas seguro de que quieres borrar el puesto {employment.Name}?",
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

            var responseHttp = await Repository.DeleteAsync<Department>($"api/Employments/{employment.Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }
            }

            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000,
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, title: "Puesto borrado exitosamente");
        }

    }
}
