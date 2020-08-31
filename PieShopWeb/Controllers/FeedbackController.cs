using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLLCore.Repository;
using EntitiesCore.Dto;
using EntitiesCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PieShopWeb.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FeedbackDto feedbackDto)
        {
            if(ModelState.IsValid)
            {
                var feedback = _mapper.Map<Feedback>(feedbackDto);

                _repository.AddFeedback(feedback);

                return RedirectToAction("FeedbackComplete");
            }

            return View(feedbackDto);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
