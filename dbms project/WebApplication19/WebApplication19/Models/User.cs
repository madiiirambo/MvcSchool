using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication19.Models
{
    public class User
    {
        public int Userid { get; set; }
        [ForeignKey("mid")]
        public virtual member member { get; set; }
        public string passward { get; set; }
        public User(int mid,string pass)
        {

            this.Userid = mid;
            this.passward = pass;
        }
    }
}