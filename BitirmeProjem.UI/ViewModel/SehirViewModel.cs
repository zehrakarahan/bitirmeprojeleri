using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.UI.ViewModel
{
    public class SehirViewModel
    {

        public SehirViewModel()
        {
            this.IlceList = new List<SelectListItem>();
            IlceList.Add(new SelectListItem
            {
                Text = "Seciniz",
                Value = "",
            });
        }
        public int Id{ get; set; }
        public int IlceId { get; set; }
        public int BaslikId { get; set; }
        public int AdresId { get; set; }
        public string BaslikBilgisi { get; set; }
        public List<SelectListItem> SehirList { get; set; }
        public List<SelectListItem> IlceList { get; set; }
        public List<SelectListItem> AdresList { get; set; }
        public List<SelectListItem> BaslikList { get; set; }
    }
}