using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.Model
{
    public class Articles
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlImage { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
