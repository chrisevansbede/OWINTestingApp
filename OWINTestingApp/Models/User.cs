namespace OWINTestingApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "text")]
        public string Username { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "text")]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "text")]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "text")]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime DOB { get; set; }
    }
}
