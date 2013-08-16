using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Backgram.InstagramApi.Types;

namespace Backgram.InstagramApi
{
    delegate string getData();

    public class InstagramDataCollection: IEnumerator
    {
        private Uri _nextUri;
        private Uri _lastUri;
        private List<string> _data;
        private int _page = -1;

        public InstagramDataCollection(string metaData)
        {
            if (string.IsNullOrEmpty(metaData))
                throw new ArgumentNullException("metadata cannot be null");

            _data = new List<string>();
            _page++;
            _data.Add(metaData);
            _nextUri = new Uri(JsonConvert.DeserializeObject<MetaData>(metaData).pagination.next_url);
        }

        protected bool FetchNewPage(Uri uri)
        {
            _page++;
            _data.Add(new Func<string>(() =>
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var result = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

                        var jsonPagination = JsonConvert.DeserializeObject<MetaData>(result);

                        _lastUri = _nextUri;

                        if (string.IsNullOrEmpty(jsonPagination.pagination.next_url))
                            _nextUri = null;
                        else
                            _nextUri = new Uri(jsonPagination.pagination.next_url);

                        return result;
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw;
                }


            })());

            return true;
        }

        public object Current
        {
            get { return _data[_page]; }
        }

        public bool MoveNext()
        {
            if (_nextUri == null)
                return false;
            else
                return FetchNewPage(_nextUri);
        }

        public void Reset()
        {
            _page = -1;
            _data = new List<string>();
            _nextUri = _lastUri = null;
        }
    }
}
