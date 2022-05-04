using Incubadora.Business.Enum;
using Incubadora.Encrypt;
using Incubadora.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Incubadora.Helpers.DatabaseInitialization
{
    public class IncubadoraDBInitializer : IDatabaseInitializer<IncubadoraDataBaseEntities>
    {
        public IncubadoraDBInitializer()
        {
        }

        public void InitializeDatabase(IncubadoraDataBaseEntities context)
        {
            if(context.Database.Exists())
            {
                if (context.Status.Count() == 0)
                {
                    this.AddStatus(context);
                }

                if (context.AspNetRoles.Count() == 0)
                {
                    this.AddAspNetRoles(context);
                }

                if (context.CatAvatars.Count() == 0)
                {
                    this.AddAvatars(context);
                }

                if (context.AspNetUsers.Count() == 0)
                {
                    this.AddDefaultAspNetUser(context);
                }

                if (context.Modulos.Count() == 0)
                {
                    this.AddModulos(context);
                }

                if (context.CatUnidadesAcademicas.Count() == 0)
                {
                    this.AddUnidadesAcademicasWithPE(context);
                }

                if (context.CatCuatrimestres.Count() == 0)
                {
                    this.AddCuatrimestres(context);
                }

                if (context.CatFases.Count() == 0)
                {
                    this.AddFases(context);
                }

                if (context.CatGiros.Count() == 0)
                {
                    this.AddGiros(context);
                }

                if (context.CatServicios.Count() == 0)
                {
                    this.AddServicios(context);
                }

                if (context.CatSexos.Count() == 0)
                {
                    this.AddSexos(context);
                }
            }
        }

        private void AddAvatars(IncubadoraDataBaseEntities context)
        {
            List<CatAvatars> avatars = new List<CatAvatars>
            {
                new CatAvatars
                {
                    Id = 1,
                    StrUrl = "default-avatars/user-default-1.png",
                    StrValor = "Default Avatar for Any User",
                },
                new CatAvatars
                {
                    Id = 2,
                    StrUrl = "default-avatars/avatar-mujer-3.png",
                    StrValor = "Default Avatar for Any women",
                },
                new CatAvatars
                {
                    Id = 3,
                    StrUrl = "default-avatars/avatar-hombre-2.png",
                    StrValor = "Default Avatar for men",
                }
            };
            avatars.ForEach(av => context.CatAvatars.Add(av));
            context.SaveChanges();
        }

        private void AddModulos(IncubadoraDataBaseEntities context)
        {
            List<Modulos> modulos = new List<Modulos>
            {
                new Modulos
                {
                    StrValor = "Test"
                }
            };
            modulos.ForEach(m => context.Modulos.Add(m));
            context.SaveChanges();
        }

        private void AddAspNetRoles(IncubadoraDataBaseEntities context)
        {
            List<AspNetRoles> aspNetRoles = new List<AspNetRoles>
            {
                new AspNetRoles
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "Administrador".ToUpper(),
                    ConcurrencyStamp = DateTime.Now.Date.ToString(),
                },
                new AspNetRoles
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Emprendedor",
                    NormalizedName = "Emprendedor".ToUpper(),
                    ConcurrencyStamp = DateTime.Now.Date.ToString(),
                },
                new AspNetRoles
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Docente",
                    NormalizedName = "Docente".ToUpper(),
                    ConcurrencyStamp = DateTime.Now.Date.ToString(),
                },
                new AspNetRoles
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ayudante",
                    NormalizedName = "Ayudante".ToUpper(),
                    ConcurrencyStamp = DateTime.Now.Date.ToString(),
                }
            };
            aspNetRoles.ForEach(ar => context.AspNetRoles.Add(ar));
            context.SaveChanges();
        }

        private void AddDefaultAspNetUser(IncubadoraDataBaseEntities context)
        {
            var Identificador = Guid.NewGuid();
            AspNetUsers aspNetUsers = new AspNetUsers
            {
                Id = Identificador.ToString(),
                UserName = "sa",
                PasswordHash = Funciones.Encrypt("1234"),
                Email = "admin@admin.com",
                IdAvatar = (int)AvatarEnum.User,
            };
            var adminRolId = context.AspNetRoles.FirstOrDefault(r => r.Name == "Administrador");
            AspNetRoles roles = new AspNetRoles { Id = adminRolId.Id };
            AspNetUserRoles userRoles = new AspNetUserRoles
            {
                UserId = aspNetUsers.Id,
                RoleId = roles.Id
            };
            aspNetUsers.AspNetUserRoles.Add(userRoles);
            context.AspNetUsers.Add(aspNetUsers);
            context.SaveChanges();
        }

        private void AddUnidadesAcademicasWithPE(IncubadoraDataBaseEntities context)
        {
            List<CatUnidadesAcademicas> unidadesAcademicas = new List<CatUnidadesAcademicas>
            {
                new CatUnidadesAcademicas
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Tula-Tepeji",
                    StrDescripcion = "Universidad Tecnológica de Tula Tepeji",
                    CatCarreras = new List<CatCarreras>
                    {
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Química",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Energías Renovables",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Mantenimiento",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Contaduría",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Procesos Industriales",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Desarrollo de Negocios",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Mecatrónica",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Tecnologías de la Información",
                            IdStatus = (int)StatusEnum.Activo,
                        }
                    }
                },
                new CatUnidadesAcademicas
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Chapulhuacán",
                    StrDescripcion = "Universidad Tecnológica campus Chapulhuacán",
                    CatCarreras = new List<CatCarreras>
                    {
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Agricultura",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Contaduría",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Desarrollo de negocios",
                            IdStatus = (int)StatusEnum.Activo,
                        },
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Tecnologías de la Información",
                            IdStatus = (int)StatusEnum.Activo,
                        }
                    }
                },
                new CatUnidadesAcademicas
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Tepetitlán",
                    StrDescripcion = "Universidad Tecnológica campus Tepetitlán",
                    CatCarreras = new List<CatCarreras>
                    {
                        new CatCarreras
                        {
                            Id = Guid.NewGuid().ToString(),
                            StrValor = "Enfermería",
                            IdStatus = (int)StatusEnum.Activo,
                        }
                    }
                }
            };
            unidadesAcademicas.ForEach(ua => context.CatUnidadesAcademicas.Add(ua));
            context.SaveChanges();
        }

        private void AddStatus(IncubadoraDataBaseEntities context)
        {
            List<Status> status = new List<Status>
            {
                new Status
                {
                    StrValor = "Activo"
                },
                new Status
                {
                    StrValor = "Eliminar"
                }
            };
            status.ForEach(s => context.Status.Add(s));
            context.SaveChanges();
        }

        private void AddCuatrimestres(IncubadoraDataBaseEntities context)
        {
            List<CatCuatrimestres> cuatris = new List<CatCuatrimestres>
            {
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Primero"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Segundo"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Tercero"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Cuarto"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Quinto"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Sexto"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Séptimo"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Octavo"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Noveno"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Décimo"
                },
                new CatCuatrimestres
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Onceavo"
                },
            };
            cuatris.ForEach(c => context.CatCuatrimestres.Add(c));
            context.SaveChanges();
        }

        private void AddFases(IncubadoraDataBaseEntities context)
        {
            List<CatFases> fases = new List<CatFases>
            {
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Idea"
                },
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "En marcha con más de un año de operación"
                },
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "En marcha con entre 6 y 12 meses de operación"
                },
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "En marcha con menos de 6 meses de operación"
                },
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Plan de negocios"
                },
                new CatFases
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Proyecto de inversión"
                }
            };
            fases.ForEach(f => context.CatFases.Add(f));
            context.SaveChanges();
        }

        private void AddGiros(IncubadoraDataBaseEntities context)
        {
            List<CatGiros> giros = new List<CatGiros>
            {
                new CatGiros
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Industrial"
                },
                new CatGiros
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Servicios"
                },
                new CatGiros
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Comercial"
                }
            };
            giros.ForEach(g => context.CatGiros.Add(g));
            context.SaveChanges();
        }

        private void AddServicios(IncubadoraDataBaseEntities context)
        {
            List<CatServicios> services = new List<CatServicios>
            {
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en mercadotécnia"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en propiedad intelectual"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en normas ambientales"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en tecnologías de la información"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría técnica e industrial"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en búsqueda de financiamiento"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Generación de prototipos"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría en procesos de producción"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Hospedaje empresarial"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Asesoría financiera"
                },
                new CatServicios
                {
                    Id = Guid.NewGuid().ToString(),
                    StrValor = "Estudios y pruebas de laboratorio"
                }
            };
            services.ForEach(s => context.CatServicios.Add(s));
            context.SaveChanges();
        }

        private void AddSexos(IncubadoraDataBaseEntities context)
        {
            List<CatSexos> sexos = new List<CatSexos>
            {
                new CatSexos
                {
                    StrValor = "Masculino"
                },
                new CatSexos
                {
                    StrValor = "Femenino"
                }
            };
            sexos.ForEach(s => context.CatSexos.Add(s));
            context.SaveChanges();
        }
    }
}