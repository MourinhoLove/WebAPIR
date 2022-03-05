// 一个Person控制器。对本地数据库person表的数据进行CRUD
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
namespace WebAPIR.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly DataContext _dbContext;
    public PersonController(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    // 创建数据
    [HttpPost("create")]
    public ActionResult createPersion([FromBody] User value)
    {
        var message = "";

        using (_dbContext)
        {
            var user = new User
            {
                name = value.name,
                age = value.age,
                address = value.address
            };
            _dbContext.Person.Add(user);
            var i = _dbContext.SaveChanges();
            message = i > 0 ? "成功" : "失败";
        }
        return Ok("新增成功");
    }

    // 获取数据库下面的所有person
    [HttpPost("getAll")]
    public ActionResult getPerson([FromBody] PageIndex value)
    {
        using (_dbContext)
        {
            var list = _dbContext.Person.ToList();
            if (!list.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }

        }
    }
}

