using System;
//validasi
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sportstore.Models
{
    public class Product 
    {
        public int Id { get;set; }

        [Required]  //tdk boleh kosong
        public string Name {get;set;}
        public string Description {get;set;}
        [Required]
        public decimal Price {get;set;}
        public string img { get;set; }

        //bisa nambah satu Category punya banyak Product
        public Category Category {get;set;}
        //validasi foreign key
        [NotMapped]
         public int CatId { get;set; }

         

    }
}