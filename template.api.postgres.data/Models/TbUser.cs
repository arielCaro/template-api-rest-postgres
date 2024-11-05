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

    public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public int Phone { get; set; }

    public int PhoneMobile { get; set; }

    public string CodePhoneCountry { get; set; } = null!;

    public string Name { get; set; } = null!;
}
