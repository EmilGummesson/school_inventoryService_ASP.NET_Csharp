﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryService.ContractTypes
{
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "15.8.169+g1ccb72aefa")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class OrderProducts
    {
        
        private string nProductField;
        
        private int nAmountField;
        
        private bool nAmountFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nProduct
        {
            get
            {
                return this.nProductField;
            }
            set
            {
                this.nProductField = value;
            }
        }
        
        /// <remarks/>
        public int nAmount
        {
            get
            {
                return this.nAmountField;
            }
            set
            {
                this.nAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nAmountSpecified
        {
            get
            {
                return this.nAmountFieldSpecified;
            }
            set
            {
                this.nAmountFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MSBuild", "15.8.169+g1ccb72aefa")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class OrderProductsResponse
    {
        
        private string orderProductsResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OrderProductsResult
        {
            get
            {
                return this.orderProductsResultField;
            }
            set
            {
                this.orderProductsResultField = value;
            }
        }
    }
}
