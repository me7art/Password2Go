using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Data;
using Password2Go.Modules.PrivateCard;

namespace Password2Go.Services.Mappers.CardDataMapper.Site
{
    public static class NoteSecretDataExtension
    {
        public static NoteCardPrivateViewModel MapToNoteCardPrivateViewModel(this NoteSecretData data)
        {
            return new NoteCardPrivateViewModel() { Note = data.Note };
        }
    }
}
