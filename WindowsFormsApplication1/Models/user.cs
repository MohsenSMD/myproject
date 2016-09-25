﻿

namespace  Models
{
    class user :BaseEntity
    {
        public user()
        {

        }
        public bool  IsActive { get; set; }

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings =false)]
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength:20,MinimumLength =6)]
        [System.ComponentModel.DataAnnotations.Schema.Index
            (IsUnique =true)]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings =false)]
        [System.ComponentModel.DataAnnotations.StringLength
            (maximumLength:40,MinimumLength =8)]
        [System.ComponentModel.DataAnnotations.Schema.Index
            (IsUnique =true)]
        public string PassWord { get; set; }
        [System.ComponentModel.DataAnnotations.StringLength
        (maximumLength: 50)]
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
