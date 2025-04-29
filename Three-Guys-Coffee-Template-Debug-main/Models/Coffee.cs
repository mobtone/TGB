using System.Collections.Generic;

namespace Easyweb.Site.Models
{
    public class Coffee
    {
        //en klass som representerar strukturen på data som kaffe-APIet returnerar
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> ingredients { get; set; }
        public string image { get; set; }
    }
}
