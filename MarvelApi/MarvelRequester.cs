﻿using MarvelApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace MarvelApi
{
    public class MarvelRequester: Requester
    {

        /// <summary>
        /// A timespan to compose eventually a hash
        /// </summary>
        private static TimeSpan t = new TimeSpan();
        /// <summary>
        /// The public key if necessary
        /// </summary>
        private static string Key = "0ff03084ac21b47e141e976157955918";
        /// <summary>
        /// The private key if necessary
        /// </summary>
        private static string pKey = "509beae229ea216f69a400478cfef76a07f1f40d0ff03084ac21b47e141e976157955918";
        /// <summary>
        /// The hash to compute 
        /// </summary>
        private static string hash;
        /// <summary>
        /// The URL parameters if necessary
        /// </summary>
        private string urlParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarvelRequester"/> class.
        /// </summary>
        public MarvelRequester():base("https://gateway.marvel.com/")
        {
            
        }

        public List<Characters> GetCharacters(int limit = 1, int offset = 200, string Endpoint = "v1/public/characters")
        {
            //Marvel accept a maximum of 100 character by requests
            if (limit > 100)
            {
                throw new InvalidOperationException("Limit 0 to 100 only");
            }
            //1- Get the time
            t = DateTime.Now.TimeOfDay;
            //2- Calculate hash in accordance with marvel documentation
            hash = Tools.CalculateMD5LikeMarvel(t,pKey).ToLower();
            //3- Prepare the parameters
            urlParameters = "?ts=" + t.ToString().Replace(":", "").Replace(".", "") + "&limit=" + limit + "&offset=" + offset + "&apikey=" + Key + "&hash=" + hash;

            //4- Get the json response from marvel API
            string json = base.Execute(Endpoint, urlParameters);
            if (json != "")
            {
                List<Characters> lc = null;
                CharacterDataWrapper cd = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);

                if(cd.data!=null)
                {
                    CharacterDataContainer CDC = cd.data;
                    if(CDC.results.Count>0)
                    {
                        lc = CDC.results;
                    }
                }

         
                return lc;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searches characters.
        /// </summary>
        /// <param name="limit">The number of result</param>
        /// <param name="offset">The number of character to jump before search</param>
        /// <param name="Endpoint">The endpoint</param>
        /// <param name="SearchString">The search string</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Limit 0 to 100 only</exception>
        public List<Characters> SearchCharacters(int limit = 1, 
            int offset = 200, string Endpoint = "v1/public/characters", 
            string SearchString="")
        {
            //Marvel accept a maximum of 100 character by requests
            if (limit > 100)
            {
                throw new InvalidOperationException("Limit 0 to 100 only");
            }
            //1- Get the time
            t = DateTime.Now.TimeOfDay;
            //2- Calculate hash in accordance with marvel documentation
            hash = Tools.CalculateMD5LikeMarvel(t, pKey).ToLower();
            //3- Prepare the parameters
            urlParameters = "?nameStartsWith="+HttpUtility.UrlEncode(SearchString) +"&ts=" + t.ToString().Replace(":", "").Replace(".", "") + "&limit=" + limit + "&offset=" + offset + "&apikey=" + Key + "&hash=" + hash;

            //4- Get the json response from marvel API
            string json = base.Execute(Endpoint, urlParameters);
            if (json != "")
            {
                List<Characters> lc = null;
                CharacterDataWrapper cd = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);

                if (cd.data != null)
                {
                    CharacterDataContainer CDC = cd.data;
                    if (CDC.results.Count > 0)
                    {
                        lc = CDC.results;
                    }
                }


                return lc;
            }
            else
            {
                return null;
            }
        }

    }
}
