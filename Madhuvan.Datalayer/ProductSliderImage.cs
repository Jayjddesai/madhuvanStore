//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madhuvan.Datalayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSliderImage
    {
        public int ProductSliderImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductSliderImagePath { get; set; }
    
        public virtual ProductMaster ProductMaster { get; set; }
    }
}