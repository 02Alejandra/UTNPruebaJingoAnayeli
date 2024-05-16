using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTNPruebaJingoAnayeli.Models
{
    public class Launcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> GamesList { get; set; }
    }
}
