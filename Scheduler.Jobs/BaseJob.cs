using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Scheduler.Common.Configuration;

namespace Scheduler.Jobs
{
    public class BaseJob
    {
        private string _hostUrl { get; }

        private string _version { get; }

        private string _token { get; }

        protected ILogger<IScheduledJob> Logger { get; }

        protected BaseJob(IIEXConfiguration config, ILogger<IScheduledJob> logger)
        {
            Logger = logger;
            _hostUrl = config.HOST;
            _version = config.VERSION;
            _token = config.TOKEN;
        }

        protected string CreateResource(string iexArea, string companyStockSymbol, string path, string optionalParameter = null)
            => $"{iexArea}/{companyStockSymbol}/{path}" +
                "{(optionalParameter != null ? '?' + optionalParameter : string.Empty)}";

        protected string GenerateGroup() => $"group_{new Random().Next(2, 10000).ToString()}";

        protected Task<T> ExecuteAsync<T>(string resource) where T: new()
        {
            var client = new RestClient(_hostUrl + "/" + _version + "/");

            var request = new RestRequest(resource);

            var taskCompletionSource = new TaskCompletionSource<T>();

            request.AddParameter("token", _token);

            client.ExecuteAsync<T>(request, (response, handle)
                => taskCompletionSource.SetResult(JsonConvert.DeserializeObject<T>(response.Content))
            );

            return taskCompletionSource.Task;
        }
    }
}