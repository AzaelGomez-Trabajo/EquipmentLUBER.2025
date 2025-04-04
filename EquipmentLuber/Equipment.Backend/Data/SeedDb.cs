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
            await CheckEmployeesAsync();
        }

        private async Task CheckBranchOfficesAsync()
        {
            if (!_context.BranchOffices.Any())
            {
                _context.BranchOffices.Add(
                    new BranchOffice
                    {
                        Name = "Oficina",
                        Departments =
                        [
                            new Department
                            {
                                Name = "Cobranza",
                                Employments =
                                [
                                    new() { Name = "Jefe de Credito y Cobranza" },
                                    new() { Name = "Gestor de Cobranza" },
                                    new() { Name = "Supervisor de Credito" },
                                    new() { Name = "Auxiliar de Credito y Cobranza" },
                                ]
                            },
                            new Department
                            {
                                Name = "Compras",
                                Employments =
                                [
                                    new() { Name = "Coordinador de Compras" },
                                    new() { Name = "Aux de Compras" },
                                ]
                            },
                            new Department
                            {
                                Name = "Contabilidad",
                                Employments =
                                [
                                    new() { Name = "Contador General" },
                                    new() { Name = "Auxiliar de Contabilidad" },
                                    new() { Name = "Auxiliar Contable" },
                                    new() { Name = "Encargado de Inventarios." },
                                ]
                            },
                            new Department {
                                Name = "Direccion",
                                Employments =
                                [
                                    new() { Name = "Asistente" },
                                ]
                            },
                            new Department {
                                Name = "Direccion Operativa",
                                Employments =
                                [
                                    new() { Name = "Director Operativo" },
                                ]
                            },
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
                                    new() { Name = "Auxiliar de Logistica" },
                                    new() { Name = "Monitorista" },
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
                            new Department
                            {
                                Name = "N Depto",
                                Employments =
                                [
                                    new() { Name = "N Puesto" },
                                ]
                            },
                            new Department
                            {
                                Name = "Produccion",
                                Employments =
                                [
                                    new() { Name = "Gerente de Produccion" },
                                    new() { Name = "Jefe de Soplado" },
                                    new() { Name = "Supervisor de Produccion" },
                                ]
                            },
                            new Department
                            {
                                Name = "Recursos Humanos",
                                Employments =
                                [
                                    new() { Name = "Auxiliar de Reclutamiento" },
                                    new() { Name = "Encargada de Nominas y Percep." },
                                    new() { Name = "Recepcionista" },
                                ]
                            },
                            new Department
                            {
                                Name = "Seguridad e Higiene",
                                Employments =
                                [
                                    new() { Name = "Encargado de Seguridad e Higiene" },
                                ]
                            },
                            new Department
                            {
                                Name = "Tecnologias de la Informacion",
                                Employments =
                                [
                                    new() { Name = "Auxiliar Soporte Tecnico" },
                                    new() { Name = "Encargado de Tecnologias Infor." },
                                    new() { Name = "Programador Analista" },
                                    new() { Name = "Responsable de Sistemas" },
                                ]
                            },
                            new Department
                            {
                                Name = "Ventas",
                                Employments =
                                [
                                    new() { Name = "Gerente de Sucursales y Apert" },
                                    new() { Name = "Kam Autoservicios y Refacciona" },
                                ]
                            },
                        ]
                    });
                _context.BranchOffices.Add(
                new BranchOffice
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
                    Name = "Leon",
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
                                new() { Name = "Ventas" },
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

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEmployeesAsync()
        {
            if (!_context.Employees.Any())
            {
                //COBRANZA
                _context.Employees.Add(new Employee { Name = "MIGUEL ANGEL CALIXCO ADJUNTAS", EmployeeNumber = 117, EmploymentId = 2 });
                _context.Employees.Add(new Employee { Name = "GUSTAVO HERNANDEZ MARTINEZ", EmployeeNumber = 127, EmploymentId = 1 });
                _context.Employees.Add(new Employee { Name = "BENJAMIN BURGOS GARCIA", EmployeeNumber = 267, EmploymentId = 4 });
                _context.Employees.Add(new Employee { Name = "LISET LILIAN CRUZ FERREIRA", EmployeeNumber = 400, EmploymentId = 4 });
                _context.Employees.Add(new Employee { Name = "MA YOLANDA ZARATE ESPINOZA", EmployeeNumber = 425, EmploymentId = 4 });
                _context.Employees.Add(new Employee { Name = "EDGAR HOYOS ROMERO", EmployeeNumber = 430, EmploymentId = 4 });
                _context.Employees.Add(new Employee { Name = "GILBERTO GOMEZ DIAZ", EmployeeNumber = 426, EmploymentId = 3 });
                //COMPRAS
                _context.Employees.Add(new Employee { Name = "MARISELA SANCHEZ TAVARES", EmployeeNumber = 290, EmploymentId = 5 });
                _context.Employees.Add(new Employee { Name = "KAREN NOEMI HERNANDEZ MARTINEZ", EmployeeNumber = 432, EmploymentId = 6 });
                //CONTABILIDAD
                _context.Employees.Add(new Employee { Name = "JAVIER CRESCENCIO VICTORIANO", EmployeeNumber = 201, EmploymentId = 7 });
                _context.Employees.Add(new Employee { Name = "ROSA ISELA OLEA HERNANDEZ", EmployeeNumber = 276, EmploymentId = 8 });
                _context.Employees.Add(new Employee { Name = "MARIA DEL ROSARIO ROSALES TREJO", EmployeeNumber = 346, EmploymentId = 9 });
                _context.Employees.Add(new Employee { Name = "MARIA MAGDALENA RAMIREZ MOSQUEDA", EmployeeNumber = 360, EmploymentId = 9 });
                _context.Employees.Add(new Employee { Name = "ANA BERTHA TEMICH JIMENEZ", EmployeeNumber = 387, EmploymentId = 8 });
                _context.Employees.Add(new Employee { Name = "JUANA MARICELA OLGUIN MARTINEZ", EmployeeNumber = 390, EmploymentId = 8 });
                _context.Employees.Add(new Employee { Name = "DANIEL MORALES RIVERA", EmployeeNumber = 404, EmploymentId = 10 });
                _context.Employees.Add(new Employee { Name = "LUIS ALBERTO MORALES LOPEZ", EmployeeNumber = 414, EmploymentId = 10 });
                //DIRECCION
                _context.Employees.Add(new Employee { Name = "MARIA LETICIA TREJO PATIÑO", EmployeeNumber = 170, EmploymentId = 11 });
                //DIRECCION OPERATIVA
                _context.Employees.Add(new Employee { Name = "JUAN JOSE CHAVEZ SANCHEZ", EmployeeNumber = 421, EmploymentId = 12 });
                //GERENCIA DE SUSTENTABILIDAD
                _context.Employees.Add(new Employee { Name = "VALENTIN FERNANDO GOMEZ MERLO", EmployeeNumber = 122, EmploymentId = 13 });
                //GESTION HUMANA
                _context.Employees.Add(new Employee { Name = "NANCY ESTHER PEREZ ACOSTA", EmployeeNumber = 297, EmploymentId = 14 });
                _context.Employees.Add(new Employee { Name = "MIRIAM MIREL SANTOS MANDUJANO", EmployeeNumber = 311, EmploymentId = 15 });
                //JURIDICO
                _context.Employees.Add(new Employee { Name = "ALBERTO SALINAS ZARRION", EmployeeNumber = 329, EmploymentId = 16 });
                //LABORATORIO
                _context.Employees.Add(new Employee { Name = "JOSE ZENON RUIZ LOPEZ", EmployeeNumber = 148, EmploymentId = 17 });
                _context.Employees.Add(new Employee { Name = "DIEGO ARTURO CALDERON MEDINA", EmployeeNumber = 198, EmploymentId = 18 });
                _context.Employees.Add(new Employee { Name = "LAURA MARIANA ARRIAGA NIEVES", EmployeeNumber = 252, EmploymentId = 19 });
                _context.Employees.Add(new Employee { Name = "JOSE GEOVANNI BEIZA VAZQUEZ", EmployeeNumber = 321, EmploymentId = 19 });
                //LOGISTICA
                _context.Employees.Add(new Employee { Name = "VERONICA GARCIA PEREZ", EmployeeNumber = 277, EmploymentId = 20 });
                _context.Employees.Add(new Employee { Name = "DIANA FERNANDA RAMIREZ AGUILAR", EmployeeNumber = 287, EmploymentId = 21 });
                _context.Employees.Add(new Employee { Name = "CARLOS ARMANDO BARRON CHAPARRO", EmployeeNumber = 299, EmploymentId = 21 });
                _context.Employees.Add(new Employee { Name = "NEFTALI SAENZ JAIMEZ", EmployeeNumber = 354, EmploymentId = 20 });
                _context.Employees.Add(new Employee { Name = "JESSICA YOLANDA MORALES IRINEO", EmployeeNumber = 419, EmploymentId = 20 });
                //MANTENIMIENTO
                _context.Employees.Add(new Employee { Name = "JULIO CESAR HERNANDEZ TORALES", EmployeeNumber = 423, EmploymentId = 22 });
                //MRECADOTECNIA
                _context.Employees.Add(new Employee { Name = "JAZMIN RIVAS CABALLERO", EmployeeNumber = 373, EmploymentId = 23 });
                _context.Employees.Add(new Employee { Name = "JUAN ARREDONDO HERNANDEZ", EmployeeNumber = 385, EmploymentId = 23 });
                _context.Employees.Add(new Employee { Name = "ERANDI MARIA MICHELLE GONZALEZ AYALA", EmployeeNumber = 411, EmploymentId = 24 });
                _context.Employees.Add(new Employee { Name = "URINCHO MORALES LUIS CARLOS", EmployeeNumber = 305, EmploymentId = 25 });
                _context.Employees.Add(new Employee { Name = "WENDY PAOLA RODRIGUEZ ALONSO", EmployeeNumber = 433, EmploymentId = 26 });
                //MONITOREO
                _context.Employees.Add(new Employee { Name = "SHEILA NATALY PALOMINO OLIVA", EmployeeNumber = 429, EmploymentId = 27 });
                //N DEPTO
                _context.Employees.Add(new Employee { Name = "ENRIQUE ROMERO GARCIA", EmployeeNumber = 231, EmploymentId = 28 });
                //PRODUCCION
                _context.Employees.Add(new Employee { Name = "VICTOR ROJAS LEON", EmployeeNumber = 237, EmploymentId = 29 });
                _context.Employees.Add(new Employee { Name = "NOE RODRIGUEZ ORTIZ", EmployeeNumber = 318, EmploymentId = 30 });
                _context.Employees.Add(new Employee { Name = "BEATRIZ ADRIANA VILLEGAS RINCON", EmployeeNumber = 331, EmploymentId = 31 });
                _context.Employees.Add(new Employee { Name = "FERNANDO EFREN RAMIREZ FLORES", EmployeeNumber = 413, EmploymentId = 31 });
                //RECURSOS HUMANOS
                _context.Employees.Add(new Employee { Name = "BRENDA CITLALLI GARFIAS VENTURA", EmployeeNumber = 357, EmploymentId = 33 });
                _context.Employees.Add(new Employee { Name = "THELMA MONTSERRAT MULLER CANO", EmployeeNumber = 388, EmploymentId = 32 });
                _context.Employees.Add(new Employee { Name = "SANDRA OROZCO ROMERO", EmployeeNumber = 407, EmploymentId = 34 });
                _context.Employees.Add(new Employee { Name = "DANIELA SERNA ROJAS", EmployeeNumber = 308, EmploymentId = 32 });
                //SEGURIDAD E HIGIENE
                _context.Employees.Add(new Employee { Name = "GUILLERMO ALFONSO HERNANDEZ ALVAREZ", EmployeeNumber = 436, EmploymentId = 35 });
                //TECNOLOGIAS
                _context.Employees.Add(new Employee { Name = "ERICK OCTAVIO SANDOVAL GARCIA", EmployeeNumber = 313, EmploymentId = 39 });
                _context.Employees.Add(new Employee { Name = "SARAHI GONZALEZ BARRON", EmployeeNumber = 350, EmploymentId = 37 });
                _context.Employees.Add(new Employee { Name = "IVAN RAFAEL OLVERA MORENO", EmployeeNumber = 435, EmploymentId = 36 });
                _context.Employees.Add(new Employee { Name = "NOE AZAEL GOMEZ SERRANO", EmployeeNumber = 437, EmploymentId = 38 });
                //VENTAS
                _context.Employees.Add(new Employee { Name = "JOSE MANUEL ANIEVA GONZALEZ", EmployeeNumber = 415, EmploymentId = 40 });
                _context.Employees.Add(new Employee { Name = "OMAR MANJARREZ HERNANDEZ", EmployeeNumber = 416, EmploymentId = 41 });

                await _context.SaveChangesAsync();
            }
        }
    }
}