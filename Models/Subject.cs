using System;
using System.Collections.Generic;

namespace StudentWebApi.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int? SubjectMax { get; set; }

    public int SubjectObt { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
