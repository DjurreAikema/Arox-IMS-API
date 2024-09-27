﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace IMS.EF.Models;

public partial class Tool
{
    public long Id { get; set; }

    public long ApplicationId { get; set; }

    public string Name { get; set; }

    public string ApiEndpoint { get; set; }

    public virtual Application Application { get; set; }

    public virtual ICollection<ToolInput> ToolInputs { get; set; } = new List<ToolInput>();

    public virtual ICollection<ToolOutput> ToolOutputs { get; set; } = new List<ToolOutput>();
}