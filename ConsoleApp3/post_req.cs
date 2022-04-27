using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Net;

public class post_req
{
    public JObject update(string key)
    {
        string url = /*url update*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }

    public JObject addBot(string key, string bot_id)
    {
        string url = /*url addBot*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            pars.Add("bot_id", bot_id);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }

    public JObject getCommand(string key, string bot_id)
    {
        string url = /*url getCommand*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            pars.Add("bot_id", bot_id);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }

    public JObject delCommand(string key, string bot_id)
    {
        string url = /*delCommand*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            pars.Add("bot_id", bot_id);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }

    public JObject addOtherData(string key, string bot_id, string type, string content)
    {
        string url = /*addOtherData*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            pars.Add("bot_id", bot_id);
            pars.Add(type, content);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }


    public JObject getOtherData(string key, string bot_id, string required)
    {
        string url = /*getOtherData*/;
        using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();
            pars.Add("key", key);
            pars.Add("bot_id", bot_id);
            pars.Add("required", required);
            var response = webClient.UploadValues(url, pars);
            string str = System.Text.Encoding.UTF8.GetString(response);
            JObject jresponse = JObject.Parse(str);
            return jresponse;
        }
    }
}
