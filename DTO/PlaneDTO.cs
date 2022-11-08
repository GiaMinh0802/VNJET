using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PlaneDTO
    {
        private string idPlane;
        private string namePlane;
        private string seatsPlane;

        public PlaneDTO()
        {
        }

        public PlaneDTO(string idPlane, string namePlane, string seatsPlane)
        {
            IdPlane = idPlane;
            NamePlane = namePlane;
            SeatsPlane = seatsPlane;
        }

        public string IdPlane { get => idPlane; set => idPlane = value; }
        public string NamePlane { get => namePlane; set => namePlane = value; }
        public string SeatsPlane { get => seatsPlane; set => seatsPlane = value; }
    }
}
