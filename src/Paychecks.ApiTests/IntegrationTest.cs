namespace Paychecks.ApiTests;

public class IntegrationTest : IDisposable
{
    private HttpClient? _httpClient;

    protected HttpClient HttpClient
    {
        get
        {
            if (_httpClient == default)
            {
                _httpClient = new HttpClient
                {
                    //task: update your port if necessary
                    BaseAddress = new Uri("http://localhost:5086")
                };
                _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
            }

            return _httpClient;
        }
    }

    public void Dispose()
    {
        HttpClient.Dispose();
    }
}

