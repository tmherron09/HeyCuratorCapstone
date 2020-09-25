using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.AnonymousQuestionBoard
{
    public class AnonymousQuestion
    {
        [Key]
        public Guid AnonymousQuestionId { get; set; }

        
        public string UserId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{h:mm:ss tt, M/d}")]
        public DateTime TimePosted { get; set; }

        public string QuestionHeader { get; set; }

        public string Question { get; set; }

        public ICollection<AnonymousComment> AnonymousComments { get; set; }


    }
}
