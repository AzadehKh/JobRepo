using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobRepo.Model
{

     /*
       To control scaffolding for individual tables, partial class for those tables which need to be data entried through 
      ASP.NET Dynamic Data has been added and also [ScaffoldTable(true)] attribute has been applied to the partial classes.
     */

    [ScaffoldTable(true)]
    public partial class Location
    {
    }

    [ScaffoldTable(true)]
    public partial class Country
    {
    }

    [ScaffoldTable(true)]
    public partial class City
    {
    }

    [ScaffoldTable(true)]
    public partial class Province
    {

    }


}