using System;
using System.Collections.Generic;

namespace template.api.postgres.data.Models;

public partial class TbUser
{
    public long Id { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Active { get; set; }

    public DateOnly DateCreated { get; set; }

    public DateOnly DateModified { get; set; }

    public string UserCreated { get; set; } = null!;

    public string UserModified { get; set; } = null!;

    public long IdCompany { get; set; }
}
