//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HESProgram.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class addAnalysi
    {
        public int addAnalysisId { get; set; }
        public int SampleId { get; set; }
        public int AnalysisId { get; set; }
    
        public virtual Analysis Analysis { get; set; }
        public virtual Sample Sample { get; set; }
    }
}
