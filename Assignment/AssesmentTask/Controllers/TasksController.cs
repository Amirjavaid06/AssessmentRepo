using Application.Task.Commands;
using Application.Task.Queries;
using AssesmentTask.Models;
using AutoMapper;
using Domain.Aggregates.TaskAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Runtime.InteropServices;

namespace AssesmentTask.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
            GetAllTasksQuery queryHandler = new GetAllTasksQuery();
            var tasks =await _mediator.Send(queryHandler);
            var result = _mapper.Map<List<TasksViewModel>>(tasks);

            return View(result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TasksViewModel mdoel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateTaskCommand command = new CreateTaskCommand();
                    var mapping = _mapper.Map<CreateTaskCommand>(mdoel);
                    var result = await _mediator.Send(mapping);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var result =await GetTaskById(id);
            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TasksViewModel mdoel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UpdateTaskCommand command = new UpdateTaskCommand();
                    var mapping = _mapper.Map<UpdateTaskCommand>(mdoel);
                    var result = _mediator.Send(mapping);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result =await GetTaskById(id);
            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                DeleteTaskCommand command = new DeleteTaskCommand();
                command.Id = id;
               await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task< TasksViewModel> GetTaskById(int id)
        {
            GetTaskByIdQuery queryHandler = new GetTaskByIdQuery();
            queryHandler.Id = id;
            var tasks = await _mediator.Send(queryHandler);
            var result = _mapper.Map<TasksViewModel>(tasks);
            return result;
        }
    }
}
