﻿using NoteIt.Application.Common;

namespace NoteIt.Application.Handlers.Note;
public class NoteInfo : InfoBase, IMapFrom<Domain.Entities.Note>
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
