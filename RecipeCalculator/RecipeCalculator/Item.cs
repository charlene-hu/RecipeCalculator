//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeCalculator
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public Item()
        {
            this.RecipeItems = new HashSet<RecipeItem>();
            this.Prices = new HashSet<Price>();
        }
    
        public string Name { get; set; }
        public bool Organic { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<RecipeItem> RecipeItems { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}