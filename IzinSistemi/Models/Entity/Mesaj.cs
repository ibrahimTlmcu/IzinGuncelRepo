//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IzinSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mesaj
    {
        public int Id { get; set; }
        public Nullable<int> GonderenId { get; set; }
        public Nullable<int> AlıcıId { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    }
}
