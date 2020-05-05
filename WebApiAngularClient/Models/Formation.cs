using System;
using System.Collections.Generic;

namespace WebApiAngularClient.Models
{
    public partial class Formation
    {
        public Formation()
        {
            Avis = new HashSet<Avis>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string NomSeo { get; set; }

        public virtual ICollection<Avis> Avis { get; set; }
    }
}
