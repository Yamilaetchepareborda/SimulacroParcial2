using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Repositories
{
    public class RepositorioJson<T> : IRepositorio<T>
    {
        private readonly string _ruta;

        private static readonly JsonSerializerOptions _opts = new JsonSerializerOptions { WriteIndented = true }; //serializo el json de forma prolija, osea identado con espacios.
        public RepositorioJson(string ruta) => _ruta = ruta; // constructor
        public void Guardar(T entidad)
        {
            List<T> data = new List<T>(); //lista temporal para almacenar los datos
            if (File.Exists(_ruta)) //si el archivo existe
            {
                var json = File.ReadAllText(_ruta); //leo el contenido del archivo
                var list = JsonSerializer.Deserialize<List<T>>(json, _opts); //deserializo el contenido
                if (list != null) data = list; //si no es nulo asigno el contenido a data

            }
            data.Add(entidad);
            File.WriteAllText(_ruta, JsonSerializer.Serialize(data, _opts)); //escribo el contenido actualizado en el archivo
        }

        public IEnumerable<T> ObtenerTodos()
        {
            if (!File.Exists(_ruta)) return Enumerable.Empty<T>(); //si no existe el archivo retorno una lista vacia
            var json = File.ReadAllText(_ruta); 
            return JsonSerializer.Deserialize<List<T>>(json, _opts) ?? Enumerable.Empty<T>(); //deserializo y retorno el contenido o una lista vacia si es nulo
        }

    }
}
