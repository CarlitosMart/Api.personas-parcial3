using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Data;
using System.Text;
using System.Threading.Tasks;
using Repository.Models.BD;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Services.Logica;
using Microsoft.Extensions.Configuration;

namespace Services.Validaciones
{
    public class FacturaValidator : AbstractValidator<FacturaModel>
    {
        //private readonly FacturasDbContext _context;

        public FacturaValidator()
        {
            //_context = context;
            RuleFor(x => x.Nro_factura).NotEmpty().Length(14).Matches(@"^\d{3}-\d{3}-\d{6}$").WithMessage("Formato de factura no coincide con lo esperado");
            RuleFor(x => x.Total).NotEmpty().Matches(@"^[\d]+$").WithMessage("Total  debe ser numerico.");
            RuleFor(x => x.Total_iva5).NotEmpty().Matches(@"^[\d]+$").WithMessage("Total_iva5  debe ser numerico.");
            RuleFor(x => x.Total_iva10).NotEmpty().Matches(@"^[\d]+$").WithMessage("Total_iva10  debe ser numerico.");
            RuleFor(x => x.Total_iva).NotEmpty().Matches(@"^[\d]+$").WithMessage("Total_iva  debe ser numerico.");
            RuleFor(x => x.Total_letras).NotEmpty().WithMessage("Campo Total_letras requerido").Length(6, 256).WithMessage("Minimo 6 caracteres");
            
        }

       // private bool IsUnique(String Documento)
       // {
       //     FacturaRepository r = new FacturaRepository();
       //     var model = _context.Facturas.GroupBy(x => x.Documento)
       //.Where(g => g.Count() > 1)
       //.Select(y => y.Key).ToList();  //judge whether parentclass has duplicate id
       //     if (model == null)
       //         return true;
       //     else return false;
        //}
        // private bool IsActivo(int Id)
        // {
        //     var model = _context.Facturas.Where(x => x.Id == Id).FirstOrDefault();
        //     if (model.Estado == "1")
        //         return true;
        //     else return false;
        // }
    }
}
