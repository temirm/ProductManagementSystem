using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;
using ProductManagementSystem.WebAPI.ViewModels;

namespace ProductManagementSystem.WebAPI.Controllers;

[Route("api/[controller]")]
public class GroupsController : ApiControllerBase
{
    private readonly IGroupsService groupsService;

    public GroupsController(IGroupsService groupsService)
    {
        this.groupsService = groupsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Guid>), 200)]
    public async Task<IActionResult> ListAll()
    {
        IEnumerable<Guid> groupIds = await groupsService.ListAll();
        return Ok(groupIds);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductGroupViewModel), 200)]
    public async Task<IActionResult> GetById(Guid id)
    {
        ProductGroup? group = await groupsService.GetById(id);

        if (group is null)
        {
            return NotFound();
        }

        return Ok(ProductGroupViewModel.FromEntity(group));
    }
}
