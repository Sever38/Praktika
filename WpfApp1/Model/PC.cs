//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PC()
        {
            this.InstalledSoftware = new HashSet<InstalledSoftware>();
        }
    
        public int id { get; set; }
        public string Название { get; set; }
        public Nullable<int> Тип_Устройства { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstalledSoftware> InstalledSoftware { get; set; }
        public virtual ТИП_УСТРОЙСТВА ТИП_УСТРОЙСТВА1 { get; set; }
    }
}
