using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tchat.Core.DTO;
using Tchat.Core.Models;

namespace Projet_tchat.Models
{
    public class MessageModel
    {
        public List<MessageDTO> messageVue { get; set; }
        public List<Private_message> messageEdit { get; set; }
    }
}