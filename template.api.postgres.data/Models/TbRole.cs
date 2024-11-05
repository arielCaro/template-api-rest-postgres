using System;
using System.Collections.Generic;

namespace template.api.postgres.data.Models;

public partial class TbRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }
}
