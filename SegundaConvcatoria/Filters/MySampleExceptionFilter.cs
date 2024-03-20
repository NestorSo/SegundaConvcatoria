using SegundaConvcatoria.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SegundaConvcatoria.Filters
{
    public class MySampleExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IModelMetadataProvider _modelMetataProvider;

        public MySampleExceptionFilter(IWebHostEnvironment webHostEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetataProvider = modelMetadataProvider;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyException)
            context.Result = new JsonResult($"Fallo en la aplicacion {_webHostEnvironment.ApplicationName}" +
                $". La excepcion del tipo {context.Exception.GetType()}");
        }
    }
}
