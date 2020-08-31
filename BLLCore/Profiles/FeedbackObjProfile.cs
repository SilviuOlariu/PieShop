using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EntitiesCore.Dto;
using EntitiesCore.Models;

namespace BLLCore.Profiles
{
   public class FeedbackObjProfile:Profile
    {
        public FeedbackObjProfile()
        {
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();
        }
    }
}
