using DALContext;
using EntitiesCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLCore.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly PieShopContext _context;
        public FeedbackRepository(PieShopContext context)
        {
            _context = context;
        }

        public void AddFeedback(Feedback feedBack)
        {
            _context.Feedbacks.Add(feedBack);
            _context.SaveChanges();
        }
    }
}
