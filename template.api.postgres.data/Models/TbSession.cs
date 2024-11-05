using System;
using System.Collections.Generic;

namespace template.api.postgres.data.Models;

public partial class TbSession
{
    public long Id { get; set; }

    public DateTime SessionOn { get; set; }

    public DateTime SessionOut { get; set; }

    public string TokenBearer { get; set; } = null!;

    public bool Active { get; set; }

    public long IdUser { get; set; }

    public long IdApplication { get; set; }
}
