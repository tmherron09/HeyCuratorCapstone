using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.AnonymousQuestionBoard
{
    public class AnonymousComment
    {
        [Key]
        public Guid AnonymousCommentId { get; set; }

        
        [ForeignKey("AnonymousQuestion")]
        public Guid AnonymousQuestionId { get; set; }
        public AnonymousQuestion AnonymousQuestion { get; set; }

        
        public string UserId { get; set; }

        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{h:mm:ss tt, M/d}")]
        public DateTime TimeStamp{ get; set; }


        public string CommentBody { get; set; }
    }
}
