using EntitiesCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLCore.Repository
{
   public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedBack);
    }
}
