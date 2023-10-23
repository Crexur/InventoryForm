using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryForm
{
    internal class ProductClass
    {
        private int _Quantity; 
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _description;

        public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate, double Price, int quantity, string Description)
        {
            this._Quantity = quantity; this._SellingPrice = Price; this._ProductName = ProductName; this._Category = Category; this._ManufacturingDate = MfgDate; this._ExpirationDate = ExpDate; this._description = Description;
        }
        public string productName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }
        public string category
        {
            get
            {
                return this._Category;
            }

            set 
            {
                this._Category = value;
            }

            }

        public string manufacturingDate {

            get {
                return this._ManufacturingDate;
            }

            set {
                this._ManufacturingDate = value;
            }

        }

        public string expirationDate
        {

            get
            {
                return this._ExpirationDate;
            }

            set
            {
                this._ExpirationDate = value;
            }

        }

        public string description
        {

            get
            {
                return this._description;
            }

            set
            {
                this._description = value;
            }

        }

        public int quantity
        {

            get
            {
                return this._Quantity;
            }

            set
            {
                this._Quantity = value;
            }

        }

        public double sellingPrice
        {

            get
            {
                return this._SellingPrice;
            }

            set
            {
                this._SellingPrice = value;
            }

        }



    }
    }
