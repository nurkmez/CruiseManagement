using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Dtos
{
    public class Ship
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int CruiseLineId { get; set; }
    }
}
