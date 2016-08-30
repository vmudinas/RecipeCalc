using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface ICalculation
    {
        RecipeTotals ProcessRecipie(RecipeTotals recipie);

    }
}
