using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace UI
{
    public class OrderType
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public int Name
        {
            get => default(int);
            set
            {
            }
        }

        public ProductConfig ProductConfig
        {
            get => default(ProductConfig);
            set
            {
            }
        }

        public SupplierConfig SupplierConfig
        {
            get => default(SupplierConfig);
            set
            {
            }
        }
    }

    public class SupplierConfig
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public int SupplierId
        {
            get => default(int);
            set
            {
            }
        }

        public int OrderTypeId
        {
            get => default(int);
            set
            {
            }
        }

        public int TaxPercentage
        {
            get => default(int);
            set
            {
            }
        }

        public void Add(SupplierConfig model)
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Get()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ProductConfig
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public int ProductId
        {
            get => default(int);
            set
            {
            }
        }

        public int OrderTypeId
        {
            get => default(int);
            set
            {
            }
        }

        public int TaxPercentage
        {
            get => default(int);
            set
            {
            }
        }

        public int TaxTypeId
        {
            get => default(int);
            set
            {
            }
        }

        public TaxType TaxType
        {
            get => default(TaxType);
            set
            {
            }
        }

        public void Add(ProductConfig model)
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Get()
        {
            throw new System.NotImplementedException();
        }
    }

    public class TaxInOutType
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public int Name
        {
            get => default(int);
            set
            {
            }
        }

        public PO PO
        {
            get => default(PO);
            set
            {
            }
        }
    }

    public class CopyOfTaxType
    {
        public int Id
        {
            get => default(int);
            set
            {
            }
        }

        public int Name
        {
            get => default(int);
            set
            {
            }
        }

        public void Add(CopyOfTaxType model)
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Get()
        {
            throw new System.NotImplementedException();
        }
    }
}