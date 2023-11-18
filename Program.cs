using AutoMapper;
using loterry_console.Dto;
using loterry_console.Models;
using SpreadsheetLight;

string filePath = Environment.GetEnvironmentVariable("TXTROUTE");

quinielaContext dbcontext = new quinielaContext();

//obtengo la ruta de cada archivo
string[] fileNames = Directory.GetFiles(filePath);

List<Quiniela> quinielas = new List<Quiniela>();

//entro a cada archivo
foreach (var file in fileNames)
{
    SLDocument sl = new SLDocument(file);

    //dd-mm-aaaa la fecha la toma del nombre del archivo
    string fechaArchivo = file.Substring(33,10);

    int iRow = 1;

    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
    {
        Quiniela quini = new Quiniela();

        quini.nombre_quiniela = sl.GetCellValueAsString(iRow, 1);
        quini.previa = sl.GetCellValueAsInt32(iRow, 2);
        quini.primera = sl.GetCellValueAsInt32(iRow, 3);
        quini.matutina = sl.GetCellValueAsInt32(iRow, 4);
        quini.vespertina = sl.GetCellValueAsInt32(iRow, 5);
        quini.tarde = sl.GetCellValueAsInt32(iRow, 6);
        quini.nocturna = sl.GetCellValueAsInt32(iRow, 7);
        quini.fecha_dia_publicacion = fechaArchivo;

        quinielas.Add(quini);

        iRow++;
    }
}
IMapper mapper = config.CreateMapper();

List<Persona> personas = ObtenerListaPersonas();

// Utilizar AutoMapper para mapear la lista de Persona a la lista de PersonaDTO
List<PersonaDTO> personasDTO = mapper.Map<List<PersonaDTO>>(personas);

await dbcontext.DatosQuiniela.AddRangeAsync(quinielas);












