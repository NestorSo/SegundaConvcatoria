using Microsoft.AspNetCore.Mvc.Filters;

namespace SegundaConvcatoria.Filters
{
    public class MySampleActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _name;

        public MySampleActionFilterAttribute(string name)
        {
            _name = name;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Filter - After {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before {_name}");
        }
    }
}
