using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CruiseManagement.API.Dtos
{
    public class CabinType 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ShipId { get; set; }

    }
}
