
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.Avalonia1.Utils;

public class Telemetry
{
    public static async Task SendTelemetryAsync(string metricName, Dictionary<string, string> metricLabels, double metricValue)
    {
        try
        {
            string dataProtectionKey = File.ReadAllText("/Keys/telemetry.txt");

            string userId = Protector.DecryptAES("d8f4eg9J90IAWFrFSnRFYYfMcOSSSPoCXcetIMWWtSg=",
                dataProtectionKey);
            string apiKey = Protector.DecryptAES("C+ToyV4vhlbibMFfd+4UL7zFR/UV72Z2fTe1IkhgR0fvqubergIrY5TzUhcJ16W51RHKf6vtO3mapPLIixuyCCkaNwGE/glAfsNxwCE/mYTMMdv4GbJd7KbbSNgV3WA3xBnVBdoXpUek5x5eEmdei8dotSHaUA8pFhP2soH7dz8Zh+f4ffIgjIowWirilJdfjb3v4vVOILemiSXYNCHPUJHk+WNOW5a8g/cRd3PiCHTjPE27WlftHZNjNgYzR94jTHHn3GyeG/UfntiHfKO93r0UypOH41C9Nuff7i6zmKv98vf71XBgDp+NMMWn1gnhf49wslLas1EdMInp/V8psYfu5zH9MPZXshr3fWDOQ2v4+i+YbGy6GHdqU/b9vnbQ7FkxLLyzkHZ0CYj5Y4XccIv2wp2j4bZ6APTt2yoKnqw=", 
                dataProtectionKey);
            string apiUrl = "https://influx-prod-18-prod-ap-southeast-0.grafana.net/api/v1/push/influx/write";

            HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + userId + ":" + apiKey);

            string metricLabelsText = metricLabels.Select(kv => $"{kv.Key}={kv.Value}").Aggregate((a, b) => $"{a},{b}");
            string metricText = $"{metricName},{metricLabelsText} metric={metricValue}";
            HttpContent content = new StringContent(metricText, Encoding.UTF8, "text/plain");

            await httpClient.PostAsync(apiUrl, content);
        }
        catch (Exception)
        { }  
    }
}