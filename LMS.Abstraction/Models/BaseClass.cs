﻿using Core.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonIgnoreRequest = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonIgnoreResponse = Newtonsoft.Json.JsonIgnoreAttribute;

namespace LMS.Abstraction.Models
{
    public class BaseClass
    {
        public bool IsActive { get; set; } = true;

        [JsonIgnoreResponse]
        [JsonIgnoreRequest]
        public DateTime CreatedDate { get; set; } = CommonUtils.GetDefaultDateTime();

        [JsonIgnoreResponse]
        [JsonIgnoreRequest]
        public String CreatedBy { get; set; }

        [JsonIgnoreResponse]
        [JsonIgnoreRequest]
        public DateTime UpdatedDate { get; set; } = CommonUtils.GetDefaultDateTime();

        [JsonIgnoreResponse]
        [JsonIgnoreRequest]
        public String UpdatedBy { get; set; }

        [JsonIgnoreResponse]
        [JsonIgnoreRequest]
        public bool IsDeleted { get; set; }

    }
}
