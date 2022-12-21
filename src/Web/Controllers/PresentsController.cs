using Application;
using Application.Presents.Commands;
using Application.Presents.Queries;
using Domain.Presents;
using Microsoft.AspNetCore.Mvc;
using Web.Requests;

namespace Web.Controllers;

[ApiController]
[Route("api/presents")]
public class PresentsController : ControllerBase
{
    private readonly IQueryHandler<GetPresentQuery, Present> _getPresentHandler;
    private readonly IQueryHandler<GetPresentsQuery, List<Present>> _getPresentsHandler;
    private readonly ICommandHandler<CreatePresentCommand> _createPresentHandler;


    public PresentsController(
        IQueryHandler<GetPresentQuery, Present> getPresentHandler,
        IQueryHandler<GetPresentsQuery, List<Present>> getPresentsHandler,
        ICommandHandler<CreatePresentCommand> createPresentHandler)
    {
        _getPresentHandler = getPresentHandler;
        _getPresentsHandler = getPresentsHandler;
        _createPresentHandler = createPresentHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var allPresents = await _getPresentsHandler.Handle(new GetPresentsQuery(), cancellationToken);
        return Ok(allPresents.Select(present => new
        {
            present.Id,
            present.To,
            present.From
        }));
    }

    [HttpGet]
    [Route("{presentId:int}")]
    public async Task<IActionResult> Get(int presentId, CancellationToken cancellationToken)
    {
        var present = await _getPresentHandler.Handle(new GetPresentQuery(presentId), cancellationToken);
        return Ok(new
        {
            present.Id,
            present.To,
            present.From
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePresentRequest request, CancellationToken cancellationToken)
    {
        await _createPresentHandler.Handle(CreatePresentCommand.With(request.To, request.From), cancellationToken);
        return Accepted();
    }
}