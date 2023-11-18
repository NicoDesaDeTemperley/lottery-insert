using AutoMapper;
using loterry_console.Dto;
using loterry_console.Models;
using Microsoft.EntityFrameworkCore;
using SpreadsheetLight;
using System.Threading.Tasks;

namespace loterry_console
{
    public class Principal
    {
        string fechaArchivo;

        public void procesoPrincipal()
        {
            string filePath = Environment.GetEnvironmentVariable("TXTROUTE"); 

            //obtengo la ruta de cada archivo
            string[] fileNames = Directory.GetFiles(filePath);

            List<Quiniela> quinielas = new List<Quiniela>();

            //entro a cada archivo
            foreach (var file in fileNames)
            {
                SLDocument sl = new SLDocument(file);

                //dd-mm-aaaa la fecha la toma del nombre del archivo
                 fechaArchivo = file.Substring(33, 10);

                int iRow = 1;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    Quiniela quini = new Quiniela();

                    quini.nombre_quiniela = sl.GetCellValueAsString(iRow, 1);
                    quini.previa = sl.GetCellValueAsString(iRow, 2);
                    quini.primera = sl.GetCellValueAsString(iRow, 3);
                    quini.matutina = sl.GetCellValueAsString(iRow, 4);
                    quini.vespertina = sl.GetCellValueAsString(iRow, 5);
                    quini.tarde = sl.GetCellValueAsString(iRow, 6);
                    quini.nocturna = sl.GetCellValueAsString(iRow, 7);
                    quini.fecha_dia_publicacion = fechaArchivo;

                    quinielas.Add(quini);

                    iRow++;
                }
            }

            List<DatosQuiniela> datos_quiniela = new List<DatosQuiniela>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quiniela, DatosQuiniela>()
                .ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.nombre_quiniela))
                .ForMember(dest => dest.Previa, act => act.MapFrom(src => src.previa))
                .ForMember(dest => dest.Primera, act => act.MapFrom(src => src.primera))
                .ForMember(dest => dest.Matutina, act => act.MapFrom(src => src.matutina))
                .ForMember(dest => dest.Vespertina, act => act.MapFrom(src => src.vespertina))
                .ForMember(dest => dest.Tarde, act => act.MapFrom(src => src.tarde))
                .ForMember(dest => dest.Nocturna, act => act.MapFrom(src => src.nocturna))
                .ForMember(dest => dest.FechaDiaPublicacion, act => act.MapFrom(src => src.fecha_dia_publicacion));
            });

            IMapper mapper = config.CreateMapper();

            foreach (var quini in quinielas)
            { 
                datos_quiniela.Add(mapper.Map<DatosQuiniela>(quini));
            }

            using (var dbContext = new quinielaContext())
            {
                dbContext.DatosQuiniela.AddRange(datos_quiniela);
                dbContext.SaveChanges();
            } 
        } 

    }
}
