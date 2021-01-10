using System;
// < validasi tambah [required]
using System.ComponentModel.DataAnnotations;
using sportstore.Helper;
// valildasi >

namespace sportstore.Models
{
    public class Category 
    {
        public int Id { get;set; }
        // for validasi
        [Required(ErrorMessage="Isi dongs !!!")]
        [StringLength(20, ErrorMessage="isi min 3 dan max 8 huruf !!!", MinimumLength=3)]
        [UniqueName]
        
        public string Name {get;set;}
    }
}
