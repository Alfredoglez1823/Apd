using System;
using System.Collections.Generic;

namespace ApdAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int Language { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
