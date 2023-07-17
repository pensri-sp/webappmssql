using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace webappmssql.Controllers;

[ApiController]
[Route("[controller]")]
public class GadgetsController : ControllerBase
{
    private readonly MyWorldDBContext _myWorldDBContext;

    public GadgetsController(MyWorldDBContext myWorldDBContext)
    {
        _myWorldDBContext = myWorldDBContext;
    }

    //Get all gadgets
    [HttpGet]
    [Route("all")]
    public IActionResult GetAllGadgets()
    {
        var allGadgets = _myWorldDBContext.Gadgets.ToList();
        return Ok(allGadgets);
    }

    //Add Gadget
    [HttpPost]
    [Route("add")]
    public IActionResult CreateGadget(Gadgets gadgets)
    {
        _myWorldDBContext.Gadgets.AddAsync(gadgets);
        _myWorldDBContext.SaveChanges();
        return Ok(gadgets.Id);
    } 

    [HttpPut]
    [Route("update")]
    public IActionResult UpdateGadget(Gadgets gadgets)
    {
        _myWorldDBContext.Update(gadgets);
        _myWorldDBContext.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public IActionResult DeleteGadget(int id)
    {
        var gadgetToDelelte = _myWorldDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
        if(gadgetToDelelte == null)
        {    return  NotFound();}

        _myWorldDBContext.Gadgets.Remove(gadgetToDelelte);
        _myWorldDBContext.SaveChanges();
        return NoContent();

    }
}