using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vidly.Models;
namespace Vidly.ViewModel
{
    public class CustomerFormView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
       
        public Customer customer { get; set; }

      
    }
}