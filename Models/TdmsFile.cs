﻿using System;
using System.Collections.Generic;
namespace SyncfusionLayout.Models;

public partial class TdmsFile
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public byte[] Data { get; set; } = null!;
}
