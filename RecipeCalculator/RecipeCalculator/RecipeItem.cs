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
    
    public partial class RecipeItem
    {
        public int RecipeId { get; set; }
        public int ItemId { get; set; }
        public double Quantity { get; set; }
        public Nullable<int> UnitId { get; set; }
        public bool Active { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
