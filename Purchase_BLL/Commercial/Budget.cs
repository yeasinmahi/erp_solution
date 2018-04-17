using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.BudgetTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Budget
    {
        public BudgetTDS.SprCommercialBudgetListDataTable GetBudget(DateTime searchDate)
        {
            SprCommercialBudgetListTableAdapter adp = new SprCommercialBudgetListTableAdapter();
            return adp.GetBudgetData(searchDate);
        }


        public BudgetTDS.FunCommercialBudgetDataTable GetBudgetCommercial(DateTime? searchDate)
        {
            FunCommercialBudgetTableAdapter adp = new FunCommercialBudgetTableAdapter();
            return adp.GetDataBudget(searchDate);
        }

    }
}
