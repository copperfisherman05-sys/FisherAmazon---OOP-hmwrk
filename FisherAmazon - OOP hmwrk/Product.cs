using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FisherAmazon___OOP_hmwrk
{
    public class Product
    {
        
        public static int productCounter = 0; //Static variable to keep track of the number of Product instances created.
       
        
        /* public required string ProductId { get; init; } */    //This is a required property that must be set when creating a Product object.
        public string ProductId { get; set; } = ""; //This is a property that can be set and get. This is for testing purposes.



        private string _productName = "";

        //This will allow what is an actual name for a board game.
        public string ProductName
        {
            get { return _productName; }


            set
            {
                //This to check on each indiviual spot is a letter, a space, a dash, the and sign, and the comma sign. Nothing else
                if (value.All(a => char.IsLetter(a) || char.IsWhiteSpace(a) || a == '-' || a == '&' || a == '\''))
                {
                    _productName = value;
                }
            }
        }




        /*public string ProductDescription { get; init; } = "";*/  //Readonly property, can only be set in the constructor or at the point of declaration. REAL CODE
        public string ProductDescription { get; set; } = ""; //This is a property that can be set and get. This is for testing purposes.



        /* public required string ProductPrice { get; set; } = ""; */  //This is a required property that must be set when creating a Product object.
        public decimal ProductPrice { get; set; } //This is a property that can be set and get. This is for testing purposes.


        private string _productCategory = "uncategorized";

        public string ProductCategory
        {
            get => _productCategory;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _productCategory = "Uncategorized";
                }
                else
                {
                    //Custom setter part after changing the name
                    _productCategory = value.ToUpper(); //This will make the name of the product all uppercase letters.
                }

                
            }

        }
        public string ProductRate { get; } = "5 Stars";


        //CONSTRUCTORS

        public Product()
        {
        }

        
        public Product(string productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }


        public Product(string productId, string productName, string productDescription, decimal productPrice, string productCategory)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
        }
    }
}
