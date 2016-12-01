using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookShelf.MVC.Infrastructure
{
    public class SessionKeys : ISessionKeys
    {
        private HttpSessionState _session;

        public SessionKeys()
        {
            _session = HttpContext.Current.Session;        
        }

        public int? CurrentPage
        {
            get {  return _session["CurrentPage"] != null ? _session["CurrentPage"] as int? : null;  }
            set { _session["CurrentPage"] = value;  }
        }

        public string SearchTerm
        {
            get { return _session["SearchTerm"] != null ? _session["SearchTerm"].ToString() : string.Empty; }
            set { _session["CurrentPage"] = value; }
        }
    }
}