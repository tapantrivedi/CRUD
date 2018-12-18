using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace CRUD.Models
{
    public class Dish
    {
    [Key]
        public int iddishes { get; set; }
        [Required (ErrorMessage = "Dish name can not be emplty")]
        [MinLength(3,ErrorMessage = " DishName Error Name Must be 3 or more Character long")]

        public string Name  { get; set; }
        [Required (ErrorMessage = "Chef  can not be emplty")]
        [MinLength(3,ErrorMessage = " Error Chef name Must be 3 or more Character long")]
        public string Chef  { get; set; }
        [Range(1,5, ErrorMessage = "Tastiness can not be emplty")]
        
      
        public int Tastiness { get; set; }
        
        [Range(1,5, ErrorMessage = " Can Must be  between 1 to 5")]
        public int Calories   { get; set; }
        
        [Required (ErrorMessage = "Description  can not be emplty")]
        [MinLength(3,ErrorMessage = " Error Description name Must be 3 or more Character long")]
        
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }

}