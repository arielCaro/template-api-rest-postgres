using System;
using System.Collections.Generic;

namespace template.api.postgres.data.Models;

public partial class TbTokenBearer
{
    public long Id { get; set; }

    public DateOnly SessionIn { get; set; }

    public DateOnly SessionOut { get; set; }

    public bool Active { get; set; }

    public string Token { get; set; } = null!;

    public long IdUser { get; set; }
}
