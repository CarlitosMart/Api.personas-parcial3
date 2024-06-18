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
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        //private readonly ClientesDbContext _context;
        private ClienteService ClienteService;
        public ClienteValidator(IConfiguration configuracion)
        {
            //_context = context;
            ClienteService = new ClienteService(configuracion.GetConnectionString("postgres"));

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Campo nombre requerido").Length(3, 256).WithMessage("Minimo 3 caracteres");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("Campo apellido requerido").Length(3, 256).WithMessage("Minimo 3 caracteres");

            //RuleFor(x => x.Celular).NotEmpty().Matches(@"^\d{9}$").WithMessage("Por favor ingrese un nro de celular");
            RuleFor(x => x.Celular).NotEmpty().Length(10).Matches(@"^[\d]+$").WithMessage("Celular debe ser numerico.");


            RuleFor(x => x.Documento).NotEmpty().WithMessage("Documento es obligatorio.").Length(7, 256).WithMessage("Documento minimo 7 caracteres.").Must(ClienteService.IsUnique).WithMessage("Ya existe ese número de documento");

            RuleFor(s => s.Mail).NotEmpty().WithMessage("Debe ingresar un email").EmailAddress().WithMessage("Verifique el formato del email");

        }

       // private bool IsUnique(String Documento)
       // {
       //     ClienteRepository r = new ClienteRepository();
       //     var model = _context.Clientes.GroupBy(x => x.Documento)
       //.Where(g => g.Count() > 1)
       //.Select(y => y.Key).ToList();  //judge whether parentclass has duplicate id
       //     if (model == null)
       //         return true;
       //     else return false;
        //}
        // private bool IsActivo(int Id)
        // {
        //     var model = _context.Clientes.Where(x => x.Id == Id).FirstOrDefault();
        //     if (model.Estado == "1")
        //         return true;
        //     else return false;
        // }
    }
}
