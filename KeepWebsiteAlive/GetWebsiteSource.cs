﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GetHTMLSource
{
    public class GetWebsiteSource
    {
        public Task<string> HTML { get { return getHTML(); } set {; } }
        public Uri websiteURL { get; set; }

        /// <summary>
        /// Gets HTML Source Code right away and every so often as specified
        /// in order to prevent a website from "going to sleep"
        /// </summary>
        /// <returns>HTML Source Code</returns>

        private Task<string> getHTML()
        {
            return Task<string>.Run(() =>
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(websiteURL);
                req.Method = "GET";

                string source;
                using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    source = reader.ReadToEnd();
                }
                return source;
            });
        }


        
    }
}
