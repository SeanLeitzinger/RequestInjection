using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SimpleInjector;
using System.Linq;
using System.Threading.Tasks;

namespace RequestInjectionTest
{
    public class QueryModelBinderProvider : IModelBinderProvider
    {
        Container container;

        public QueryModelBinderProvider(Container container)
        {
            this.container = container;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context?.BindingInfo?.BindingSource == BindingSource.Query)
                return new QueryModelBinder(container);

            return null;
        }
    }

    public class QueryModelBinder : IModelBinder
    {
        Container container;

        public QueryModelBinder(Container container)
        {
            this.container = container;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelInstance = container.GetInstance(bindingContext.ModelType);
            var nameValuePairs = bindingContext.ActionContext.HttpContext.Request.Query.ToDictionary(m => m.Key, m => m.Value.FirstOrDefault());

            var json = JsonConvert.SerializeObject(nameValuePairs);

            JsonConvert.PopulateObject(json, modelInstance, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });

            bindingContext.Result = ModelBindingResult.Success(modelInstance);

            return Task.CompletedTask;
        }

        private void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
}
