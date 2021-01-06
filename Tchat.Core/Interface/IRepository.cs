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
        List<MessageDTO> message(int UserID, int id_user);
        MONPOSTIDDTO ididepost(int postid);
        UserDTO utilisateurmessage(int id);

    //    void messageprivée(int id_sender, int id_recepient, String content);




    }


   
}
