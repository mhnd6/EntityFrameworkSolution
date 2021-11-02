using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkUI.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        [Required]
        public string EmailAddress { get; set; }
    }
}
