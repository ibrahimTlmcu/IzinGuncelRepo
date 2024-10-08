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
    
    public partial class IzinTalebi
    {
        public int Id { get; set; }
        public Nullable<int> IzinTip { get; set; }
        public Nullable<int> IzinTalepPersoneId { get; set; }
        public Nullable<int> IzinOnayPersoneld { get; set; }
        public Nullable<System.DateTime> Baslangic { get; set; }
        public Nullable<System.DateTime> Bitis { get; set; }
        public string Detay { get; set; }
        public Nullable<bool> Onay { get; set; }
        public Nullable<bool> Iptal { get; set; }
        public Nullable<int> Gun { get; set; }
    
        public virtual Personel Personel { get; set; }
        public virtual OnaylananIzin OnaylananIzin { get; set; }
        public virtual İzinTipi İzinTipi { get; set; }
    }
}
