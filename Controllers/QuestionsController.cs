﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
namespace quiz_backend.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly QuizDbContext context;
        public QuestionsController(QuizDbContext context)
        { 
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return context.Questions;
        }
        [HttpGet("{quizId}")]
        public IEnumerable<Models.Question> Get([FromRoute]int quizId)
        {
            return context.Questions.Where(q => q.QuizId==quizId);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Question question)
        {
            var quiz = context.Quizzes.SingleOrDefault(q => q.ID == question.QuizId);

            if (quiz == null)
                return NotFound();

            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return Ok(question);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Question question)
        {
            if (id != question.ID)
                return BadRequest();

            context.Entry(question).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);
        }
    }
}
