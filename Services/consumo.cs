using System.Text;
using ProyectoInicial.Models;
using Newtonsoft.Json;


namespace ProyectoInicial.Services
{
    public class consumo : Iconsumo
    {
        private static string _baseUrl;

        public consumo()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }
        public async Task<string> DeleteLibro(int IdLibro)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"api/InventarioLibros/{IdLibro}");
            return "Producto eliminado correctamente";

        }



        public async Task<List<Libros>> GetLibros()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("api/InventarioLibros/");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Libros> listaLibros = JsonConvert.DeserializeObject<List<Libros>>(json_response);
            return listaLibros;

        }

        public async Task<Libros> GetLibro(int IdLibro)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"api/InventarioLibros/{IdLibro}");
            var json_response = await response.Content.ReadAsStringAsync();
            Libros libro = JsonConvert.DeserializeObject<Libros>(json_response);
            return libro;
        }

        public async Task<Libros> PutLibro(int IdLibro, Libros libro)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(libro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/InventarioLibros/{IdLibro}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Libros editarLibro = JsonConvert.DeserializeObject<Libros>(jsonResponse);
            return editarLibro;

        }

        public async Task<Libros> PostLibro(Libros Libro)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(Libro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/InventarioLibros", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Libros libroCreado = JsonConvert.DeserializeObject<Libros>(jsonResponse);
            return libroCreado;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("api/Usuario/");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Usuario> listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json_response);
            return listaUsuarios;
        }

        public async Task<Usuario> GetUsuario(int IdUsuario)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"api/Usuario/{IdUsuario}");
            var json_response = await response.Content.ReadAsStringAsync();
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json_response);
            return usuario;
        }

        public async Task<Usuario> PostUsuario(Usuario usuario)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Usuario", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Usuario usuarioCreado = JsonConvert.DeserializeObject<Usuario>(jsonResponse);
            return usuarioCreado;
        }

        public async Task<Usuario> PutUsuario(int IdUsuario, Usuario usuario)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Usuario/{IdUsuario}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Usuario editarUsuario = JsonConvert.DeserializeObject<Usuario>(jsonResponse);
            return editarUsuario;
        }

        public async Task<string> DeleteUsuario(int IdUsuario)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"api/Usuario/{IdUsuario}");
            return "Producto eliminado correctamente";
        }

        

        public async Task<List<Prestamo>> GetPrestamos()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("api/Prestamo/");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Prestamo> listaprestamo = JsonConvert.DeserializeObject<List<Prestamo>>(json_response);
            return listaprestamo;
        }

        public async Task<Prestamo> GetPrestamo(int IdPrestamo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"api/Prestamo/{IdPrestamo}");
            var json_response = await response.Content.ReadAsStringAsync();
            Prestamo prestamo = JsonConvert.DeserializeObject<Prestamo>(json_response);
            return prestamo;
        }

        public async Task<Prestamo> PostPrestamo(Prestamo prestamo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(prestamo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Prestamo", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Prestamo prestamoCreado = JsonConvert.DeserializeObject<Prestamo>(jsonResponse);
            return prestamoCreado;
        }

        public async Task<Prestamo> PutPrestamo(int IdPrestamo, Prestamo prestamo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(prestamo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Prestamo/{IdPrestamo}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Prestamo prestamoEdit = JsonConvert.DeserializeObject<Prestamo>(jsonResponse);
            return prestamoEdit;
        }

        public async Task<string> DeletePrestamo(int IdPrestamo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"api/Prestamo/{IdPrestamo}");
            return "Producto eliminado correctamente";
        }
    }
}


