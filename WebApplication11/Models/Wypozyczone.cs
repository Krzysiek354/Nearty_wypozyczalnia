namespace WebApplication11.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wypozyczone")]
    public partial class Wypozyczone
    {
        [Key]
        public int IDWypo { get; set; }

        [StringLength(30)]
        public string NazwaNart { get; set; }

 

        [StringLength(40)]
        public string OSOBA { get; set; }
    }
}
