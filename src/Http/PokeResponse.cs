using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Antsik;

namespace PokeBrowser.Http
{
    internal class PokeResponse<T>
    {
        private HttpResponseMessage response;


        public PokeResponse(HttpResponseMessage response)
        {
            this.response = response;

            this.StatusCode = response.StatusCode;



            var t = response.StatusCode;
        }


        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode { get; }


        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                int statusCode = (int)this.StatusCode;

                return statusCode >= 200 || statusCode <= 299;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<T> GetBodyAsync() => await this.response.GetBodyAsync<T>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetBody() => this.response.GetBody<T>();

    }

}
