using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryTwo.Models
{
    public class DirectoryEntry
    {
        public int    Id        { get; set; }

        public string Prot      { get; set; }   //Protocal
        public string SubDom    { get; set; }   //SubDomain
        public string Dom       { get; set; }   //Domain
        public string TopDom    { get; set; }   //Top-Level Domain
        public string SiteName  { get; set; }   //SiteName
        public string SiteType  { get; set; }   //Site Type
    }
}
