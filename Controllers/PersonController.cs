// 一个Person控制器。对本地数据库person表的数据进行CRUD
using Microsoft.AspNetCore.Mvc;
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
            return Ok("新增成功");
        }
    }

    // 获取数据库下面的所有person
    [HttpPost("getAll")]
    public ActionResult getPerson([FromBody] PageIndex value)
    {
        using (_dbContext)
        {
            var list = _dbContext.Person.AsNoTracking().ToList();
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

    // 通过id 删除数据
    [HttpPost("deleteById")]
    public ActionResult deletPerson([FromBody] User value)
    {
        using (_dbContext)
        {
            var obj = _dbContext.Person.Find(value.id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Person.Remove(obj);
                _dbContext.SaveChanges();
                return Ok("成功啦");
            }

        }
    }

    // 更新Person
    [HttpPost("update")]
    public ActionResult updateUser([FromBody] User value)
    {
        using (_dbContext)
        {
            var obj = _dbContext.Person.Find(value.id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                obj.name = value.name;
                obj.age = value.age;
                obj.address = value.address;
                _dbContext.SaveChanges();
                return Ok("成功啦");
            }
        }
    }

}

