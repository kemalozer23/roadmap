using System.Text;

public class EndpointBuilder
{
    public string BaseUrl { get; set; }
    private readonly StringBuilder urlBuilder = new();
    private readonly StringBuilder paramsBuilder = new();
    private const char defaultDelimiter = '/';

    public EndpointBuilder(string baseUrl)
    {
        BaseUrl = baseUrl;
    }

    public EndpointBuilder Append(string value)
    {
        urlBuilder.Append(value);
        urlBuilder.Append(defaultDelimiter);
        return this;
    }

    public EndpointBuilder AppendParam(string name, string value)
    {
        paramsBuilder.Append($"{name}={value}&");
        return this;
    }

    public string Build()
    {
        if (BaseUrl.EndsWith(defaultDelimiter))
            urlBuilder.Insert(0, BaseUrl);
        else
            urlBuilder.Insert(0, BaseUrl + defaultDelimiter);

        var url = urlBuilder.ToString().TrimEnd('&');

        if(paramsBuilder.Length > 0)
        {
            var urlParams = paramsBuilder.ToString().TrimEnd('&');
            url = urlBuilder.ToString().TrimEnd(defaultDelimiter).TrimEnd('&');

            url = $"{url}?{urlParams}";
        }

        return url.TrimEnd(defaultDelimiter);
    }
}