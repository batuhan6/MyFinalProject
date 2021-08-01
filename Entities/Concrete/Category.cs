using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity  //IEntity bu adamın referansını tutabiliyor
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
