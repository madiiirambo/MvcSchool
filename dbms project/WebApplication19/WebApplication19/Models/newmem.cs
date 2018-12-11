using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication19.Models
{
    public class newmem
    {
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string addr { get; set; }
        public string cnic { get; set; }
        public string passwd { get; set; }
        public int bisno { get; set; }
        public DateTime bisdate { get; set; }
        
            public int mid { get; set; }
        [ForeignKey("mid")]
        public DateTime dda { get; set; }
        public int midd {get;set;}
        public string pswd { get; set; }

        public newmem(int mid,string pswd)
        {
            this.mid = mid;
            this.pswd = pswd;

        }
        public newmem (string name,string email, string contact, string address, string cnic)
    {
         this.name = name;
            this.email = email;
            this.contact = contact;
            this.addr = address;
            this.cnic = cnic;
            

    }


        public newmem(int bino,DateTime bid,int mid,DateTime dda)
        {
            this.bisno = bino;
            this.bisdate = bid;
            this.mid = mid;
            this.dda = dda;

        }
        public newmem(int mid, string name, string email, string contact, string address, string cnic)
        { this.midd = mid;

        this.name = name;
        this.email = email;
        this.contact = contact;
        this.addr = address;
        this.cnic = cnic;
        }

        public newmem()
        {
            // TODO: Complete member initialization
        }
    }
}