using System;
using System.Collections.Generic;

namespace StudentWebApi.Models;

public partial class VstudentDetail
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentAdd { get; set; } = null!;

    public string StudentClass { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public int? SubjectMax { get; set; }

    public int SubjectObt { get; set; }
}
