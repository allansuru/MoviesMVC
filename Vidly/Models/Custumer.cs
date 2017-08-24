﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Custumer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente.")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(200, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}