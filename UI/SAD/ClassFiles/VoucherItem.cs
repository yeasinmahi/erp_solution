using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.ClassFiles
{
    public class VoucherItem
    {
        private string accountCode;
        private string accountName;
        private string description;
        private double amount;
        private bool ysnControlHead;

        public string AccountCode
        {
            get
            {
                return accountCode;
            }
            set
            {
                accountCode = value;
            }
        }

        public string AccountName
        {
            get
            {
                return accountName;
            }
            set
            {
                accountName = value;
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public bool YsnControlHead
        {
            get
            {
                return ysnControlHead;
            }
            set
            {
                ysnControlHead = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

    }
}
