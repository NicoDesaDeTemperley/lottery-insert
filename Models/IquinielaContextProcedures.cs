﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using loterry_console.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace loterry_console.Models
{
    public partial interface IquinielaContextProcedures
    {
        Task<int> insert_datos_quinielaAsync(string Nombre, int? Previa, int? Primera, int? Matutina, int? Vespertina, int? Tarde, int? Nocturna, string FechaDiaPublicacion, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
