
using portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyectos(); //
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>()
            {
                new ProyectoDTO()
                {
                    Titulo = "Presentacion para marca",
                    Descripcion = "Codigo para Email con HTML y CSS",
                    Link = "https://pwhoja.neocities.org/Email/index.html",
                    ImagenURL ="/assets/Screenshot 2022-03-31 114519.png"
                },
                 new ProyectoDTO()
                {
                    Titulo = "PokeApi",
                    Descripcion = "Consumo de PokeApi con Ionic-Angular",
                    Link = "https://github.com/lMiguelVSl/Pokemon",
                    ImagenURL ="/assets/Screenshot 2022-03-31 114940.png"
                },
                  new ProyectoDTO()
                {
                    Titulo = "Curso JavaScript Jr",
                    Descripcion = "Documentacion sobre curso a nivel Junior de JavaScript",
                    Link = "https://github.com/lMiguelVSl/PW/tree/master/DesarrolloAppsWebConJs/LvlJuniorJavaScript",
                    ImagenURL ="/assets/Screenshot 2022-03-31 115549.png"
                },
            };
        }
    }
}
