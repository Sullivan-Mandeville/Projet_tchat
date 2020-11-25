using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.DTO;
using Tchat.Core.Models;

namespace Tchat.Infrastructure.dal
{
    public interface IRepository
    {
       

        LoginDTO Authentifier(string email, string password);
        List<UserDTO>  liste();
        List<PostDTO> AllPost();
        List<CommentDTO> ListeCommentaire(List<int> PostID);
        List<PostDTO> postByUserID(int id);
        List<User> liste_user_id(int id);
        List<MessageDTO> message(int UserID, int id_user);
       // PostDTO like(int id_post, int id_user);
    }


   
}
