using System;
using System.Collections.Generic;

namespace WebApiAngularClient.Models
{
    public partial class Avis
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public double Note { get; set; }
        public int IdFormation { get; set; }
        public DateTime DateAvis { get; set; }
        public string UserId { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
    }
}
