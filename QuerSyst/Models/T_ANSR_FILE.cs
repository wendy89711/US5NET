//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuerSyst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_ANSR_FILE
    {
        public string CASE_NO { get; set; }
        public int QUER_NUMB { get; set; }
        public int FILE_NO { get; set; }
        public string FILE_ADDR { get; set; }
        public string FILE_NAME { get; set; }
        public string UPLD_DATE { get; set; }
    
        public virtual T_CASE_BASE T_CASE_BASE { get; set; }
    }
}
