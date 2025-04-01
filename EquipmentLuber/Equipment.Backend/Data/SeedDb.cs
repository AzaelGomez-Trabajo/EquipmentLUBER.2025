using Equipment.Shared.Entities;

namespace Equipment.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckBranchOfficesAsync();
        }

        private async Task CheckBranchOfficesAsync()
        {
            if (!_context.BranchOffices.Any())
            {
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Mexico",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Coatzacoalcos",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Cancun",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Leon" ,
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                { 
                    Name = "Merida",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Monterrey",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Morelos",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Oaxaca",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                { 
                    Name = "Pachuca",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]

                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Puebla",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Queretaro",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "San Luis",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Tapachula",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Toluca",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Tuxtla",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Veracruz",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]

                });
                _context.BranchOffices.Add(new BranchOffice 
                {
                    Name = "Villa Hermosa",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Guadalajara",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Oficina",
                            Employments =
                            [
                                new() { Name = "Gerente" },
                                new() { Name = "Facturacion" },
                            ]
                        },
                    ]
                });
                _context.BranchOffices.Add(new BranchOffice
                {
                    Name = "Oficina",
                    Departments =
                    [
                        new Department
                        {
                            Name = "Gerencia de Sustentabilidad",
                            Employments =
                            [
                                new() { Name = "Ger. de Gest y Op de Suc." },
                            ]
                        },
                        new Department
                        {
                            Name = "Gestion Humana",
                            Employments =
                            [
                                new() { Name = "Jefe de Recursos Humanos" },
                                new() { Name = "Encargada de Nominas y Percep." },
                            ]
                        },
                        new Department
                        {
                            Name = "Juridico",
                            Employments =
                            [
                                new() { Name = "Encargado de Juridico" },
                            ]
                        },
                        new Department
                        {
                            Name = "Laboratorio",
                            Employments =
                            [
                                new() { Name = "Gerente Tecnico" },
                                new() { Name = "Supervisor de Laboratorio" },
                                new() { Name = "Tecnico de Ensayo" },
                            ]
                        },
                        new Department
                        {
                            Name = "Logistica",
                            Employments =
                            [
                                new() { Name = "Ausiliar de Logistica" },
                                new() { Name = "Monitorista" },
                                new() { Name = "Auxiliar de Logistica" },
                            ]
                        },
                        new Department
                        {
                            Name = "Mantenimiento",
                            Employments =
                            [
                                new() { Name = "Jefe de Mantenimiento" },
                            ]
                        },
                        new Department
                        {
                            Name = "Mercadotecnia",
                            Employments =
                            [
                                new() { Name = "Diseñador Grafico" },
                                new() { Name = "Analista de E-Commerce" },
                                new() { Name = "Gerente de Mercadotecnia" },
                                new() { Name = "Community Manager" },
                            ]
                        },
                        new Department
                        {
                            Name = "Monitoreo",
                            Employments =
                            [
                                new() { Name = "Auxiliar de Monitoreo" },
                            ]
                        },

                    ]
                });

                await _context.SaveChangesAsync();
            }
        }

        //private async Task CheckDepatmentsAsync()
        //{
        //    if (!_context.Departments.Any())
        //    {
        //        _context.Departments.Add(new Department { Name = "Laboratorio" });
        //        _context.Departments.Add(new Department { Name = "Juridico" });
        //        _context.Departments.Add(new Department { Name = "Produccion" });
        //        _context.Departments.Add(new Department { Name = "Contabilidad" });
        //        _context.Departments.Add(new Department { Name = "Tecnologias de la Informacion" });
        //        _context.Departments.Add(new Department { Name = "Logistica" });
        //        _context.Departments.Add(new Department { Name = "Recursos Humanos" });
        //        _context.Departments.Add(new Department { Name = "Mercadotecnia" });
        //        _context.Departments.Add(new Department { Name = "Cobranza" });
        //        _context.Departments.Add(new Department { Name = "Ventas" });
        //        _context.Departments.Add(new Department { Name = "Direccion Operativa" });
        //        _context.Departments.Add(new Department { Name = "Mantenimiento" });
        //        _context.Departments.Add(new Department { Name = "Monitoreo" });
        //        _context.Departments.Add(new Department { Name = "Compras" });
        //        _context.Departments.Add(new Department { Name = "Seguridad e Higiene" });
        //        _context.Departments.Add(new Department { Name = "Direccion" });
        //        _context.Departments.Add(new Department { Name = "Gerencia de Sustentabilidad" });
        //        _context.Departments.Add(new Department { Name = "Gestion Humana" });
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //private async Task CheckEmploymentsAsync()
        //{
        //    if (!_context.Employments.Any())
        //    {
        //        _context.Employments.Add(new Employment { Name = "Analista de E-Commerce" });
        //        _context.Employments.Add(new Employment { Name = "Asistente" });
        //        _context.Employments.Add(new Employment { Name = "Auxiliar de Reclutamiento" });
        //        _context.Employments.Add(new Employment { Name = "Aux de Compras" });
        //        _context.Employments.Add(new Employment { Name = "Aux de Monitoreo" });
        //        _context.Employments.Add(new Employment { Name = "Aux de Contabilidad" });
        //        _context.Employments.Add(new Employment { Name = "Auxiliar Contable" });
        //        _context.Employments.Add(new Employment { Name = "Auxiliar de Credito y Cobranza" });
        //        _context.Employments.Add(new Employment { Name = "Auxiliar de Logistica" });
        //        _context.Employments.Add(new Employment { Name = "Auxiliar Soporte Tecnico" });
        //        _context.Employments.Add(new Employment { Name = "Community Manager" });
        //        _context.Employments.Add(new Employment { Name = "Contador General" });
        //        _context.Employments.Add(new Employment { Name = "Coordinador de Compras" });
        //        _context.Employments.Add(new Employment { Name = "Director Operativo" });
        //        _context.Employments.Add(new Employment { Name = "Diseñador Grafico" });
        //        _context.Employments.Add(new Employment { Name = "Encargada de Nomina y Percep" });
        //        _context.Employments.Add(new Employment { Name = "Encargado de Invetarios" });
        //        _context.Employments.Add(new Employment { Name = "Encargado Juridico" });
        //        _context.Employments.Add(new Employment { Name = "Encargado de Seguridad e Higiene" });
        //        _context.Employments.Add(new Employment { Name = "Encargado de Tecnologias Infor" });
        //        _context.Employments.Add(new Employment { Name = "Ger de Gest y Op de Sucursal" });
        //        _context.Employments.Add(new Employment { Name = "Gerente de Mercadotecnia" });
        //        _context.Employments.Add(new Employment { Name = "Gerente de Produccion" });
        //        _context.Employments.Add(new Employment { Name = "Gerente de Sucursales y Apert" });
        //        _context.Employments.Add(new Employment { Name = "Gerente Tecnico" });
        //        _context.Employments.Add(new Employment { Name = "Gestor de Cobranza" });
        //        _context.Employments.Add(new Employment { Name = "Jefe de Credito y Cobranza" });
        //        _context.Employments.Add(new Employment { Name = "Jefe de Mantenimiento" });
        //        _context.Employments.Add(new Employment { Name = "Jefe de Recursos Humanos" });
        //        _context.Employments.Add(new Employment { Name = "Jefe de Soplado" });
        //        _context.Employments.Add(new Employment { Name = "Kam Autoservicios y Refacciona" });
        //        _context.Employments.Add(new Employment { Name = "Monitorista" });
        //        _context.Employments.Add(new Employment { Name = "Programador Analista" });
        //        _context.Employments.Add(new Employment { Name = "Recepcionista" });
        //        _context.Employments.Add(new Employment { Name = "Responsable de Sistemas" });
        //        _context.Employments.Add(new Employment { Name = "Supervisor de Laboratorio" });
        //        _context.Employments.Add(new Employment { Name = "Supervisor de Produccion" });
        //        _context.Employments.Add(new Employment { Name = "Supervisora de Credito" });
        //        _context.Employments.Add(new Employment { Name = "Tecnico de Ensayos" });
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}