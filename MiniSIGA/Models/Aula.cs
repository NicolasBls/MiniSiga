//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniSIGA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aula()
        {
            this.Falta = new HashSet<Falta>();
        }
    
        public int AulaId { get; set; }
        public int PessoaId { get; set; }
        public System.DateTime Data { get; set; }
        public string Conteudo { get; set; }
        public int DisciplinaId { get; set; }
        public string Observacao { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Falta> Falta { get; set; }
    }
}